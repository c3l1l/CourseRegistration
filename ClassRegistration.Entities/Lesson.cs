using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegistration.Entities
{
    public class Lesson
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public byte Credit { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
    }
}
