using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using E_Selo_Siswa.model.angkatan;
using E_Selo_Siswa.model.dashboard;
using E_Selo_Siswa.model.fuzztest;
using E_Selo_Siswa.model.general;
using E_Selo_Siswa.model.kompi;
using E_Selo_Siswa.model.pleton;
using E_Selo_Siswa.model.serverRespon;
using Newtonsoft.Json;
using RestSharp;
using Timer = System.Timers.Timer;

namespace E_Selo_Siswa.ui
{
    public partial class TestFuzzy : ParrentForm
    {
        private TestOpen testOpen;
        private Timer t;
        private int sec;
        private double minute;
        private List<PletonModel> listPleton;
        private List<KompiModel> listKompi;
        private List<AngkatanModel> listAngkatan;
        private Siswa siswa;
        private int noTest = 0;
        private RestClient client = new RestClient(RootUrl.rootUrl);
        private List<SoalModel> listSoal = new List<SoalModel>();
        private List<int> listIdSoal = new List<int>();
        private List<String> listJenisSoal = new List<string>();
        private double[] scores;
        private Boolean isTrue = false;


        public TestFuzzy()
        {
            InitializeComponent();
        }

        private void TestFuzzy_Shown(object sender, EventArgs e)
        {
            lblNamaTest.Text = testOpen.namaTest;
            lblJenisTest.Text = testOpen.jenisTest;
            lblJmlPilgan.Text = testOpen.jmlPilGanda.ToString();
            lblJmlEssay.Text = testOpen.jmlEssay.ToString();
            lblMinute.Text = testOpen.waktuTest.ToString();
            for (int tes = 0; tes < testOpen.jmlPilGanda; tes++)
            {
                listJenisSoal.Add("Pilihan Ganda");

            }
            for (int i = 0; i < testOpen.jmlEssay; i++)
            {
                listJenisSoal.Add("Melengkapi");
            }
            scores = new double[listJenisSoal.Count];
        }

        public TestFuzzy(TestOpen testOpen, Siswa siswa, List<AngkatanModel> listAngkatan, List<KompiModel> listKompi, List<PletonModel> listPleton)
        {
            InitializeComponent();
            this.testOpen = testOpen;
            this.Shown += new System.EventHandler(this.TestFuzzy_Shown);
            loadTimerTest(testOpen);
            this.siswa = siswa;
            this.listAngkatan = listAngkatan;
            this.listKompi = listKompi;
            this.listPleton = listPleton;
        }

        private void loadTimerTest(TestOpen testOpen1)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += onTimeEvent;
            sec = 0;
            minute = testOpen.waktuTest;
            lblSec.Text = sec.ToString();
            lblMinute.Text = minute.ToString();
        }

        private void onTimeEvent(object sender, ElapsedEventArgs e)
        {
            if (sec <= 0)
            {
                if (minute > 0)
                {
                    minute--;
                    sec = 59;
                    refreshTimer();
                }
                else {
                    t.Stop();
                    if (pnlRunTest.InvokeRequired)
                    {
                        pnlRunTest.Invoke(
                            (Action)delegate
                            {
                                pnlRunTest.Visible = false;
                            }
                        );
                    }
                    if (abx2.InvokeRequired)
                    {
                        abx2.Invoke(
                            (Action)delegate
                            {
                                abx2.Visible = true;
                            }
                        );
                    }
                    MessageBox.Show("waktu habis!!! \nsilahkan tekan tombol selesai untuk submit hasil ujian anda");
                }
            }
            else {
                sec--;
                refreshTimer();
            }
        }

        private void refreshTimer()
        {
            if (lblSec.InvokeRequired)
            {
                lblSec.Invoke(
                    (Action)delegate
                    {
                        lblSec.Text = sec.ToString();
                    }
                );
            }
            if (lblMinute.InvokeRequired)
            {
                lblSec.Invoke(
                    (Action)delegate
                    {
                        lblMinute.Text = minute.ToString();
                    }
                );
            }
        }

        private void TestFuzzy_Load(object sender, EventArgs e)
        {

        }

        private void btnMulaiTest_Click(object sender, EventArgs e)
        {
            startTimer();
            btnMulaiTest.Visible = false;
            pnlSoal.Visible = true;
            lblNoSoal.Text = noTest + 1 + "";
            IRestRequest reqFirstSoal = new RestRequest("/php/desktopSiswa/getFirstSoal.php",Method.POST);
            reqFirstSoal.AddJsonBody(new
            {
                idBankSoal = testOpen.idBankSoal,
                jenisSoal = listJenisSoal[noTest]
            });
            client.ExecuteAsync(reqFirstSoal, response =>
            {
                FuzzyGetFirst respon = JsonConvert.DeserializeObject<FuzzyGetFirst>(response.Content);
                listSoal.Add(respon.data);
                Debug.WriteLine("messege : "+respon.messege);
                loadSoal(listSoal[noTest]);
                listIdSoal.Add(respon.data.idSoal);
            });

        }

