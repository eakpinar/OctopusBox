using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class SaglikKurumu
    {
        public SaglikKurumu()
        {
            SaglikkurumuOdemekurumuFonks = new HashSet<SaglikkurumuOdemekurumuFonks>();
            SaglikkurumuOdemekurumuOzelBaglanti = new HashSet<SaglikkurumuOdemekurumuOzelBaglanti>();
        }

        public long Id { get; set; }
        public string Adi { get; set; }
        public string CgmSifre { get; set; }
        public long? KurumGrubuId { get; set; }

        public virtual KurumGrubu KurumGrubu { get; set; }
        public virtual ICollection<SaglikkurumuOdemekurumuFonks> SaglikkurumuOdemekurumuFonks { get; set; }
        public virtual ICollection<SaglikkurumuOdemekurumuOzelBaglanti> SaglikkurumuOdemekurumuOzelBaglanti { get; set; }
    }
}
