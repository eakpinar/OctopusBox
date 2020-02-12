using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class Fonksiyon
    {
        public Fonksiyon()
        {
            OdemekurumuFonksiyon = new HashSet<OdemekurumuFonksiyon>();
            SaglikkurumuOdemekurumuFonks = new HashSet<SaglikkurumuOdemekurumuFonks>();
        }

        public long Id { get; set; }
        public string Adi { get; set; }
        public long? ModulId { get; set; }

        public virtual Modul Modul { get; set; }
        public virtual ICollection<OdemekurumuFonksiyon> OdemekurumuFonksiyon { get; set; }
        public virtual ICollection<SaglikkurumuOdemekurumuFonks> SaglikkurumuOdemekurumuFonks { get; set; }
    }
}
