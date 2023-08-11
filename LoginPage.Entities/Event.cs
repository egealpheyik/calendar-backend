using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginPage.Entities
{
    [Table("Events")]
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public int UserId { get; set; }
        [StringLength(30)]
        public string EventName { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public byte Importance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Time { get; set; }
        public bool AutoFinish { get; set; }
        public bool IsFinished { get; set; }
    }
}
