using System;
using Swashbuckle.Swagger;

namespace Swashbuckle.Application
{
    public class InfoBuilder
    {
        private string _version;
        private string _specialVersion;
        private string _title;
        private string _description;
        private string _termsOfService;
        private readonly ContactBuilder _contactBuilder = new ContactBuilder();
        private readonly LicenseBuilder _licenseBuilder = new LicenseBuilder();

        public InfoBuilder(string version, string title)
        {
            _version = version;
            _title = title;
        }

        public InfoBuilder Description(string description)
        {
            _description = description;
            return this;
        }

        public InfoBuilder TermsOfService(string termsOfService)
        {
            _termsOfService = termsOfService;
            return this;
        }

        public InfoBuilder Contact(Action<ContactBuilder> contact)
        {
            contact(_contactBuilder);
            return this;
        }

        public InfoBuilder License(Action<LicenseBuilder> license)
        {
            license(_licenseBuilder);
            return this;
        }

        /// <summary>
        /// 用于显示的特殊版本号格式
        /// 如：Release.2015-10-12 15:33:20
        /// </summary>
        /// <param name="specialVersion"></param>
        /// <returns></returns>
        public InfoBuilder SpecialVersionNo(string specialVersion)
        {
            _specialVersion = specialVersion;
            return this;
        }

        internal Info Build()
        {
            return new Info
            {
                version = string.IsNullOrEmpty(_specialVersion) ? _version : _specialVersion,
                title = _title,
                description = _description,
                termsOfService = _termsOfService,
                contact = _contactBuilder.Build(),
                license = _licenseBuilder.Build()
            };
        }
    }
}