using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyScannerReader
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new SkyScannerReader();

			var list = client.GetFlights();

			var result = String.Join(Environment.NewLine, list);

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
