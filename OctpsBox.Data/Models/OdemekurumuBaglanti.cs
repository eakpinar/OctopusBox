using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class OdemekurumuBaglanti
    {
        public OdemekurumuBaglanti()
        {
            SaglikkurumuOdemekurumuOzelBaglanti = new HashSet<SaglikkurumuOdemekurumuOzelBaglanti>();
        }

        public long Id { get; set; }
        public long? OdemeKurumuId { get; set; }
        public string BaglantiAdresi { get; set; }
        public long? ModulId { get; set; }
        public long? OrtamId { get; set; }

        public virtual Modul Modul { get; set; }
        public virtual Ortam Ortam { get; set; }
        public virtual ICollection<SaglikkurumuOdemekurumuOzelBaglanti> SaglikkurumuOdemekurumuOzelBaglanti { get; set; }
    }
}
