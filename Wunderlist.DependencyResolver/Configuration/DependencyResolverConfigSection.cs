using System.Configuration;

namespace Wunderlist.DependencyResolver.Configuration
{
    public class DependencyResolverConfigSection: ConfigurationSection
    {
        [ConfigurationProperty("Resolver")]
        public DependencyElementCollection DependencyItems
        {
            get { return ((DependencyElementCollection)(base["Resolver"])); }
        }
    }
}
