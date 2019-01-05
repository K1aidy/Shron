using Newtonsoft.Json;

namespace Searcher.Extensions
{
	public static class JsonHelper
	{
		public static string ToJson(this object source) =>
			JsonConvert.SerializeObject(source);

		public static T FromJson<T>(this string source) =>
			JsonConvert.DeserializeObject<T>(source);
	}
}
