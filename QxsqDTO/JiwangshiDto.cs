using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QxsqDTO
{
    public class JiwangshiDto
    {
        public int JiwangshiId {get;set;}
        public int JiwangshiUserId {get;set;}
        public string JiwangshiClass { get; set; }
        public string JiwangshiName { get; set; }
        public DateTime JiwangshiTime {get;set;}

        public string JiwangshiJibingClass { get; set; }

    }
}
