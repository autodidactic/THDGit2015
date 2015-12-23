using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace MVCAPP1.Models
{
    public class APPMAN_APPLICATION
    {
        [Key]
        public int AppId { get; set; }
        public int AppOwnerId { get; set; }
        public int DevPlatformId { get; set; }
        public int AppTypeId { get; set; }
        public int DbSchemaId { get; set; }
        public string AppDesc { get; set; }
        public Boolean Active
        {
            get; set;
        }
                 
    }
}
 