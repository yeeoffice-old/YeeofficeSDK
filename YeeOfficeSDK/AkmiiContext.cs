using System;
using YeeOfficeSDK.Interfaces;
using YeeOfficeSDK.Repository;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK
{
	public class AkmiiContext
	{
		internal string DomainUrl { get; set; }
		internal string AkmiiSecret { get; set; }
		public IAkmiiRepository Repository { get; set; }
		public static AkmiiContext GetAkmiiContext(string domainUrl, string akmiiSecret)
		{
			HttpHelper.SetSecurityProtocol();
			var context = new AkmiiContext
			{
				DomainUrl = domainUrl,
				AkmiiSecret = akmiiSecret
			};
			if (string.IsNullOrWhiteSpace(context.DomainUrl))
			{
				throw new Exception("domain url is null");
			}
			if (string.IsNullOrWhiteSpace(context.AkmiiSecret))
			{
				throw new Exception("akmiiSecret url is null");
			}
			if (!context.DomainUrl.ToLower().StartsWith("http"))
			{
				throw new Exception("domain url is invalid");
			}

			var repository = new AkmiiRepository(context);
			context.Repository = repository;
			return context;
		}
		public static AkmiiContext GetAkmiiContext(string domainUrl)
		{
			return GetAkmiiContext(domainUrl, AkmiiConstants.GetAkmiiSecret());
		}
	}
}
