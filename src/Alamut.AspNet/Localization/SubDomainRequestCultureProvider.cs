//using System;
//using System.Threading.Tasks;
//using Alamut.AspNet.Http;
//using Microsoft.AspNetCore.Http;

//namespace Alamut.AspNet.Localization
//{
//    /// <summary>
//    /// provide culture result by subdomain
//    /// subdomain should contain en, fa, .. 
//    /// otherwise set default culture
//    /// </summary>
//    public class SubDomainRequestCultureProvider : RequestCultureProvider
//    {
//        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
//        {
//            if (httpContext == null)
//                throw new ArgumentNullException(nameof(httpContext));

//            var subdomain = UrlHelper.GetSubDomain(httpContext);
//            var culture = GetValidCulture(subdomain);
//            return culture == null
//                ? Task.FromResult<ProviderCultureResult>((ProviderCultureResult)null)
//                : Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(culture));
//        }

//        /// <summary>
//        /// validate culture
//        /// </summary>
//        /// <param name="language"></param>
//        /// <returns>if culture is valid return it, otherwise return false</returns>
//        private static string GetValidCulture(string language)
//        {
//            switch (language)
//            {
//                case "en":
//                    return "en";
//                case "fa":
//                    return "fa";
//                case "ar":
//                    return "ar";
//                default:
//                    return null;
//            }
//        }
//    }
//}
