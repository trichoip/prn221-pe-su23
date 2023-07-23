using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Account
    {
        public Account()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string AccountId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int AccoutRole { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
