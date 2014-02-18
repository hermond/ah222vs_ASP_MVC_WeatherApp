using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage="Orten kan inte lämnas tom")]
        [DisplayName("Väderdata")]
        [StringLength(40, MinimumLength = 3, ErrorMessage="Orten måste vara minst tre tecken.")]
        public string SearchString {get; set;}

    }
}