using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Videogame
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Cover { get; set; }

        public virtual SavedataPc SavedataPc { get; set; }
    }
}
