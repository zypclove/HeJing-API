using System.ComponentModel.DataAnnotations.Schema;

namespace UltraNuke.CommonMormon.DDD
{
    public abstract class AggregateRoot : Entity
    {
        #region IAggregateRoot Members
        [NotMapped]
        public AggregateState AggregateState { set; get; }
        #endregion
    }
}
