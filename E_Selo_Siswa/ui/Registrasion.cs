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
using E_Selo_Siswa.model.kompi;
using E_Selo_Siswa.model.pleton;
using E_Selo_Siswa.model.general;
using Newtonsoft.Json;
using System.Diagnostics;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace E_Selo_Siswa.ui
{
    public partial class Registrasion : ParrentForm
    {
        private List<AngkatanModel> listAngkatan = new List<AngkatanModel>();
        private List<KompiModel> listKompi = new List<KompiModel>();
        private List<PletonModel> listPleton = new List<PletonModel>();
        private IRestResponse<ResponGeneral> resReg;
        private IRestResponse<ResponGeneral> resNis;

        private void loadData()
        {
            for (int a = 0; a < listAngkatan.Count; a++)
            {
                cbxAngkatan.Items.Add(listAngkatan[a].namaAngkatan);
            }
            for (int a = 0; a < listKompi.Count; a++)
            {
                cbxKompi.Items.Add(listKompi[a].namaKompi);
            }
            for (int a = 0; a < listPleton.Count; a++)
            {
                cbxPleton.Items.Add(listPleton[a].namaPleton);
            }
        }

        public Registrasion()
        {
            InitializeComponent();
            loadData();
        }

        public Registrasion(List<AngkatanModel> listAngkatan, List<PletonModel> listPleton, List<KompiModel> listKompi)
        {
            this.listAngkatan = listAngkatan;
            this.listPleton = listPleton;
            this.listKompi = listKompi;
            InitializeComponent();
            loadData();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbx_reg_Click(object sender, EventArgs e)
        {

            if (cbxAngkatan.SelectedIndex < 0 || cbxKompi.SelectedIndex < 0 || cbxPleton.SelectedIndex < 0)
            {
                abx1.Visible = true;
            }
            else {
                DialogResult result = MessageBox.Show("Apa semua data sudah di isi dengan benar", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //...
                    btn_reg.Enabled = false;
                    abx2.Visible = true;
                    var client = new RestClient(RootUrl.rootUrl);
                    IRestRequest reqReg = new RestRequest("/php/desktopSiswa/pushSiswa.php", Method.POST);
                    reqReg.AddJsonBody(new
                    {
                        nis = tbxNis.Text,
                        namaSiswa = tbx_nama.Text,
                        password = tbx_pass.Text,
                        idAngkatan = listAngkatan[cbxAngkatan.SelectedIndex].idAngkatan,
                        idKompi = listKompi[cbxKompi.SelectedIndex].idKompi,
                        idPleton = listPleton[cbxPleton.SelectedIndex].idPleton
                    });
                    resReg = client.Execute<ResponGeneral>(reqReg);
                    ResponGeneral resp = JsonConvert.DeserializeObject<ResponGeneral>(resReg.Content);
                    if (resp.status == 1)
                    {
                        abx3.Visible = true;
                        abx2.Visible = false;
                        tbxNis.Text = "";
                        tbx_nama.Text = "";
                        tbx_pass.Text = "";
                        btn_reg.Enabled = false;
                    }
                    else {
                        abx2.Visible = false;
                        abx4.Visible = true;
                    }
                    btn_reg.Enabled = true;
                }
                else if (result == DialogResult.No)
                {
                    //...
                    
                }
                else
                {
                    //...
                }
                
            }
        }

        private void flatAlertBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbxNis_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void btnCek_Click(object sender, EventArgs e)
        {
            btnCek.Enabled = false;
            if (tbxNis.Text != "")
            {
                var client = new RestClient(RootUrl.rootUrl);
                IRestRequest reqNis = new RestRequest("/php/desktopSiswa/cekNis.php", Method.POST);
                reqNis.AddJsonBody(new
                {
                    nis = tbxNis.Text
                });
                resNis = client.Execute<ResponGeneral>(reqNis);
                ResponGeneral resp = JsonConvert.DeserializeObject<ResponGeneral>(resNis.Content);
                if (resp.status == 1)
                {
                    MessageBox.Show("nis tersedia");
                    btn_reg.Enabled = true;
                    btnCek.Enabled = true;
                }
                else {
                    MessageBox.Show("nis sudah dipakai");
                    btn_reg.Enabled = false;
                    btnCek.Enabled = true;
                }
            }
            else {
                abx5.Visible = true;
                btnCek.Enabled = true;
            }
        }
    }
}
