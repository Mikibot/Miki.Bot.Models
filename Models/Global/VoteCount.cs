namespace Miki.Bot.Models
{
	public struct VoteCount
	{
		public int Downvotes { get; }
		public int Upvotes { get; }

		public VoteCount(int upvotes, int downvotes)
		{
			Upvotes = upvotes;
			Downvotes = downvotes;
		}
	}
}