using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class SavedataPc
    {
        public string Id { get; set; }
        public string FromPath { get; set; }
        public string ToPath { get; set; }
        public string BackUpMode { get; set; }
        public string LastSaved { get; set; }

        public virtual Videogame IdNavigation { get; set; }
    }
}
