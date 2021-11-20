using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Pinjaman
    {
        public int IdPinjaman { get; set; }
        public int? IdNota { get; set; }
        public int? IdBuku { get; set; }
        public int? Jumlah { get; set; }

        public virtual Buku IdBukuNavigation { get; set; }
        public virtual Notum IdNotaNavigation { get; set; }
    }
}
