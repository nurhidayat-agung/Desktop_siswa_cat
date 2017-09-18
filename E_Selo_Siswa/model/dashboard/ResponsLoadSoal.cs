using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Selo_Siswa.model.dashboard
{
    public class ResponsLoadSoal
    {
        public int status { get; set; }
        public List<ButirSoal> pilgan { get; set; }
        public List<ButirSoal> essay { get; set; }
    }
}
