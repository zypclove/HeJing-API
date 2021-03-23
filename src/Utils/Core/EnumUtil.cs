using System;
using System.Collections.Generic;

namespace UltraNuke.CommonMormon.Utils.Core
{
    public class EnumUtil
    {
        public static List<object> GetEnums<T>()
        {
            var list = new List<object>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                list.Add(new { Value = item, Name = Enum.GetName(typeof(T), item) });
            }
            return list;
        }

    }
}
