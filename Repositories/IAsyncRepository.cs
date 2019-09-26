using System.Threading.Tasks;

namespace Miki.Bot.Models.Repositories
{
	public interface IAsyncRepository<T> : IAsyncReadOnlyRepository<T>
	{
        ValueTask AddAsync(T entity);

        ValueTask EditAsync(T entity);

		ValueTask DeleteAsync(T entity);
	}

	public interface IAsyncReadOnlyRepository<T>
	{
        ValueTask<T> GetAsync(params object[] id);
	}
}