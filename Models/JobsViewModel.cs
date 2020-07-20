using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Book.Models
{
    public class JobsViewModel
    {
        public string JobTitle { get; set; }
        public IEnumerable  <ApplyforJob> items { get; set; }
    }
}