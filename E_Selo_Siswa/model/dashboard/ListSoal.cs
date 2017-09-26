using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Selo_Siswa.model.dashboard
{
    public class ListSoal
    {
        public long idSoal { get; set; }
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
        public object rebilitasSoal { get; set; }
        public object validitasSoal { get; set; }
        public object tingkatKesulitanSoal { get; set; }
        public object dayaBeda { get; set; }
        public object kesalahan_pengukuran { get; set; }
        public object cluster { get; set; }
        public int bobot { get; set; }

        public int crosscek { get; set; } = 0;
    }
}
