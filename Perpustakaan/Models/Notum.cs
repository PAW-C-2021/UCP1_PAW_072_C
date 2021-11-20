using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Notum
    {
        public Notum()
        {
            Pinjamen = new HashSet<Pinjaman>();
        }

        public int IdNota { get; set; }
        public int? IdPeminjam { get; set; }
        public int? IdAdmin { get; set; }
        public DateTime? TglDeadline { get; set; }
        public DateTime? TglPinjam { get; set; }
        public DateTime? TglKembali { get; set; }
        public int? Denda { get; set; }
        public string Status { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Peminjam IdPeminjamNavigation { get; set; }
        public virtual ICollection<Pinjaman> Pinjamen { get; set; }
    }
}
