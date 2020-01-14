using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;


namespace Domain.Infrastructure
{
    public class PropertyCopier<TSource, TDestination> where TSource : class
        where TDestination : class
    {
        public static void Copy(TSource source, TDestination destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destinationProperty in destinationProperties)
                {

                    if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }

        private static bool TypeIsAssignableFrom(PropertyInfo sourceProperty, PropertyInfo targetProperty, TSource source)
        {
            if (sourceProperty.PropertyType == targetProperty.PropertyType) return true;

            object value = sourceProperty.GetValue(source);

            if (Nullable.GetUnderlyingType(targetProperty.PropertyType) == sourceProperty.PropertyType) return true;

            if (Nullable.GetUnderlyingType(sourceProperty.PropertyType) == targetProperty.PropertyType && value != null) return true;

            return false;
        }
    }

    public class PropertyCopier 
    {
        
        public static void Copy<T>(T source, T destination)
        {
            
            foreach (PropertyInfo property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                property.SetValue(destination, property.GetValue(source));
            }
        }

        internal static List<T> MapDataTableToClass<T>(DataTable dt) where T : IDataTable
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        var value = dr[column.ColumnName] == DBNull.Value ? default(T) : dr[column.ColumnName]; 
                        pro.SetValue(obj, value, null);
                    }                        
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
