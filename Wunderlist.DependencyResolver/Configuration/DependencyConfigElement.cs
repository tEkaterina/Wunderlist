using System;
using System.Configuration;

namespace Wunderlist.DependencyResolver.Configuration
{
    public class DependencyConfigElement: ConfigurationElement
    {
        [ConfigurationProperty("sourceType", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string SourceType
        {
            get { return ((string)(base["sourceType"])); }
        }

        [ConfigurationProperty("targetType", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string TargetType
        {
            get { return ((string)(base["targetType"])); }
        }

        public enum Scope { Transient, Singleton, Request }

        [ConfigurationProperty("inScope", DefaultValue = Scope.Transient, IsKey = false, IsRequired = false)]
        public Scope InScope
        {
            get
            {
                return (Scope) base["inScope"];
            }
        }
    }
}
