namespace Manager_Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int EventID { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [StringLength(10)]
        public string ThemeColor { get; set; }

        public bool IsFullDay { get; set; }
    }
}
