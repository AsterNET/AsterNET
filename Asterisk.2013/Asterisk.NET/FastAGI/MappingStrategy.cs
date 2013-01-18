using System;	
using System.Collections;
using System.Resources;
using System.Reflection;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// A MappingStrategy that is configured via a resource bundle.<br/>
	/// The resource bundle contains the script part of the url as key and the fully
	/// qualified class name of the corresponding AGIScript as value.<br/>
	/// Example:
	/// <pre>
	/// noopcommand = Asterisk.NET.FastAGI.Command.NoopCommand
	/// </pre>
	/// NoopCommand must implement the AGIScript interface and have a default constructor with no parameters.<br/>
	/// </summary>
	public class MappingStrategy
	{
#if LOGGER
		private Logger logger = Logger.Instance();
#endif
		private string resourceName;
		private Hashtable mapping;

		public MappingStrategy()
		{
			this.resourceName = Common.AGI_DEFAULT_RESOURCE_BUNDLE_NAME;
			this.mapping = null;
		}

		public MappingStrategy(string resourceName)
		{
			this.resourceName = resourceName;
			this.mapping = null;
		}

		internal AGIScript DetermineScript(AGIRequest request)
		{
			AGIScript script = null;
			if (mapping != null)
				lock (mapping.SyncRoot)
				{
					if (mapping.Contains(request.Script))
						script = (AGIScript)mapping[request.Script];
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
				else if (this.resourceName != value)
				{
					this.resourceName = value;
					Load();
				}
			}
		}

		internal void Load()
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
					ResourceReader rr = new ResourceReader(AppDomain.CurrentDomain.BaseDirectory + resourceName);
					foreach (DictionaryEntry de in rr)
					{
						scriptName = (string)de.Key;
						className = (string)de.Value;
						agiScript = createAGIScriptInstance(className);
						if(mapping.Contains(scriptName))
							throw new AGIException(String.Format("Duplicate mapping name '{0}' in file {1}", scriptName, resourceName));
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

		private AGIScript createAGIScriptInstance(string className)
		{
			Type agiScriptClass;
			ConstructorInfo constructor;
			AGIScript agiScript;
			
			try
			{
				agiScriptClass = Type.GetType(className);
				constructor = agiScriptClass.GetConstructor(new Type[]{});
				agiScript = (AGIScript) constructor.Invoke(new object[]{});
			}
			catch(Exception ex)
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