using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System
{
    internal static class EnumExtensions
    {
        private static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue?.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }

        public static string GetDisplayName(this Enum enumvValue)
        {
            return enumvValue?.GetAttribute<DisplayAttribute>()?.Name ?? enumvValue?.ToString() ?? string.Empty;
        }

        public static string GetDescription(this Enum enumvValue)
        {
            return enumvValue?.GetAttribute<DescriptionAttribute>()?.Description ?? enumvValue?.ToString() ?? string.Empty;
        }

        public static string GetValidOptionsAsString<T>() where T : struct
        {
            var allOptions = Array.AsReadOnly((T[]) Enum.GetValues(typeof(T)))
                .Select(v => v.ToString());

            return string.Join(", ", allOptions);
        }

        public static ReadOnlyCollection<T> GetValidOptions<T>() where T : struct
        {
            var allOptions = Array.AsReadOnly((T[]) Enum.GetValues(typeof(T)));

            return allOptions;
        }
    }
}