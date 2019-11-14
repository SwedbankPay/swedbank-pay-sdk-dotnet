using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwedbankPay.Sdk
{
    internal static class TypeExtensions
    {
        public static List<TFieldType> GetFieldsOfType<TFieldType>(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Where(p => type.IsAssignableFrom(p.PropertyType))
                .Select(pi => (TFieldType)pi.GetValue(null))
                .ToList();
            //return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy) //TODO can be used if C#8.0
            //    .Where(p => type.IsAssignableFrom(p.FieldType))
            //    .Select(pi => (TFieldType)pi.GetValue(null))
            //    .ToList();
        }
    }
}