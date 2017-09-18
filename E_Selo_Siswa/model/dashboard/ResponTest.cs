using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Selo_Siswa.model.dashboard
{
    public class ResponTest
    {
        public int idResponTest { get; set; }

        public long nis { get; set; }

        public int idTest { get; set; }

        public double nilaiResponTest { get; set; }

        public string jenis { get; set; }

        public string status { get; set; }

        public object rawScore { get; set; }

        public int idBankSoal { get; set; }

        public string namaTest { get; set; }

        public string jenisTest { get; set; }

        public double waktuTest { get; set; }

        public double scoreItem { get; set; }

        public int jmlPilGanda { get; set; }

        public int jmlEssay { get; set; }
    }
}
