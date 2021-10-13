using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Emulator
    {
        public string Name { get; set; }
        public string Console { get; set; }

        public virtual SavedataEmulator SavedataEmulator { get; set; }
    }
}
