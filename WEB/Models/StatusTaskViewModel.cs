using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class StatusTaskViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}