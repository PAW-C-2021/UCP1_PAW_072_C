using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Nota = new HashSet<Notum>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }
        public string Jabatan { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Notum> Nota { get; set; }
    }
}
