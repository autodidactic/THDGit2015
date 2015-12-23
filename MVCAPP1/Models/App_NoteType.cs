using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAPP1.Models
{
    public class APPMAN_NOTETYPE
    {
        [Key]
        public int NOTETYPEID { get; set; }
        public string NOTETYPEDESC { get; set; }
    }
}