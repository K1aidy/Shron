using System.Threading;
using System.Threading.Tasks;

namespace Searcher.Abstractions
{
	public interface ISearchClient
	{
		/// <summary>
		/// Поиск
		/// </summary>
		/// <param name="cancellationToken">Токен отмены операции</param>
		Task Search(CancellationToken cancellationToken);
	}
}
