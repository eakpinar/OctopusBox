using System;
using System.Collections.Generic;

namespace OctpsBox.Data.Models
{
    public partial class Kullanici
    {
        public long Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public long? RolId { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
