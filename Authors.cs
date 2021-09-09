using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADMPublishers.DataAccess
{
    [Table("Authors")]
    public class Authors
    {
        [Column("Au_Id")]
        [Key]  
        [Required]
        public string Au_Id { get; set; }

        [Column("Au_LName")]
        [Required]
        [StringLength(50)]
        public string Au_LName { get; set; }

        [Column("Au_FName")]
        [Required]
        [StringLength(50)]
        public string Au_FName { get; set; }

        [Column("Phone")]
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Column("Address")]
        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Column("City")]
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Column("State")]
        [Required]
        [StringLength(5)]
        public string State { get; set; }

        [Column("Zip")]
        [Required]
        [StringLength(6)]
        public string Zip { get; set; }

        [Column("Contract")]
        [Required]
        public int? Contract { get; set; }
    }
}
