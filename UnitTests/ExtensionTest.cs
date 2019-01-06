using Microsoft.VisualStudio.TestTools.UnitTesting;
using Searcher.Extensions;
using System;

namespace UnitTests
{
	[TestClass]
	public class ExtensionTest
	{
		[TestMethod]
		public void IntToJson_FromJson_Equals()
		{
			var intobj = 5;

			var tojson = intobj.ToJson();
			var fromjson = tojson.FromJson<int>();

			Assert.AreEqual(intobj, fromjson);
		}

		[TestMethod]
		public void StringToJson_FromJson_Equals()
		{
			var stringobj = "123";

			var tojson = stringobj.ToJson();
			var fromjson = tojson.FromJson<string>();

			Assert.AreEqual(stringobj, fromjson);
		}

		[TestMethod]
		public void DateToJson_FromJson_Equals()
		{
			var dateobj = DateTime.Now;

			var tojson = dateobj.ToJson();
			var fromjson = tojson.FromJson<DateTime>();

			Assert.AreEqual(dateobj, fromjson);
		}
	}
}
