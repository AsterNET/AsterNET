using System.Security.Cryptography;

namespace AspNetCore.AsterNET.Util
{
    /// <summary>
    ///     Encapsulates the functionality of message digest algorithms such as SHA-1 or MD5.
    /// </summary>
    public class MD5Support
    {
        private readonly HashAlgorithm _algorithm;
        private int _position;
        private byte[] data = new byte[0];

        /// <summary>
        ///     Creates a message digest using the specified name to set Algorithm property.
        /// </summary>
        /// <param name="algorithm">The name of the algorithm to use</param>
        public MD5Support(string algorithm)
        {
            var algorithmName = algorithm.Equals("SHA-1") ? "SHA" : algorithm;
            _algorithm = (HashAlgorithm) CryptoConfig.CreateFromName(algorithmName);
            data = new byte[0];
            _position = 0;
        }

        #region DigestData

        /// <summary>
        ///     Computes the hash value for the internal data digest.
        /// </summary>
        /// <returns>The array of signed bytes with the resulting hash value</returns>
        public sbyte[] DigestData
        {
            get
            {
                var bytes = _algorithm.ComputeHash(data);
                var sbytes = new sbyte[bytes.Length];
                for (var i = 0; i < bytes.Length; i++)
                    sbytes[i] = (sbyte) bytes[i];
                data = null;
                _position = 0;
                return sbytes;
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///     Updates the digest data with the specified array of bytes by making an append
        ///     operation in the internal array of data.
        /// </summary>
        /// <param name="newData">The array of bytes for the update operation</param>
        public void Update(byte[] newData)
        {
            if (_position == 0)
            {
                data = newData;
                _position = data.Length - 1;
            }
            else
            {
                var oldData = data;
                data = new byte[newData.Length + _position + 1];
                oldData.CopyTo(data, 0);
                newData.CopyTo(data, oldData.Length);
                _position = data.Length - 1;
            }
        }

        #endregion

        #region GetInstance

        /// <summary>
        ///     Generates a new instance of the MessageDigestSupport class using the specified algorithm
        /// </summary>
        /// <param name="algorithm">The name of the algorithm to use</param>
        /// <returns>A new instance of the MessageDigestSupport class</returns>
        public static MD5Support GetInstance(string algorithm)
        {
            return new MD5Support(algorithm);
        }

        #endregion

        #region GetInstance

        /// <summary>
        ///     Generates a new instance of the MessageDigestSupport class using the specified algorithm
        /// </summary>
        /// <returns>A new instance of the MD5 algorithm class</returns>
        public static MD5Support GetInstance()
        {
            return new MD5Support("MD5");
        }

        #endregion
    }
}