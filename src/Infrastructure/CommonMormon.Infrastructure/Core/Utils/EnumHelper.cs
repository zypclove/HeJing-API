using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace CommonMormon.Infrastructure.Core.Utils;

/// <summary>
/// 
/// </summary>
public static class EnumHelper
{
    /// <summary>
    /// 传入枚举类型返回枚举键值对集合(key:枚举值，value:枚举Description内容)
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static List<KeyValuePair<int, string>> GetEnums(Type type)
    {
        List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();
        FieldInfo[] fields = type.GetFields();
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType.IsEnum)
            {
                object[] attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                string description = attr.Length == 0 ? field.Name : ((DescriptionAttribute)attr[0]).Description;
                result.Add(new KeyValuePair<int, string>(Convert.ToInt32(field.GetValue(null)), description));
            }
        }
        return result;
    }
}
