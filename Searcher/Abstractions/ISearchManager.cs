namespace Searcher.Abstractions
{
	public interface ISearchManager
	{
		/// <summary>
		/// Запуск клиента поиска
		/// </summary>
		void Start();
		/// <summary>
		/// Остановка клиента поиска
		/// </summary>
		void Stop();
	}
}