        private void loadSoal(SoalModel responData)
        {
            if (responData.jenisSoal.ToLower().Equals("pilihan ganda"))
            {
                listIdSoal.Add(responData.idSoal);
                if (this.InvokeRequired) this.Invoke((Action) delegate { loadPilGan(responData); });
            }
            else if (responData.jenisSoal.ToLower().Equals("melengkapi"))
            {
                if (this.InvokeRequired) this.Invoke((Action) delegate{ loadEssay(responData); });
            }
        }

        private void loadPilGan(SoalModel responData)
        {
            pnlPilGan.Visible = true;
            pnlEssay.Visible = false;
            rtbIsiSoal.Text = responData.isiSoal;
            rbA.Text = responData.pil1;
            rbB.Text = responData.pil2;
            rbC.Text = responData.pil3;
            rbD.Text = responData.pil4;
            rbE.Text = responData.pil5;
        }

        private void loadEssay(SoalModel responData)
        {
            pnlPilGan.Visible = false;
            pnlEssay.Visible = true;
            rtbIsiSoal.Text = responData.isiSoal;
            Debug.WriteLine("jumlah esay : " + responData.jumlahEsay);
            if (responData.jumlahEsay == 1)
            {
                Debug.WriteLine("jalan di if 1");
                rtbEssay1.Visible = true;
                label1.Visible = true;
                rtbEssay2.Visible = false;
                label5.Visible = false;
                rtbEssay3.Visible = false;
                label7.Visible = false;
            }
            else if (responData.jumlahEsay == 2)
            {
                Debug.WriteLine("jalan di if 2");
                rtbEssay1.Visible = true;
                label1.Visible = true;
                rtbEssay2.Visible = true;
                label5.Visible = true;
                rtbEssay3.Visible = false;
                label7.Visible = false;
            }
            else if (responData.jumlahEsay == 3)
            {
                Debug.WriteLine("jalan di if 3");
                rtbEssay1.Visible = true;
                label1.Visible = true;
                rtbEssay2.Visible = true;
                label5.Visible = true;
                rtbEssay3.Visible = true;
                label7.Visible = true;
            }
            else {
                Debug.WriteLine("jalan di else nya");
            }

        }

