using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Kullanici = new HashSet<Kullanici>();
        }

        public long Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
