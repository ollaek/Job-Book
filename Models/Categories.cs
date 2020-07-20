using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Book.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName  { get; set; }

        [Required]
        public string categoryDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}