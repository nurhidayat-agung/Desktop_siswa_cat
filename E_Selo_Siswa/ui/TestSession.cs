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
using E_Selo_Siswa.model.dashboard;
using E_Selo_Siswa.model.general;
using E_Selo_Siswa.model.kompi;
using E_Selo_Siswa.model.pleton;
using System.Diagnostics;
using System.Text.RegularExpressions;
using RestSharp;
using Newtonsoft.Json;
using System.Timers;

namespace E_Selo_Siswa.ui
{
    public partial class TestSession : ParrentForm
    {
        private List<AngkatanModel> listAngkatan;
        private List<KompiModel> listKompi;
        private List<PletonModel> listPleton;
        private List<ListSoal> listSoal;
        private Siswa siswa;
        private TestOpen testOpen;
        private int noTest = 0;
        private double[] scores;
        private LockedAnswer[] answers;
        private bool[] isAnswer;
        private IRestResponse<ResponGeneral> resReg;
        private IRestResponse<ResponGeneral> resDetRes;
        System.Timers.Timer t;
        double minute, sec;

        public TestSession()
        {
            InitializeComponent();
        }

        public TestSession(TestOpen testOpen, List<ListSoal> listSoal, Siswa siswa, List<AngkatanModel> listAngkatan, List<KompiModel> listKompi, List<PletonModel> listPleton)
        {
            this.testOpen = testOpen;
            this.listSoal = listSoal;
            this.siswa = siswa;
            this.listAngkatan = listAngkatan;
            this.listKompi = listKompi;
            this.listPleton = listPleton;
            scores = new double[listSoal.Count];
            answers = new LockedAnswer[listSoal.Count];
            isAnswer = new bool[listSoal.Count];
            InitializeComponent();
            loadTestInformation(testOpen);
            loadTimerTest(testOpen);            
        }

        private void TestSession_Load(object sender, EventArgs e)
        {
            
        }

        private void loadTimerTest(TestOpen testOpen)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += onTimeEvent;
            sec = 0;
            minute = testOpen.waktuTest;
            lblSec.Text = sec.ToString();
            lblMinute.Text = minute.ToString();
        }

        private void loadTestInformation(TestOpen testOpen)
        {
            lblNamaTest.Text = testOpen.namaTest;
            lblJenisTest.Text = testOpen.jenisTest;
            lblJmlPilgan.Text = testOpen.jmlPilGanda + " butir soal";
            lblJmlEssay.Text = testOpen.jmlEssay + " butir soal";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            t.Stop();
            SiswaDashBoard dasboard = new SiswaDashBoard(siswa,listAngkatan,listKompi,listPleton);
            dasboard.Show();
            this.Close();
        }

        private void btnMulaiTest_Click(object sender, EventArgs e)
        {
            startTimer();
            btnMulaiTest.Visible = false;
            pnlSoal.Visible = true;
            lblNoSoal.Text = noTest + 1 + "";
            loadSoal(listSoal[noTest]);
            btnBack.Enabled = false;
            if (listSoal.Count > 1)
            {
                btnNext.Enabled = true;
            }
            else {
                btnNext.Enabled = false;
            }
             
        }

