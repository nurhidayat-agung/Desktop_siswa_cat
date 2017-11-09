using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Selo_Siswa.model.fuzztest
{
    class SoalModel
    {
        public int idSoal { get; set; }
        public int idBankSoal { get; set; }
        public string isiSoal { get; set; }
        public string jenisSoal { get; set; }
        public string pil1 { get; set; }
        public string pil2 { get; set; }
        public string pil3 { get; set; }
        public string pil4 { get; set; }
        public string pil5 { get; set; }
        public string kunci { get; set; }
        public int jumlahEsay { get; set; }
        public double tingkatKesulitanSoal { get; set; }
        public double dayaBeda { get; set; }
        public int cluster { get; set; }
        public int bobot { get; set; }
    }
}
