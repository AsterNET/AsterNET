using System;
using System.Collections;
using System.Reflection;
using System.Resources;

namespace AspNetCore.AsterNET.FastAGI
{
    /// <summary>
    ///     A MappingStrategy that is configured via a resource bundle.<br />
    ///     The resource bundle contains the script part of the url as key and the fully
    ///     qualified class name of the corresponding AGIScript as value.<br />
    ///     Example:
    ///     <pre>
    ///         noopcommand = AsterNET.FastAGI.Command.NoopCommand
    ///     </pre>
    ///     NoopCommand must implement the AGIScript interface and have a default constructor with no parameters.<br />
    /// </summary>
    [Obsolete("This class has been depreciated in favour of MappingStrategies.ResourceMappingStrategy", false)]
    public class MappingStrategy : IMappingStrategy
    {
#if LOGGER
        private readonly Logger logger = Logger.Instance();
#endif
        private string resourceName;
        private Hashtable mapping;

        public MappingStrategy()
        {
            resourceName = Common.AGI_DEFAULT_RESOURCE_BUNDLE_NAME;
            mapping = null;
        }

        public MappingStrategy(string resourceName)
        {
            this.resourceName = resourceName;
            mapping = null;
        }

        public AGIScript DetermineScript(AGIRequest request)
        {
            AGIScript script = null;
            if (mapping != null)
                lock (mapping.SyncRoot)
                {
                    if (mapping.Contains(request.Script))
                        script = (AGIScript) mapping[request.Script];
                }
            return script;
        }

        public string ResourceBundleName
        {
            set
            {
                if (value == null)
                {
                    mapping = null;
                    resourceName = null;
                }
                else if (resourceName != value)
                {
                    resourceName = value;
                    Load();
                }
            }
        }

        public void Load()
        {
            string scriptName;
            string className;
            AGIScript agiScript;

            if (mapping == null)
                mapping = new Hashtable();
            lock (mapping)
            {
                mapping.Clear();
                try
                {
                    var rr = new ResourceReader(AppDomain.CurrentDomain.BaseDirectory + resourceName);
                    foreach (DictionaryEntry de in rr)
                    {
                        scriptName = (string) de.Key;
                        className = (string) de.Value;
                        agiScript = CreateAGIScriptInstance(className);
                        if (mapping.Contains(scriptName))
                            throw new AGIException(String.Format("Duplicate mapping name '{0}' in file {1}", scriptName,
                                resourceName));
                        mapping.Add(scriptName, agiScript);
#if LOGGER
                        logger.Info("Added mapping for '" + scriptName + "' to class " + agiScript.GetType().FullName);
#endif
                    }
                }
                catch (Exception ex)
                {
#if LOGGER
                    logger.Error("Resource bundle '" + resourceName + "' is missing.");
#endif
                    throw ex;
                }
            }
        }

        private AGIScript CreateAGIScriptInstance(string className)
        {
            Type agiScriptClass;
            ConstructorInfo constructor;
            AGIScript agiScript;

            try
            {
                agiScriptClass = Type.GetType(className);
                constructor = agiScriptClass.GetConstructor(new Type[] {});
                agiScript = (AGIScript) constructor.Invoke(new object[] {});
            }
            catch (Exception ex)
            {
#if LOGGER
                logger.Error("Unable to create AGIScript instance of type " + className, ex);
                return null;
#else
				throw new AGIException("Unable to create AGIScript instance of type " + className, ex);
#endif
            }
            return agiScript;
        }
    }
}