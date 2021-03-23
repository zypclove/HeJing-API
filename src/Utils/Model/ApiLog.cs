using System;

namespace UltraNuke.CommonMormon.Utils.Model
{
    public class ApiLog
    {
        public DateTime ExecuteTime;
        public string Method;
        public string Scheme;
        public string Host;
        public string Path;
        public string Query;
        public string RequestBody;
        public string ResponseBody;
        public string ExecuteUser;
        public string ExecuteIp;
        public long ExecuteDuration;
        public string Msg;
    }
}
