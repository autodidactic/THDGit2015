using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SendScheduledEmails.EmailDAL
{
    public class EMAILQUEUE
    {
        [Key]
        [Required]
        public int MESSAGEID { get; set; }
        public int MEASURENUMBER { get; set; }
        public int QUOTEID { get;set;}
        public DateTime SUBMITTED { get; set; }
        public string EMAILTO { get; set; }
        public int RESPONSECODE { get; set; }
        public string RESPONSETEXT { get; set; }
        public int ATTEMPTS { get; set;}
        public int EMAILTYPEID { get; set; }
        //[DefaultValue("1/1/2016 12:00:00 AM")]
        //public DateTime PROCESSED { get; set; }
        
    }
}
