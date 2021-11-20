using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Peminjam
    {
        public Peminjam()
        {
            Nota = new HashSet<Notum>();
        }

        public int IdPeminjam { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Notum> Nota { get; set; }
    }
}
