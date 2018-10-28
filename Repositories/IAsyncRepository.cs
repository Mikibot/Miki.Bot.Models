using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
	public interface IAsyncRepository<T> : IAsyncReadOnlyRepository<T>
	{
		Task AddAsync(T entity);

		Task EditAsync(T entity);

		Task DeleteAsync(T entity);
	}

	public interface IAsyncReadOnlyRepository<T>
	{
		Task<int> CountAsync();

		Task<T> GetAsync(params object[] id);
	}
}