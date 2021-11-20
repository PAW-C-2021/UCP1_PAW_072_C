using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Buku
    {
        public Buku()
        {
            Pinjamen = new HashSet<Pinjaman>();
        }

        public int IdBuku { get; set; }
        public string JudulBuku { get; set; }
        public string Harga { get; set; }
        public string Deskripsi { get; set; }
        public int? IdKategori { get; set; }
        public string GambarBuku { get; set; }

        public virtual Kategori IdKategoriNavigation { get; set; }
        public virtual ICollection<Pinjaman> Pinjamen { get; set; }
    }
}
