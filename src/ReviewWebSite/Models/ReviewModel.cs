using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReviewWebSite.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }

        private DateTime _insDate = DateTime.Now;

        public DateTime DateTime
        {
            get { return _insDate; }
            set { _insDate = value; }
        }

        //public DateTime DateTime { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        public string Rating { get; set; }
    }

}