        private void startTimer()
        {
            t.Start();
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

        private void loadSoal(ListSoal listSoal)
        {
            if (listSoal.jenisSoal.ToLower().Equals("pilihan ganda")) {
                pnlPilGan.Visible = true;
                pnlEssay.Visible = false;
                loadSoalPilGan(listSoal);
            } else if (listSoal.jenisSoal.ToLower().Equals("melengkapi")) {
                pnlEssay.Visible = true;
                pnlPilGan.Visible = false;
                loadSoalEssay(listSoal);                
            }
        }

        private void loadSoalEssay(ListSoal listSoal)
        {
            rtbIsiSoal.Text = listSoal.isiSoal;
            Debug.WriteLine("jumlah esay : " + listSoal.jumlahEsay);
            if (listSoal.jumlahEsay == 1)
            {
                Debug.WriteLine("jalan di if 1");
                rtbEssay1.Visible = true;
                label1.Visible = true;
                rtbEssay2.Visible = false;
                label5.Visible = false;
                rtbEssay3.Visible = false;
                label7.Visible = false;
            }
            else if (listSoal.jumlahEsay == 2)
            {
                Debug.WriteLine("jalan di if 2");
                rtbEssay1.Visible = true;
                label1.Visible = true;
                rtbEssay2.Visible = true;
                label5.Visible = true;
                rtbEssay3.Visible = false;
                label7.Visible = false;
            }
            else if (listSoal.jumlahEsay == 3)
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

        private void loadSoalPilGan(ListSoal listSoal)
        {
            pnlPilGan.Visible = true;
            pnlEssay.Visible = false;
            rtbIsiSoal.Text = listSoal.isiSoal;
            rbA.Text = listSoal.pil1;
            rbB.Text = listSoal.pil2;
            rbC.Text = listSoal.pil3;
            rbD.Text = listSoal.pil4;
            rbE.Text = listSoal.pil5;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cekJawab();
            abx1.Visible = false;
            resetFiled();
            noTest++;
            lblNoSoal.Text = noTest + 1 + "";
            if (noTest < listSoal.Count - 1)
            {
                btnNext.Enabled = true;
                if (noTest <= 0)
                {
                    btnBack.Enabled = false;
                }
                else {
                    btnBack.Enabled = true;
                }
            }
            else {
                btnNext.Enabled = false;
                if (noTest <= 0)
                {
                    btnBack.Enabled = false;
                }
                else {
                    btnBack.Enabled = true;
                }
            }
            loadSoal(listSoal[noTest]);
            if (isAnswer[noTest]) {
                loadAnswer(listSoal[noTest]);
            }
        }

        private void loadAnswer(ListSoal listSoal)
        {
            if (listSoal.jenisSoal.ToLower().Equals("pilihan ganda"))
            {
                loadAnswerPilGan(listSoal);
            }
            else if (listSoal.jenisSoal.ToLower().Equals("melengkapi"))
            {
                loadAnswerEssay(listSoal);
            }
        }

        private void loadAnswerEssay(ListSoal listSoal)
        {
            if (listSoal.jumlahEsay == 1)
            {
                rtbEssay1.Text = answers[noTest].pil1;
            }
            else if (listSoal.jumlahEsay == 2)
            {
                rtbEssay1.Text = answers[noTest].pil1;
                rtbEssay2.Text = answers[noTest].pil2;
            }
            else if (listSoal.jumlahEsay == 3)
            {
                rtbEssay1.Text = answers[noTest].pil1;
                rtbEssay2.Text = answers[noTest].pil2;
                rtbEssay3.Text = answers[noTest].pil3;
            }
        }

        private void loadAnswerPilGan(ListSoal listSoal)
        {
            if (answers[noTest].kunci.ToLower().Trim().Equals("a"))
            {
                rbA.Checked = true;
            }
            else if (answers[noTest].kunci.ToLower().Trim().Equals("b"))
            {
                rbB.Checked = true;
            }
            else if (answers[noTest].kunci.ToLower().Trim().Equals("c"))
            {
                rbC.Checked = true;
            }
            else if (answers[noTest].kunci.ToLower().Trim().Equals("d"))
            {
                rbD.Checked = true;
            }
            else if (answers[noTest].kunci.ToLower().Trim().Equals("e"))
            {
                rbE.Checked = true;
            }
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            cekJawab();
            abx1.Visible = false;
            resetFiled();
            noTest--;
            lblNoSoal.Text = noTest + 1 + "";
            if (noTest <= 0)
            {
                btnBack.Enabled = false;
                if (noTest < listSoal.Count - 1)
                {
                    btnNext.Enabled = true;
                }
                else {
                    btnNext.Enabled = false;
                }
            }
            else {
                btnBack.Enabled = true;
                if (noTest < listSoal.Count - 1)
                {
                    btnNext.Enabled = true;
                }
                else {
                    btnNext.Enabled = false;
                }
            }
            loadSoal(listSoal[noTest]);
            if (isAnswer[noTest])
            {
                loadAnswer(listSoal[noTest]);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (testOpen.jenisTest.ToLower().Trim().Equals("klasik"))
            {
                if (listSoal[noTest].jenisSoal.ToLower().Equals("pilihan ganda"))
                {
                    checkPilGanKlasik(listSoal[noTest]);
                }
                else if (listSoal[noTest].jenisSoal.ToLower().Equals("melengkapi"))
                {
                    checkEssayKlassik(listSoal[noTest]);
                }
            }
            else if (testOpen.jenisTest.ToLower().Trim().Equals("adaptif"))
            {
                if (listSoal[noTest].jenisSoal.ToLower().Equals("pilihan ganda"))
                {
                    checkPilGanAdaptif(listSoal[noTest]);
                }
                else if (listSoal[noTest].jenisSoal.ToLower().Equals("melengkapi"))
                {
                    checkEssayAdaptif(listSoal[noTest]);
                }
            }
            abx1.Visible = true;
            Debug.WriteLine("hasil koreksi : " + scores[noTest]);          
        }

        public void cekJawab()
        {
            if (testOpen.jenisTest.ToLower().Trim().Equals("klasik"))
            {
                if (listSoal[noTest].jenisSoal.ToLower().Equals("pilihan ganda"))
                {
                    checkPilGanKlasik(listSoal[noTest]);
                }
                else if (listSoal[noTest].jenisSoal.ToLower().Equals("melengkapi"))
                {
                    checkEssayKlassik(listSoal[noTest]);
                }
            }
            else if (testOpen.jenisTest.ToLower().Trim().Equals("adaptif"))
            {
                if (listSoal[noTest].jenisSoal.ToLower().Equals("pilihan ganda"))
                {
                    checkPilGanAdaptif(listSoal[noTest]);
                }
                else if (listSoal[noTest].jenisSoal.ToLower().Equals("melengkapi"))
                {
                    checkEssayAdaptif(listSoal[noTest]);
                }
            }
        }

        public static string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        private void checkEssayAdaptif(ListSoal listSoal)
        {
            
            if (listSoal.jumlahEsay == 1)
            {
                double midScore = listSoal.bobot * testOpen.scoreItem * checkEssay1(listSoal);
                scores[noTest] = midScore;
                saveEssayAnswer(1);
                
            }
            else if (listSoal.jumlahEsay == 2)
            {
                double midScore = (listSoal.bobot * testOpen.scoreItem) * checkEssay2(listSoal);
                scores[noTest] = midScore;
                saveEssayAnswer(2);
                
            }
            else if (listSoal.jumlahEsay == 3)
            {
                double midScore = (listSoal.bobot * testOpen.scoreItem) * checkEssay3(listSoal);
                scores[noTest] = midScore;
                saveEssayAnswer(3);
                
            }
            
        }

        private void saveEssayAnswer(int v)
        {
            answers[noTest] = new LockedAnswer();
            if (v == 1)
            {
                answers[noTest].pil1 = rtbEssay1.Text;
                isAnswer[noTest] = true;
            }
            else if (v == 2)
            {
                answers[noTest].pil1 = rtbEssay1.Text;
                answers[noTest].pil2 = rtbEssay2.Text;
                isAnswer[noTest] = true;
            }
            else if (v == 3)
            {
                answers[noTest].pil1 = rtbEssay1.Text;
                answers[noTest].pil2 = rtbEssay2.Text;
                answers[noTest].pil3 = rtbEssay3.Text;
                isAnswer[noTest] = true;
            }
        }

        private void checkPilGanAdaptif(ListSoal listSoal)
        {
            string jawab = getJawabPilgan();
            setJawabPilGan(jawab);
            if (jawab.Trim().ToLower().Equals(listSoal.kunci.Trim().ToLower()))
            {
                double score = listSoal.bobot * testOpen.scoreItem;
                scores[noTest] = score;
            }
            else {
                scores[noTest] = 0;
            }
        }

        private void checkEssayKlassik(ListSoal listSoal)
        {
            
            if (listSoal.jumlahEsay == 1)
            {
                double midScore = testOpen.scoreItem * checkEssay1(listSoal);
                scores[noTest] = midScore;
                saveEssayAnswer(1);
                if (checkEssay1(listSoal) == 1)
                {
                    this.listSoal[noTest].crosscek = 1;
                }
                else
                {
                    this.listSoal[noTest].crosscek = 0;
                }

            }
            else if (listSoal.jumlahEsay == 2)
            {
                double midScore =  testOpen.scoreItem * checkEssay2(listSoal);
                scores[noTest] = midScore;
                saveEssayAnswer(2);
                if (checkEssay2(listSoal) == 1)
                {
                    this.listSoal[noTest].crosscek = 1;
                }
                else
                {
                    this.listSoal[noTest].crosscek = 0;
                }
            }
            else if (listSoal.jumlahEsay == 3)
            {
                double midScore =  testOpen.scoreItem * checkEssay3(listSoal);
                scores[noTest] = midScore;
                saveEssayAnswer(3);
                if (checkEssay3(listSoal) == 1)
                {
                    this.listSoal[noTest].crosscek = 1;
                }
                else
                {
                    this.listSoal[noTest].crosscek = 0;
                }
            }
        }

        private void checkPilGanKlasik(ListSoal listSoal)
        {
            string jawab = getJawabPilgan();
            setJawabPilGan(jawab);
            if (jawab.Trim().ToLower().Equals(listSoal.kunci.Trim().ToLower()))
            {
                double score = testOpen.scoreItem;
                scores[noTest] = score;
                this.listSoal[noTest].crosscek = 1;
                
            }
            else
            {
                scores[noTest] = 0;
                this.listSoal[noTest].crosscek = 0;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            cekJawab();
            Debug.WriteLine("score total : " + scores.Sum());
            DialogResult result = MessageBox.Show("Submit Hasil Test ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
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
            var client = new RestClient(RootUrl.rootUrl);
            IRestRequest reqRespon = new RestRequest("/php/desktopSiswa/pushResponDesktop.php", Method.POST);
            reqRespon.AddJsonBody(new
            {
                nis = siswa.nis,
                idTest = testOpen.idTest,
                nilai = scores.Sum(),
                jenis = testOpen.jenisTest
            });
            resReg = client.Execute<ResponGeneral>(reqRespon);
            Debug.WriteLine(resReg.Content);
            ResponGeneral resp = JsonConvert.DeserializeObject<ResponGeneral>(resReg.Content);
            if (resp.status == 1)
            {
                Debug.WriteLine("idRespon test : " + resp.messege);
                long[] idSoals = new long[this.listSoal.Count];
                int[] crosscek = new int[this.listSoal.Count];
                for (int a = 0; a < this.listSoal.Count; a++) {
                    idSoals[a] = this.listSoal[a].idSoal;
                    crosscek[a] = this.listSoal[a].crosscek;
                    
                }               
                IRestRequest reqDetRespon = new RestRequest("/php/desktopSiswa/pushDetailResponDesktop.php", Method.POST);
                reqDetRespon.AddJsonBody(new {
                    idResponTest = resp.messege,
                    idSoals = idSoals,
                    crosceks = crosscek
                });
                resDetRes = client.Execute<ResponGeneral>(reqDetRespon);
                Debug.WriteLine(resDetRes.Content);
                
                ResponGeneral respDet = JsonConvert.DeserializeObject<ResponGeneral>(resDetRes.Content);
                if (respDet.status == 1)
                {
                    SiswaDashBoard dasboard = new SiswaDashBoard(siswa, listAngkatan, listKompi, listPleton);
                    dasboard.Show();
                    MessageBox.Show("nilai berhasil di upload");
                    if (this.InvokeRequired)
                    {
                        this.Invoke(
                           (Action)delegate
                           {
                               this.Close();
                           }
                        );
                    }
                    else {
                        this.Close();
                    }
                    
                }
                else {
                    MessageBox.Show("input detail respon gagal");
                }

            }
            else {
                MessageBox.Show("input respon gagal");
            }

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

        private void setJawabPilGan(string jawab) {
            answers[noTest] = new LockedAnswer();
            answers[noTest].kunci = jawab;
            isAnswer[noTest] = true;
        }

        private double checkEssay1(ListSoal listSoal) {
            double point = 0;
            if (RemoveWhitespace(listSoal.pil1.Trim().ToLower().Replace(",", "").Replace(".", ""))
                    == RemoveWhitespace(rtbEssay1.Text.Trim().ToLower().Replace(",", "").Replace(".", ""))) {
                point++;
            }
            return point;
        }

        private double checkEssay2(ListSoal listSoal)
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
            return point/2;
        }

        private double checkEssay3(ListSoal listSoal)
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
            Debug.WriteLine("score : " + point);
            return point/3;
        }
    }
}





    