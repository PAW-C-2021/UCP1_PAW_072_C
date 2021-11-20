using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            Bukus = new HashSet<Buku>();
        }

        public int IdKategori { get; set; }
        public string NamaKategori { get; set; }

        public virtual ICollection<Buku> Bukus { get; set; }
    }
}
