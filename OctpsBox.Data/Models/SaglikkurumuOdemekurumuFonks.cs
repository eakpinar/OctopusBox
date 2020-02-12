using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class SaglikkurumuOdemekurumuFonks
    {
        public long Id { get; set; }
        public long? SaglikKurumuId { get; set; }
        public long? OdemeKurumuId { get; set; }
        public long? FonksiyonId { get; set; }

        public virtual Fonksiyon Fonksiyon { get; set; }
        public virtual OdemeKurumu OdemeKurumu { get; set; }
        public virtual SaglikKurumu SaglikKurumu { get; set; }
    }
}
