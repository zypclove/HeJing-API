using System;
using System.Runtime.Serialization;

namespace UltraNuke.CommonMormon.Utils.Exceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        #region Constructors
        /// <summary>
        /// 初始化。
        /// </summary>
        public UnauthorizedException()
            : base()
        {
        }

        /// <summary>
        /// 使用指定的错误消息初始化。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public UnauthorizedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化。
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        /// <param name="exception">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用</param>
        public UnauthorizedException(string message, Exception exception)
            : base(message, exception)
        {
        }

        /// <summary>
        /// 用序列化数据初始化。
        /// </summary>
        /// <param name="info">SerializationInfo，它存有有关所引发异常的序列化的对象数据。</param>
        /// <param name="context">StreamingContext，它包含有关源或目标的上下文信息。</param>
        protected UnauthorizedException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
        #endregion
    }
}
