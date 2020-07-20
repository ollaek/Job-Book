using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Book.Models
{
    public class Job
    {
        public int id { get; set; }
       
        
        public string JobTitle { get; set; }
        public  string JobContent { get; set; }
        
        
       
        public string JobImage { get; set; }

        public string CategoryId { get; set; }
        
        public string  UserId { get; set; }

        public virtual Categories Categories { get; set; }
        public virtual ICollection<ApplyforJob> ApplyJobs { get; set; }

        public virtual ApplicationUser User { get; set; } 

    }
}