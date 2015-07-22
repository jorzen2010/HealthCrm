using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QxsqDTO
{
    public class DoctorDto
    {
        public int DoctorId {get;set;}
        public string DoctorUserName {get;set;}
        public string DoctorPassword {get;set;}
        public string DoctorRealName { get; set; }
        public DateTime DoctorRegTime {get;set;}

    }
}
