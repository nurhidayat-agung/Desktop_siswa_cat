using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Selo_Siswa.model.general
{
    public class Siswa
    {
        public Int64 nis { get; set; }
        public string namaSiswa { get; set; }
        public string password { get; set; }
        public int idAngkatan { get; set; }
        public int idPleton { get; set; }
        public int idKompi { get; set; }
        public string namaKompi { get; set; }
        public string keterangan { get; set; }
        public string namaPleton { get; set; }
        public string namaAngkatan { get; set; }
        public string deskripsiAngkatan { get; set; }
    }
}
