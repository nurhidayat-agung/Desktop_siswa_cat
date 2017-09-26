using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using E_Selo_Siswa.model.general;
using E_Selo_Siswa.ui;
using E_Selo_Siswa.model.angkatan;
using E_Selo_Siswa.model.kompi;
using E_Selo_Siswa.model.pleton;
using System.Diagnostics;

namespace E_Selo_Siswa.ui
{
    public partial class Login : ParrentForm
    {
        private List<AngkatanModel> listAngkatan = new List<AngkatanModel>();
        private List<KompiModel> listKompi = new List<KompiModel>();
        private List<PletonModel> listPleton = new List<PletonModel>();
        //private IRestResponse<List<AngkatanModel>> resAngkatan;
        //private IRestResponse<List<KompiModel>> resKompi;
        //private IRestResponse<List<PletonModel>> resPleton;
        private IRestResponse<ResponGeneral> resLogin;
        private bool isPleton = false;
        private bool isKompi = false;
        private bool isAngkatan = false;

        public Login()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            var client = new RestClient(RootUrl.rootUrl);
            IRestRequest reqAngkatan = new RestRequest("/php/angkatan/loadAngkatan.php", Method.GET);
            //resAngkatan = client.Execute<List<AngkatanModel>>(reqAngkatan);
            client.ExecuteAsync(reqAngkatan, resAngkatan => {
                listAngkatan = JsonConvert.DeserializeObject<List<AngkatanModel>>(resAngkatan.Content);
                Debug.WriteLine("result angkatan : " + listAngkatan.Count);
                isAngkatan = true;
            });                      
            IRestRequest reqKompi = new RestRequest("/php/kompi/loadKompi.php", Method.GET);
            //resKompi = client.Execute<List<KompiModel>>(reqKompi);
            client.ExecuteAsync(reqKompi, resKompi => {
                listKompi = JsonConvert.DeserializeObject<List<KompiModel>>(resKompi.Content);
                Debug.WriteLine("result kompi : " + listKompi.Count);
                isKompi = true;
            });            
            IRestRequest reqPleton = new RestRequest("/php/pleton/loadPleton.php", Method.GET);
            //resPleton = client.Execute<List<PletonModel>>(reqPleton);
            client.ExecuteAsync(reqPleton, resPleton => {
                listPleton = JsonConvert.DeserializeObject<List<PletonModel>>(resPleton.Content);
                Debug.WriteLine("result pleton : " + listPleton.Count);
                isPleton = true;
                if (btn_login.InvokeRequired)
                {
                    btn_login.Invoke(
                       (Action)delegate
                       {
                           btn_login.Enabled = true;
                       }
                    );
                }
                if (btn_register.InvokeRequired)
                {
                    btn_register.Invoke(
                       (Action)delegate
                       {
                           btn_register.Enabled = true;
                       }
                    );
                }
                if (abx1.InvokeRequired)
                {
                    abx1.Invoke(
                       (Action)delegate
                       {
                           abx1.Visible = false;
                       }
                    );
                }
            });
                                               
        }

        private void tb_nis_Enter(object sender, EventArgs e)
        {
            if (tb_nis.Text.Equals("Masukan NIS"))
            {
                tb_nis.Text = "";
            }
        }

        private void tb_nis_Leave(object sender, EventArgs e)
        {
            if (tb_nis.Text.Trim().Equals("")) {
                tb_nis.Text = "Masukan NIS";
            }
        }

        private void tb_pass_Enter(object sender, EventArgs e)
        {
            if (tb_pass.Text.Equals("lalila"))
            {
                tb_pass.Text = "";
            }
        }

        private void tb_pass_Leave(object sender, EventArgs e)
        {
            if (tb_pass.Text.Trim().Equals(""))
            {
                tb_pass.Text = "lalila";
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (isPleton && isKompi && isAngkatan)
            {
                btn_login.Enabled = false;
                abx1.Visible = true;
                var client = new RestClient(RootUrl.rootUrl);
                IRestRequest reqLogin = new RestRequest("/php/desktopSiswa/desktopLogin.php", Method.POST);
                reqLogin.AddJsonBody(new
                {
                    nis = tb_nis.Text,
                    password = tb_pass.Text
                });
                resLogin = client.Execute<ResponGeneral>(reqLogin);
                ResponGeneral resp = JsonConvert.DeserializeObject<ResponGeneral>(resLogin.Content);
                if (resp.status == 1)
                {
                    Siswa siswa = resp.data;
                    btn_login.Enabled = true;
                    abx1.Visible = false;
                    SiswaDashBoard dasboard = new SiswaDashBoard(siswa, listAngkatan, listKompi, listPleton);
                    dasboard.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("login gagal");
                    btn_login.Enabled = true;
                    abx1.Visible = false;
                }
            }
            else {
                abx1.Visible = true;
            }
            
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (isPleton && isKompi && isAngkatan)
            {
                Registrasion reg = new Registrasion(listAngkatan, listPleton, listKompi);
                reg.Show();
            }
            else {
                abx1.Visible = true;
            }
            
        }
    }
}
