
using Microsoft.Extensions.Configuration;

namespace FistAPI.DbModels
{
    public class Settings
    {
        public string ConnectionString;
        public string Database;
        public IConfigurationRoot iConfigurationRoot;
    }
}
