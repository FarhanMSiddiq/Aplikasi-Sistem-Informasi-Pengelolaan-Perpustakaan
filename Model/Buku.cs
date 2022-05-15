using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Pengelolaan_Perpustakaan.Model
{
    class Buku
    {
        string idBuku, judulBuku, kategoriBuku, hlmBuku, penerbitBuku, penulisBuku, isbnBuku;

        public Buku(string idBuku, string judulBuku, string kategoriBuku, string hlmBuku, string penerbitBuku, string penulisBuku, string isbnBuku)
        {
            this.IdBuku = idBuku;
            this.JudulBuku = judulBuku;
            this.KategoriBuku = kategoriBuku;
            this.HlmBuku = hlmBuku;
            this.PenerbitBuku = penerbitBuku;
            this.PenulisBuku = penulisBuku;
            this.IsbnBuku = isbnBuku;
        }

        public string IdBuku { get => idBuku; set => idBuku = value; }
        public string JudulBuku { get => judulBuku; set => judulBuku = value; }
        public string KategoriBuku { get => kategoriBuku; set => kategoriBuku = value; }
        public string HlmBuku { get => hlmBuku; set => hlmBuku = value; }
        public string PenerbitBuku { get => penerbitBuku; set => penerbitBuku = value; }
        public string PenulisBuku { get => penulisBuku; set => penulisBuku = value; }
        public string IsbnBuku { get => isbnBuku; set => isbnBuku = value; }
    }
}
