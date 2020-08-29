using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Students")]
    public class Student
    {
        [Key]
        int Id { get; set; }

        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
               
        public int Name { get; set; }

        public int Gender { get; set; }

        public DateTime DOfB { get; set; }
    }   
}
