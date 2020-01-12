namespace Miki.Bot.Models.Models.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Paginated interface to abstractify paged queries.
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    public interface IPaginated<T>
        where T : class
    {
        int PageIndex { get; }
        IReadOnlyList<T> Items { get; }
        int PageCount { get; }

        Task<IPaginated<T>> GetNextPageAsync();
        Task<IPaginated<T>> GetPreviousPageAsync();

    }

}
