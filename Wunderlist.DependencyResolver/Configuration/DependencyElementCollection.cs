using System.Configuration;

namespace Wunderlist.DependencyResolver.Configuration
{
    [ConfigurationCollection(typeof(DependencyConfigElement), AddItemName = "Dependency")]
    public class DependencyElementCollection: ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DependencyConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DependencyConfigElement) (element)).SourceType;
        }
        
        public DependencyConfigElement this[int id]
        {
            get { return (DependencyConfigElement)BaseGet(id); }
        }
    }
}
