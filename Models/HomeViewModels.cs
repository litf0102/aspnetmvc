using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace aspnetmvc2.Models
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "検索条件１")]
        public string complete { get; set; }
        [Required]
        [Display(Name = "検索条件２")]
        public string somevalue { get; set; }
    }
}