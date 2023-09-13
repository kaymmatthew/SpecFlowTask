using Microsoft.Extensions.Configuration;

namespace SpecFlowTask
{
    public class readTestDataConfig
    {
        private static IConfigurationRoot? _config
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("settings.json");

                return builder.Build();
            }
        }

        public static string AutomationExerciseUrl() => new(_config?.GetSection("UserInfo:url").Value);
        public static string UserPassword() => new(_config?.GetSection("UserInfo:password").Value);
        public static string Days() => new(_config?.GetSection("UserInfo:days").Value);
        public static string Month() => new(_config?.GetSection("UserInfo:month").Value);
        public static string Year() => new(_config?.GetSection("UserInfo:year").Value);
        public static string UserFirstName() => new(_config?.GetSection("UserInfo:firstName").Value);
        public static string UserLastName() => new(_config?.GetSection("UserInfo:lastName").Value);
        public static string UserCompay() => new(_config?.GetSection("UserInfo:company").Value);
        public static string UserAddress() => new(_config?.GetSection("UserInfo:address").Value);
        public static string UserAddress2() => new(_config?.GetSection("UserInfo:address2").Value);
        public static string UserCountry() => new(_config?.GetSection("UserInfo:country").Value);
        public static string UserState() => new(_config?.GetSection("UserInfo:state").Value);
        public static string UserCity() => new(_config?.GetSection("UserInfo:city").Value);
        public static string UserZipCode() => new(_config?.GetSection("UserInfo:zipCode").Value);
        public static string UserMobile() => new(_config?.GetSection("UserInfo:mobile").Value);
    }
}