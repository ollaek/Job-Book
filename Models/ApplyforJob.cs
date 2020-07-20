using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Book.Models
{
    public class ApplyforJob
    {
        public int id { get; set; }
        public string Message { get; set; }
        public int MobilePhone  {get ; set ; }

        public DateTime ApplyDate { get; set; }

       
        public int JobId { get; set; }
        public string UserId { get; set; }

        public virtual Job Job { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}