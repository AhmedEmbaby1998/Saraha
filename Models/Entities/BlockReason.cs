using System.Collections.Generic;
using System.ComponentModel.Design;

namespace SimpleSaraha.Models.Entities
{
    public class BlockReason
    {
        public BlockReason()
        {
            BlockCauses=new List<BlockCause>();
        }
       public  int Id { set; get; }
       public string Reason { set; get; }
       public IList<BlockCause> BlockCauses { set; get; }

    }
}