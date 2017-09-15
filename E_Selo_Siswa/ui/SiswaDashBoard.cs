using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Selo_Siswa.model.angkatan;
using E_Selo_Siswa.model.general;
using E_Selo_Siswa.model.kompi;
using E_Selo_Siswa.model.pleton;

namespace E_Selo_Siswa.ui
{
    public partial class SiswaDashBoard : Form
    {
        private List<AngkatanModel> listAngkatan;
        private List<KompiModel> listKompi;
        private List<PletonModel> listPleton;
        private Siswa siswa;

        public SiswaDashBoard()
        {
            InitializeComponent();
        }

        public SiswaDashBoard(Siswa siswa, List<AngkatanModel> listAngkatan, List<KompiModel> listKompi, List<PletonModel> listPleton)
        {
            this.siswa = siswa;
            this.listAngkatan = listAngkatan;
            this.listKompi = listKompi;
            this.listPleton = listPleton;
            InitializeComponent();
            loadProfile();
        }

        private void loadProfile()
        {
            tbxNIS.Text = siswa.nis.ToString();
            int index = 0;
            for (int a = 0; a < listPleton.Count;a ++) {
                cbxPleton.Items.Add(listPleton[a].namaPleton);
                if (siswa.idPleton == listPleton[a].idPleton) {
                    index = a;
                }
            }
            cbxPleton.SelectedIndex = index;
            for (int a = 0; a < listKompi.Count; a++)
            {
                cbxKompi.Items.Add(listKompi[a].namaKompi);
                if (siswa.idKompi == listKompi[a].idKompi)
                {
                    index = a;
                }
            }
            cbxKompi.SelectedIndex = index;
            for (int a = 0; a < listAngkatan.Count; a++)
            {
                cbxAngkatan.Items.Add(listAngkatan[a].namaAngkatan);
                if (siswa.idAngkatan == listAngkatan[a].idAngkatan)
                {
                    index = a;
                }
            }
            cbxAngkatan.SelectedIndex = index;
            tbx_nama.Text = siswa.namaSiswa;
            tbx_pass.Text = siswa.password;

        }
    }
}
