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
using E_Selo_Siswa.model.dashboard;
using E_Selo_Siswa.ui;
using RestSharp;
using Newtonsoft.Json;
using System.Diagnostics;

namespace E_Selo_Siswa.ui
{
    public partial class SiswaDashBoard : ParrentForm
    {
        //private IRestResponse<List<TestOpen>> resTest;
        //private IRestResponse<List<ResponTest>> resRespon;
        private IRestResponse<List<ListSoal>> resLoadSoal;
        private List<AngkatanModel> listAngkatan = new List<AngkatanModel>();
        private List<KompiModel> listKompi = new List<KompiModel>();
        private List<PletonModel> listPleton = new List<PletonModel>();
        private List<TestOpen> listTest = new List<TestOpen>();
        private List<ResponTest> listRespon = new List<ResponTest>();
        private List<ListSoal> listSoal = new List<ListSoal>();
        private Siswa siswa;
        //private IRestResponse<ResponGeneral> resNis;
        //private IRestResponse<ResponGeneral> resUpdateNis;

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
            loadOpenTest();
        }

        private void loadOpenTest()
        {
            var client = new RestClient(RootUrl.rootUrl);
            IRestRequest reqTest = new RestRequest("/php/desktopSiswa/loadTestOpen.php", Method.POST);
            reqTest.AddJsonBody(new {
                nis = this.siswa.nis
            });
            client.ExecuteAsync(reqTest, resTest => {
                listTest = JsonConvert.DeserializeObject<List<TestOpen>>(resTest.Content);
                Debug.WriteLine("result Test : " + listTest.Count);
                if (listTest.Count > 0)
                {
                    if (dgvTest.InvokeRequired)
                    {
                        dgvTest.Invoke(
                           (Action)delegate
                           {
                               foreach (TestOpen test in listTest)
                               {
                                   dgvTest.Rows.Add(test.idTest, test.namaTest, test.jenisTest, test.waktuTest);
                               }
                           }
                        );
                    }
                }
                else {
                    MessageBox.Show("tidak ditemukan data test dalam data base");
                }
                if (abx2.InvokeRequired)
                {
                    abx2.Invoke(
                       (Action)delegate
                       {
                           abx2.Visible = false;
                       }
                    );
                }
            });
            IRestRequest reqRespon = new RestRequest("/php/desktopSiswa/loadResponTest.php", Method.POST);
            reqRespon.AddJsonBody(new
            {
                nis = siswa.nis
            });
            client.ExecuteAsync(reqRespon, resRespon => {
                listRespon = JsonConvert.DeserializeObject<List<ResponTest>>(resRespon.Content);
                Debug.WriteLine("result respon : " + listTest.Count);
                if (listRespon.Count > 0)
                {
                    if (dgvRespon.InvokeRequired)
                    {
                        dgvRespon.Invoke(
                           (Action)delegate
                           {
                               foreach (ResponTest respon in listRespon)
                               {
                                   dgvRespon.Rows.Add(respon.idResponTest, respon.namaTest, respon.jenisTest, respon.nilaiResponTest);
                               }
                           }
                        );
                    }
                }
                else {
                    MessageBox.Show("Tidak ditemukan respon dalam data base");
                }
                if (abx3.InvokeRequired)
                {
                    abx3.Invoke(
                       (Action)delegate
                       {
                           abx3.Visible = false;
                       }
                    );
                }
            });
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

        private void dgvTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) {
                dgvTest.Enabled = false;
                abx1.Visible = true;
                loadSoalTest(listTest[e.RowIndex]);
            }
        }

        private void loadSoalTest(TestOpen testOpen)
        {
            var client = new RestClient(RootUrl.rootUrl);
            IRestRequest reqSoal = new RestRequest("/php/desktopSiswa/loadSoalTest.php", Method.POST);
            reqSoal.AddJsonBody(new
            {
                idBankSoal = testOpen.idBankSoal,
                jmlPilGan = testOpen.jmlPilGanda,
                jmlEssay = testOpen.jmlEssay
            });
            //client.ExecuteAsync(reqSoal, resLoadSoal => {});
            resLoadSoal = client.Execute<List<ListSoal>>(reqSoal);
            listSoal = JsonConvert.DeserializeObject<List<ListSoal>>(resLoadSoal.Content);
            Debug.WriteLine("soal jumlah : " + listSoal.Count);

            if (listSoal.Count == (testOpen.jmlPilGanda + testOpen.jmlEssay))
            {
                TestSession session = new TestSession(testOpen,listSoal,siswa,listAngkatan,listKompi,listPleton);
                session.Show();
                abx1.Visible = false;
                dgvTest.Enabled = true;
                this.Close();                
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Update Profile siswa ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnUpdate.Enabled = false;
                abx4.Visible = true;
                var client = new RestClient(RootUrl.rootUrl);
                IRestRequest reqUpdate = new RestRequest("/php/desktopSiswa/editSiswa.php", Method.POST);
                reqUpdate.AddJsonBody(new
                {
                    nis = tbxNIS.Text,
                    namaSiswa = tbx_nama.Text,
                    password = tbx_pass.Text,
                    idAngkatan = listAngkatan[cbxAngkatan.SelectedIndex].idAngkatan,
                    idPleton = listPleton[cbxPleton.SelectedIndex].idPleton,
                    idKompi = listKompi[cbxKompi.SelectedIndex].idKompi
                });
                client.ExecuteAsync(reqUpdate, resUpdateNis => {
                    ResponGeneral respon = JsonConvert.DeserializeObject<ResponGeneral>(resUpdateNis.Content);
                    if (respon.status == 1)
                    {
                        MessageBox.Show("update siswa sukses");
                        if (abx4.InvokeRequired)
                        {
                            abx4.Invoke(
                               (Action)delegate
                               {
                                   abx4.Visible = false;
                               }
                            );
                        }
                        if (btnUpdate.InvokeRequired)
                        {
                            btnUpdate.Invoke(
                               (Action)delegate
                               {
                                   btnUpdate.Enabled = true;
                               }
                            );
                        } 
                    }
                    else if (respon.status == 0)
                    {
                        MessageBox.Show("update siswa gagal");
                        if (abx4.InvokeRequired)
                        {
                            abx4.Invoke(
                               (Action)delegate
                               {
                                   abx4.Visible = false;
                               }
                            );
                        }
                        if (btnUpdate.InvokeRequired)
                        {
                            btnUpdate.Invoke(
                               (Action)delegate
                               {
                                   btnUpdate.Enabled = true;
                               }
                            );
                        }
                    }
                });
            }
            else if (result == DialogResult.No)
            {

            }
            else {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listTest.Clear();
            listRespon.Clear();
            dgvTest.Rows.Clear();
            dgvRespon.Rows.Clear();
            abx2.Visible = true;
            abx3.Visible = true;
            loadOpenTest();
        }
    }
}
