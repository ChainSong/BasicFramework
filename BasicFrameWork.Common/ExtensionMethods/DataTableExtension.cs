using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace BasicFramework.Common
{
    public static class DataTableExtension
    {
        public static T ConvertToEntity<T>(this DataTable dt) where T : new()
        {
            IEnumerable<T> entities = dt.ConvertToEntityCollection<T>();
            return entities.FirstOrDefault();
        }

        public static IEnumerable<T> ConvertToEntityCollection<T>(this DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return Enumerable.Empty<T>();
            }

            IList<T> entities = new List<T>();

            IEnumerable<PropertyInfo> properties = typeof(T).GetProperties();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T entity = new T();

                foreach (PropertyInfo property in properties)
                {
                    var attributes = property.GetCustomAttributes(typeof(EntityPropertyExtensionAttribute), false);

                    if (attributes != null && attributes.Any())
                    {
                        EntityPropertyExtensionAttribute attribute = (EntityPropertyExtensionAttribute)attributes.First();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Columns[j].ColumnName == attribute.DBTableColumnName)
                            {
                                property.SetValue(entity, dt.Rows[i][j].ConvertSimpleType(property.PropertyType), null);
                                break;
                            }
                        }
                    }
                }

                entities.Add(entity);
            }

            return entities;
        }
    }
}