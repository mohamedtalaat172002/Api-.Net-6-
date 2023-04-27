
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI2022.Model
{
    public class CreateGenreDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
