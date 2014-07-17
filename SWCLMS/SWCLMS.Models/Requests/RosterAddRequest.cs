using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Requests
{
   public class RosterAddRequest
    {
       public int ClassId { get; set; }
       public string UserId { get; set; }
       public int RosterId { get; set; }
    }
}
