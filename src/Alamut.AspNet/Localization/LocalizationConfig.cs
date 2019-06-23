//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using Alamut.Helpers.Localization;

//namespace Alamut.AspNet.Localization
//{
//    /// <summary>
//    /// provide localization service configuration model
//    /// </summary>
//    public class LocalizationConfig
//    {
//        public bool IsMultiLanguage { get; set; } = false;
//        public string DefaultLanguage { get; set; }
//        public Dictionary<string,string> SupportedLanguges { get; set; }

//        public IList<CultureInfo> GetSupportedCulture()
//        {
//            return this.SupportedLanguges
//                .Select(s => new CultureInfo(s.Key))
//                .ToList();
//        }

//        public string CurrentLanguage => this.IsMultiLanguage ? Language.Current : string.Empty;

//        public string CurrentLanguageTitle => this.SupportedLanguges[Language.Current];
//    }
//}