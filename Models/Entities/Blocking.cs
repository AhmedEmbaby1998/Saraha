using System.Collections.Generic;

namespace SimpleSaraha.Models.Entities
{
    public class Blocking
    {
        public Blocking()
        {
            BlockCauses=new List<BlockCause>();
        }
        public int Id { set; get; }
        public int BlockerId { set; get; }
        public int BlockedId { set; get; }
        public User Blocked { set; get; }
        public User Blocker { set; get; }
        public IList<BlockCause>  BlockCauses { set; get; }
    }
}