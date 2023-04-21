using System.Collections.Generic;

namespace CommonMormon.Admin.Api.Dtos.Users
{
    public class Meta
    {
        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 首页
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? isLink { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? isHide { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? isFull { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? isAffix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? isKeepAlive { get; set; }
    }

    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> children { get; set; } = new List<DataItem>();
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 成功
        /// </summary>
        public string msg { get; set; }
    }
}







