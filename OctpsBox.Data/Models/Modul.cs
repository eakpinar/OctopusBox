using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class Modul
    {
        public Modul()
        {
            Fonksiyon = new HashSet<Fonksiyon>();
            OdemekurumuBaglanti = new HashSet<OdemekurumuBaglanti>();
        }

        public long Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<Fonksiyon> Fonksiyon { get; set; }
        public virtual ICollection<OdemekurumuBaglanti> OdemekurumuBaglanti { get; set; }
    }
}
