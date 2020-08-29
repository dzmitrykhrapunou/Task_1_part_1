using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        int Id { get; set; }

        public string Name { get; set; }
    }
}    

