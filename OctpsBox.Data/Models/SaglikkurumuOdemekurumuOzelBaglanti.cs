using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class SaglikkurumuOdemekurumuOzelBaglanti
    {
        public long Id { get; set; }
        public long? SaglikKurumuId { get; set; }
        public long? OdemekurumuBaglantiId { get; set; }
        public string SaglikKurumuKodu { get; set; }
        public string SaglikKurumuSifre { get; set; }

        public virtual OdemekurumuBaglanti OdemekurumuBaglanti { get; set; }
        public virtual SaglikKurumu SaglikKurumu { get; set; }
    }
}
