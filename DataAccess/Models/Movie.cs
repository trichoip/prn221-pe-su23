using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int MovieId { get; set; }

        [MinLength(10, ErrorMessage = "movie name is greate that 10 character")]
        public string MovieName { get; set; } = null!;
        public string ActorName { get; set; } = null!;
        [Range(61, 120)]
        public int Duration { get; set; }
        public string DirectorName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
