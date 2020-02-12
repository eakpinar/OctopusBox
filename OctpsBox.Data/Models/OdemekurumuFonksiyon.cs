using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class OdemekurumuFonksiyon
    {
        public long Id { get; set; }
        public long? OdemeKurumuId { get; set; }
        public long? FonksiyonId { get; set; }

        public virtual Fonksiyon Fonksiyon { get; set; }
        public virtual OdemeKurumu OdemeKurumu { get; set; }
    }
}
