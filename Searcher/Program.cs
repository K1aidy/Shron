using Autofac;
using Searcher.Abstractions;
using Searcher.Api;
using System;

namespace Seracher
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			var container = builder.ConfigureContainer();

			var manager = container.Resolve<ISearchManager>();

			manager.Start();

			var IsCanceling = false;

			while (!IsCanceling)
			{
				var key = Console.ReadKey();
				if (key.Key == ConsoleKey.Q)
				{
					manager.Stop();
					IsCanceling = !IsCanceling;
				}
			}
		}
	}
}
