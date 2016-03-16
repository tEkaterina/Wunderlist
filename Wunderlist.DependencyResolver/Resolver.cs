using System;
using System.Configuration;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;
using Wunderlist.DependencyResolver.Configuration;

namespace Wunderlist.DependencyResolver
{
    public static class ResolverSettings
    {
        public static void Configure(this IKernel kernel)
        {
            ResolveByConfigFile(kernel);
        }

        private static void ResolveByConfigFile(IKernel kernel)
        {
            var section = (DependencyResolverConfigSection)ConfigurationManager.GetSection("dependencyResolver");
            if (section != null)
            {
                foreach (DependencyConfigElement dependency in section.DependencyItems)
                {
                    var sourceType = Type.GetType(dependency.SourceType);
                    var targetType = Type.GetType(dependency.TargetType);

                    if (sourceType == null)
                        throw new ConfigurationErrorsException("Convertion error for source type = " +
                                                               dependency.SourceType);
                    if (targetType == null)
                        throw new ConfigurationErrorsException("Convertion error for target type = " +
                                                               dependency.TargetType);

                    var binding = kernel.Bind(sourceType).To(targetType);
                    BindToScope(binding, dependency.InScope);
                }
            }
        }

        private static void BindToScope<T>(IBindingWhenInNamedWithOrOnSyntax<T> binding, DependencyConfigElement.Scope scope)
        {
            switch (scope)
            {
                case DependencyConfigElement.Scope.Request:
                    {
                        binding.InRequestScope();
                        break;
                    }
                case DependencyConfigElement.Scope.Singleton:
                    {
                        binding.InSingletonScope();
                        break;
                    }
                default:
                    {
                        binding.InTransientScope();
                        break;
                    }
            }
        }
    }
}
