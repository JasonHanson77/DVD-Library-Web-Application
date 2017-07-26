using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryDBWEB.Models.Tables
{
    public class DVD
    {
        public int DVDId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Notes { get; set; }
        [Required]
        public string ReleaseYear { get; set; }
    }
}
