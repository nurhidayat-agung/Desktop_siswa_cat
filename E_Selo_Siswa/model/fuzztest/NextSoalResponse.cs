using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Selo_Siswa.model.fuzztest
{
    class NextSoalResponse
    {
        public bool status { get; set; }
        public double aMin { get; set; }
        public double aMax { get; set; }
        public double aDist { get; set; }
        public double bMin { get; set; }
        public double bMax { get; set; }
        public double bDist { get; set; }
        public double aTurun { get; set; }
        public double aNaik { get; set; }
        public double bTurun { get; set; }
        public double bNaik { get; set; }
        public double pred1 { get; set; }
        public double pred2 { get; set; }
        public double pred3 { get; set; }
        public double pred4 { get; set; }
        public double z1 { get; set; }
        public double z2 { get; set; }
        public double z3 { get; set; }
        public double z4 { get; set; }
        public double zMeans { get; set; }
        public int cluster { get; set; }
        public SoalModel soal { get; set; }
    }
}
