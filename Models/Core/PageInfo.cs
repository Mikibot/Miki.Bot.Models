namespace Miki.Bot.Models.Models.Core
{
    /// <summary>
    /// Shows current page context helper for <see cref="IPaginated{T}"/>
    /// </summary>
    public struct PageInfo
    {
        /// <summary>
        /// Current page in context.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Total amount of pages available.
        /// </summary>
        public int PageCount { get; }

        public PageInfo(int index, int count)
        {
            PageCount = count;
            PageIndex = index;
        }
    }
}
