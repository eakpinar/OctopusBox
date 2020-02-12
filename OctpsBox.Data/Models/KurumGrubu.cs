using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class KurumGrubu
    {
        public KurumGrubu()
        {
            SaglikKurumu = new HashSet<SaglikKurumu>();
        }

        public long Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<SaglikKurumu> SaglikKurumu { get; set; }
    }
}
