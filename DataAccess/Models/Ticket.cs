using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Ticket
    {
        public string TicketId { get; set; } = null!;
        public int Amount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Slot { get; set; } = null!;
        public int MovieId { get; set; }
        public string Seat { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Movie Movie { get; set; } = null!;
    }
}
