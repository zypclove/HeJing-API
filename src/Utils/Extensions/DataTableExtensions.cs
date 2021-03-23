using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace UltraNuke.CommonMormon.Utils.Extensions
{
    public static class DataTableExtensions
    {
        public static T ToEntity<T>(this DataTable dt) where T : new()
        {
            var entities = dt.ToCollection<T>();
            return entities.FirstOrDefault();
        }

        public static IEnumerable<T> ToCollection<T>(this DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return Enumerable.Empty<T>();
            }

            var list = new List<T>();
            // 获得此模型的类型 
            foreach (DataRow dr in dt.Rows)
            {
                var t = new T();
                var properties = t.GetType().GetProperties();
                foreach (var pi in properties)
                {
                    var tempName = pi.Name;
                    //检查DataTable是否包含此列（列名==对象的属性名）     
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter   
                        if (!pi.CanWrite) { continue; }

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
}
