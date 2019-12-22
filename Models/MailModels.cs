using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

     public class MailModels
    {
        public string Fullname { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

    }
}

