using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// Response that is received when sending a GetConfigAction.<br/>
	/// Asterisk's response to the GetConfig command is ugly, and requires some
	/// parsing of attributes. This class lazily parses its own attributes to hide
	/// the ugly details. If the file requested exists but does not contain at least
	/// a line with a category, the ResponseBuilder won't create an instance of
	/// GetConfigResponse, as it won't know what the empty response is.
	/// </summary>
	public class GetConfigResponse : ManagerResponse
	{
		private Dictionary<int, string> categories;
		private Dictionary<int, Dictionary<int, string>> lines;

		/// <summary>
		/// Get the map of category numbers to category names.
		/// </summary>
		public Dictionary<int, string> Categories
		{
			get
			{
				if (categories == null)
				{
					categories = new Dictionary<int, string>();
					lines = new Dictionary<int, Dictionary<int, string>>();
					if (attributes != null)
						foreach (string key in attributes.Keys)
						{
							string keyLower = key.ToLower(Helper.CultureInfo);
							if (keyLower.StartsWith("category-"))
							{
								string[] parts = key.Split(Common.MINUS_SEPARATOR);
								if (parts.Length < 2)
									continue;

								int categoryNumber;
								if (!int.TryParse(parts[1], out categoryNumber))
									continue;
								categories.Add(categoryNumber, attributes[key]);
								continue;
							}
							if (keyLower.StartsWith("line-"))
							{
								string[] parts = key.Split(Common.MINUS_SEPARATOR);
								if (parts.Length < 3)
									continue;

								int categoryNumber;
								if (!int.TryParse(parts[1], out categoryNumber))
									continue;

								int lineNumber;
								if (!int.TryParse(parts[2], out lineNumber))
									continue;
								if (!lines.ContainsKey(categoryNumber))
									lines.Add(categoryNumber, new Dictionary<int, string>());

								if(lines[categoryNumber].ContainsKey(lineNumber))
									lines[categoryNumber][lineNumber] = attributes[key];
								else
									lines[categoryNumber].Add(lineNumber, attributes[key]);
							}
						}
				}
				return categories;
			}
		}

		/// <summary>
		/// Returns the map of line number to line value for a given category.
		/// </summary>
		/// <param name="categoryNumber">a valid category number from getCategories.</param>
		/// <returns></returns>
		public Dictionary<int, string> Lines(int category)
		{
			if (lines == null)
			{
				lines = new Dictionary<int, Dictionary<int, string>>();
				if (attributes != null)
					foreach (string key in attributes.Keys)
						if (key.ToLower(Helper.CultureInfo).StartsWith("line-"))
						{
							string[] parts = key.Split(Common.MINUS_SEPARATOR);
							if (parts.Length < 3)
								continue;

							int categoryNumber;
							if (!int.TryParse(parts[1], out categoryNumber))
								continue;

							int lineNumber;
							if (!int.TryParse(parts[2], out lineNumber))
								continue;
							if (!lines.ContainsKey(categoryNumber))
								lines.Add(categoryNumber, new Dictionary<int, string>());

							if (lines[categoryNumber].ContainsKey(lineNumber))
								lines[categoryNumber][lineNumber] = attributes[key];
							else
								lines[categoryNumber].Add(lineNumber, attributes[key]);
						}
			}
			if (lines.ContainsKey(category))
				return lines[category];
			return new Dictionary<int,string>();
		}
	}
}
