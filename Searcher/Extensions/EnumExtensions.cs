using System;
using System.ComponentModel;

namespace Searcher.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDesc(this Enum source)
		{
			var type = source.GetType();
			var name = Enum.GetName(type, source);
			if (name != null)
			{
				var field = type.GetField(name);
				if (field != null)
				{
					var attr = Attribute.GetCustomAttribute(
							field,
							typeof(DescriptionAttribute)) 
						as DescriptionAttribute;

					if (attr != null)
					{
						return attr.Description;
					}
				}
			}
			return null;
		}
	}
}
