using System;
using System.Security.Cryptography;

namespace Asterisk.NET.Util
{
	/// <summary>
	/// Encapsulates the functionality of message digest algorithms such as SHA-1 or MD5.
	/// </summary>
	public class MD5Support
	{
		private HashAlgorithm algorithm;
		private byte[] data = new byte[0];
		private int position;
		private string algorithmName;

		/// <summary>
		/// Creates a message digest using the specified name to set Algorithm property.
		/// </summary>
		/// <param name="algorithm">The name of the algorithm to use</param>
		public MD5Support(string algorithm)
		{
			if (algorithm.Equals("SHA-1"))
				this.algorithmName = "SHA";
			else
				this.algorithmName = algorithm;
			this.algorithm = (HashAlgorithm)CryptoConfig.CreateFromName(this.algorithmName);
			this.data = new byte[0];
			this.position = 0;
		}

		#region DigestData
		/// <summary>
		/// Computes the hash value for the internal data digest.
		/// </summary>
		/// <returns>The array of signed bytes with the resulting hash value</returns>
		public sbyte[] DigestData
		{
			get
			{
				byte[] bytes = this.algorithm.ComputeHash(this.data);
				sbyte[] sbytes = new sbyte[bytes.Length];
				for (int i = 0; i < bytes.Length; i++)
					sbytes[i] = (sbyte)bytes[i];
				this.data = null;
				this.position = 0;
				return sbytes;
			}
		}
		#endregion

		#region Update
		/// <summary>
		/// Updates the digest data with the specified array of bytes by making an append
		/// operation in the internal array of data.
		/// </summary>
		/// <param name="newData">The array of bytes for the update operation</param>
		public void Update(byte[] newData)
		{
			if (position == 0)
			{
				this.data = newData;
				this.position = this.data.Length - 1;
			}
			else
			{
				byte[] oldData = this.data;
				this.data = new byte[newData.Length + position + 1];
				oldData.CopyTo(this.data, 0);
				newData.CopyTo(this.data, oldData.Length);
				this.position = this.data.Length - 1;
			}
		}
		#endregion

		#region GetInstance
		/// <summary>
		/// Generates a new instance of the MessageDigestSupport class using the specified algorithm
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
		/// Generates a new instance of the MessageDigestSupport class using the specified algorithm
		/// </summary>
		/// <returns>A new instance of the MD5 algorithm class</returns>
		public static MD5Support GetInstance()
		{
			return new MD5Support("MD5");
		}
		#endregion
	}
}
