using Microsoft.AspNetCore.Hosting;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Core
{
	public class CardCacheConfig
	{
		public static IHearthstoneCardCache BuildCardCache(IHostingEnvironment hostingEnvironment)
		{
			var parser = new HearthstoneCardParser();
			var factory = new LocalJsonFeedHearthstoneCardCacheFactory(parser, hostingEnvironment);
			return factory.Create();
		}
	}
}