using System.Collections.Generic;

namespace SimpleSaraha.Models.Entities
{
    public class BlockCause
    {
        public int Id { get; set; }

        public int  ReasonId { set; get; }
        
        public int? BlockingId { set; get; }
        
        public Blocking Blocking { set; get; }
        
        public BlockReason BlockReason { set; get; }
        
    }
}