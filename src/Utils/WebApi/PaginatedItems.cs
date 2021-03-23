using System;
using System.Collections.Generic;
using System.Text;

namespace UltraNuke.CommonMormon.Utils.WebApi
{
    public class PaginatedItems<T> where T : class
    {
        public int Total { get; private set; }

        public List<T> Items { get; private set; }

        public PaginatedItems(int total, List<T> items)
        {
            this.Total = total;
            this.Items = items;
        }
    }
}