        private void startTimer()
        {
            t.Start();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            t.Stop();
            SiswaDashBoard dash = new SiswaDashBoard(siswa,listAngkatan,listKompi,listPleton);
            dash.Show();
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            cekJawab();
            Debug.WriteLine("score total : " + scores.Sum());
            DialogResult result = MessageBox.Show("Submit Hasil Test ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                submitRespon();

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

        private void submitRespon()
        {
            t.Stop();
            IRestRequest reqRespon = new RestRequest("/php/desktopSiswa/pushResponDesktop.php", Method.POST);
            reqRespon.AddJsonBody(new
            {
                nis = siswa.nis,
                idTest = testOpen.idTest,
                nilai = scores.Sum(),
                jenis = testOpen.jenisTest
            });
            IRestResponse<ResponGeneral> resFinish = client.Execute<ResponGeneral>(reqRespon);
            ResponGeneral respon = JsonConvert.DeserializeObject<ResponGeneral>(resFinish.Content);
            if (respon.status == 1)
            {
                SiswaDashBoard dasboard = new SiswaDashBoard(siswa, listAngkatan, listKompi, listPleton);
                dasboard.Show();
                MessageBox.Show("nilai berhasil di upload");
                if (this.InvokeRequired) this.Invoke((Action)delegate { this.Close(); });

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("apa anda yakin sudah terjawab dengan benar ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cekJawab();
                resetFiled();
                noTest++;
                lblNoSoal.Text = noTest + 1 + "";
                if (noTest == listJenisSoal.Count - 1)
                {
                    btnNext.Visible = false;
                }
                Debug.WriteLine("croscek : " + scores[noTest]);
                getNextSoal();
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

        private void getNextSoal()
        {
            var reqNextSoal = new RestRequest("/php/desktopSiswa/nextSoal.php", Method.POST);
            reqNextSoal.AddJsonBody(new
            {
                status = isTrue,
                idBankSoal = testOpen.idBankSoal,
                jenis = listJenisSoal[noTest],
                dayaBeda = listSoal[noTest-1].dayaBeda,
                tingkatKesulitanSoal = listSoal[noTest-1].tingkatKesulitanSoal,
                idSoals = listIdSoal
            });
            client.ExecuteAsync(reqNextSoal, response =>
            {
                Debug.WriteLine("result : " + response.Content);
                SoalModel soal = JsonConvert.DeserializeObject<NextSoalResponse>(response.Content).soal;
                listSoal.Add(soal);
                listIdSoal.Add(soal.idSoal);
                loadSoal(listSoal[noTest]);

            });
        }

        public void cekJawab()
        {
            if (listSoal[noTest].jenisSoal.ToLower().Equals("pilihan ganda"))
            {
                Debug.WriteLine("notest : " + noTest);
                Debug.WriteLine("list soal : " + listSoal.Count);
                checkPilGanAdaptif(listSoal[noTest]);
            }
            else if (listSoal[noTest].jenisSoal.ToLower().Equals("melengkapi"))
            {
                checkEssayAdaptif(listSoal[noTest]);
            }
        }

        private void checkEssayAdaptif(SoalModel soalModel)
        {
            if (soalModel.jumlahEsay == 1)
            {
                double midScore = soalModel.cluster * testOpen.scoreItem * checkEssay1(soalModel);
                scores[noTest] = midScore;
            }
            else if (soalModel.jumlahEsay == 2)
            {
                double midScore = (soalModel.cluster * testOpen.scoreItem) * checkEssay2(soalModel);
                scores[noTest] = midScore;
            }
            else if (soalModel.jumlahEsay == 3)
            {
                double midScore = (soalModel.cluster * testOpen.scoreItem) * checkEssay3(soalModel);
                scores[noTest] = midScore;
            }

        }

        private double checkEssay1(SoalModel listSoal)
        {
            double point = 0;
            if (RemoveWhitespace(listSoal.pil1.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay1.Text.Trim().ToLower().Replace(",", "").Replace(".", "")))
            {
                point++;
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
            return point;
        }

        private double checkEssay2(SoalModel listSoal)
        {
            double point = 0;
            if (RemoveWhitespace(listSoal.pil1.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay1.Text.Trim().ToLower().Replace(",", "").Replace(".", "")))
            {
                point++;
            }
            if (RemoveWhitespace(listSoal.pil2.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay2.Text.Trim().ToLower().Replace(",", "").Replace(".", "")))
            {
                point++;
            }
            if (point == 2)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
            return point / 2;
        }

        private double checkEssay3(SoalModel listSoal)
        {
            double point = 0;
            if (RemoveWhitespace(listSoal.pil1.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay1.Text.Trim().ToLower().Replace(",", "").Replace(".", "")))
            {
                point++;
            }
            if (RemoveWhitespace(listSoal.pil2.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay2.Text.Trim().ToLower().Replace(",", "").Replace(".", "")))
            {
                point++;
            }
            if (RemoveWhitespace(listSoal.pil3.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay3.Text.Trim().ToLower().Replace(",", "").Replace(".", "")))
            {
                point++;
            }
            if (point == 3)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
            Debug.WriteLine("score : " + point);
            return point / 3;
        }

        private void checkPilGanAdaptif(SoalModel soalModel)
        {
            string jawab = getJawabPilgan();
            if (jawab.Trim().ToLower().Equals(soalModel.kunci.Trim().ToLower()))
            {
                double score = soalModel.cluster * testOpen.scoreItem;
                scores[noTest] = score;
                isTrue = true;
            }
            else
            {
                isTrue = false;
                scores[noTest] = 0;
            }

        }



        public static string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        private string getJawabPilgan()
        {
            string jawab = "";
            if (rbA.Checked)
            {
                jawab = "a";
            }
            if (rbB.Checked)
            {
                jawab = "b";
            }
            if (rbC.Checked)
            {
                jawab = "c";
            }
            if (rbD.Checked)
            {
                jawab = "d";
            }
            if (rbE.Checked)
            {
                jawab = "e";
            }
            return jawab;
        }
        private void resetFiled()
        {
            rbA.Checked = false;
            rbB.Checked = false;
            rbC.Checked = false;
            rbD.Checked = false;
            rbE.Checked = false;
            rtbEssay1.Text = "";
            rtbEssay2.Text = "";
            rtbEssay3.Text = "";
        }
    }
}
