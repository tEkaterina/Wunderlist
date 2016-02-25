using System;
using System.Collections.Generic;
using System.Reflection;

namespace BLL.Mapper.MapRules
{
    public static class Mapper
    {
        private static readonly List<MapRule> Rules = new List<MapRule>();

        public static void AddRule<TFirst, TSecond>()
            where TFirst : class
            where TSecond : class
        {
            AddRule<TFirst, TSecond>(null, null);
        }

        public static void AddRule<TFirst, TSecond>(Action<TFirst, TSecond> firstToSecond)
            where TFirst : class
            where TSecond : class
        {
            AddRule(firstToSecond, null);
        }

        public static void AddRule<TFirst, TSecond>(Action<TFirst, TSecond> firstToSecond,
            Action<TSecond, TFirst> secondToFirst)
            where TFirst : class
            where TSecond : class
        {
            MapRule<TFirst, TSecond> rule = FindRule<TFirst, TSecond>();
            if (rule == null)
            {
                Rules.Add(new MapRule<TFirst, TSecond>(firstToSecond));
                Rules.Add(new MapRule<TSecond, TFirst>(secondToFirst));
            }
            else
            {
                rule.Map = firstToSecond;
            }
        }

        public static TTarget Map<TSource, TTarget>(TSource source)
            where TTarget : class, new()
        {
            var target = (TTarget)typeof(TTarget).GetConstructor(new Type[0]).Invoke(null);
            Map(source, target);
            return target;
        }

        public static void Map<TSource, TTarget>(TSource source, TTarget target)
            where TTarget : class
        {
            if (source == null) throw new ArgumentNullException("source");

            var rule = FindRule<TSource, TTarget>();
            if (rule != null)
            {
                FillSameProperties(source, target);
                rule.Map(source, target);
            }
            else
                throw new ArgumentException("Mapping rule for specified types doesn't exist");
        }

        private static void FillSameProperties<TSource, TTarget>(TSource source, TTarget target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (target == null) throw new ArgumentNullException(nameof(target));

            Type sourceType = typeof(TSource);
            Type targetType = typeof(TTarget);

            foreach (var targetProperty in targetType.GetProperties())
            {
                if (targetProperty.CanWrite)
                {
                    PropertyInfo sourceProperty = sourceType.GetProperty(
                        targetProperty.Name, targetProperty.PropertyType, new Type[0]);
                    if (sourceProperty != null && sourceProperty.CanRead)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source));
                    }
                }
            }
        }

        private static MapRule<TFirst, TSecond> FindRule<TFirst, TSecond>()
        {
            for (int i = 0; i < Rules.Count; i++)
            {
                var rule = Rules[i] as MapRule<TFirst, TSecond>;
                if (rule != null)
                {
                    return rule;
                }
            }
            return null;
        }
    }
}