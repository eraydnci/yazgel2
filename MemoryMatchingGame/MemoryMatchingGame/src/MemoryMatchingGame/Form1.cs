using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MemoryMatchingGame
{
    public partial class GameWindow : Form
    {
     
        Random location = new Random();
        List<Point> points = new List<Point>();
        bool again = false;
        PictureBox PendingImage1;
        PictureBox PendingImage2;
        public GameWindow()
        {
            InitializeComponent();
        }
        public void ses()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
            sound.SoundLocation = "bilme_ses.wav";
            sound.Play();

        }
        public void yanlıs_ses()
        {
            System.Media.SoundPlayer ysound = new System.Media.SoundPlayer();
            ysound.SoundLocation = "yanlıs_ses.wav";
            ysound.Play();
        }
        private void GameWindow_Load(object sender, EventArgs e)
        {
            ScoreCounter.Text = "0";
            label1.Text = "5";
            label3.Text = "180";
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = false;
                points.Add(picture.Location);
            }
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                int next = location.Next(points.Count);
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);
            }

            timer2.Start();
            timer1.Start();
            timer4.Start();
            Card1.Image = Properties.Resources.Card1;
            DupCard1.Image = Properties.Resources.Card1;
            Card2.Image = Properties.Resources.Card2;
            DupCard2.Image = Properties.Resources.Card2;
            Card3.Image = Properties.Resources.Card3;
            DupCard3.Image = Properties.Resources.Card3;
            Card4.Image = Properties.Resources.Card4;
            DupCard4.Image = Properties.Resources.Card4;
            Card5.Image = Properties.Resources.Card5;
            DupCard5.Image = Properties.Resources.Card5;
            Card6.Image = Properties.Resources.Card6;
            DupCard6.Image = Properties.Resources.Card6;
            Card7.Image = Properties.Resources.Card7;
            DupCard7.Image = Properties.Resources.Card7;
            Card8.Image = Properties.Resources.Card8;
            DupCard8.Image = Properties.Resources.Card8;
            Card9.Image = Properties.Resources.Card9;
            DupCard9.Image = Properties.Resources.Card9;
            Card10.Image = Properties.Resources.Card10;
            DupCard10.Image = Properties.Resources.Card10;
            Card11.Image = Properties.Resources.Card11;
            DupCard11.Image = Properties.Resources.Card11;
            Card12.Image = Properties.Resources.Card12;
            DupCard12.Image = Properties.Resources.Card12;
        }

        public void oyunbitti()
        {
            if (Card1.Visible == false && DupCard1.Visible == false && Card2.Visible == false && DupCard2.Visible == false && Card3.Visible == false && DupCard3.Visible == false && Card4.Visible == false && DupCard4.Visible == false && Card5.Visible == false && DupCard5.Visible == false && Card6.Visible == false && DupCard6.Visible == false && Card7.Visible == false && DupCard7.Visible == false && Card8.Visible == false && DupCard8.Visible == false && Card9.Visible == false && DupCard9.Visible == false && Card10.Visible == false && DupCard10.Visible == false && Card11.Visible == false && DupCard11.Visible == false && Card12.Visible == false && DupCard12.Visible == false)
            {
                DialogResult secenek = MessageBox.Show("Oyun Bitti! Yeniden Oynamak İstiyor musunuz?", "Oyun Bitti!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    // System.Diagnostics.Process.Start(@"MemoryMatchingGame.exe");
                    Application.Restart();
                }
                else if (secenek == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = true;
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.Cover;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label1.Text);
            timer = timer - 1;
            label1.Text = Convert.ToString(timer);
            if (timer == 0)
            {
                timer2.Stop();
            }
        }

        //Change Card Value
        #region Cards
        private void Card1_Click(object sender, EventArgs e)
        {
            Card1.Image = Properties.Resources.Card1;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card1;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card1;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    ses();
                    MessageBox.Show("Doğru Çift");
                    Card1.Visible = false;
                    DupCard1.Visible = false;
                    oyunbitti();

                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");

                    timer3.Start();
                }
            }
        }
        private void DupCard1_Click(object sender, EventArgs e)
        {
            DupCard1.Image = Properties.Resources.Card1;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard1;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard1;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                    Card1.Visible = false;
                    DupCard1.Visible = false;
                    ses();
                    MessageBox.Show("Doğru Çift");
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");

                    timer3.Start();
                }
            }
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            Card2.Image = Properties.Resources.Card2;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card2;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card2;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    Card2.Visible = false;
                    DupCard2.Visible = false;
                    ses();
                    MessageBox.Show("Doğru Çift");
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");

                    timer3.Start();
                }
            }
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            DupCard2.Image = Properties.Resources.Card2;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard2;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard2;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    Card2.Visible = false;
                    DupCard2.Visible = false;
                    ses();
                    MessageBox.Show("Doğru Çift");
                    oyunbitti();

                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");

                    timer3.Start();
                }
            }
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Card3.Image = Properties.Resources.Card3;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card3;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card3;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    Card3.Visible = false;
                    DupCard3.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");

                    timer3.Start();
                }
            }
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            DupCard3.Image = Properties.Resources.Card3;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard3;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard3;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    Card3.Visible = false;
                    DupCard3.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");

                    timer3.Start();
                }
            }
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Card4.Image = Properties.Resources.Card4;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card4;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card4;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    Card4.Visible = false;
                    DupCard4.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            DupCard4.Image = Properties.Resources.Card4;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard4;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard4;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    Card4.Visible = false;
                    DupCard4.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Card5.Image = Properties.Resources.Card5;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card5;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card5;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    Card5.Visible = false;
                    DupCard5.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            DupCard5.Image = Properties.Resources.Card5;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard5;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard5;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    Card5.Visible = false;
                    DupCard5.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            Card6.Image = Properties.Resources.Card6;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card6;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card6;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    Card6.Visible = false;
                    DupCard6.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            DupCard6.Image = Properties.Resources.Card6;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard6;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard6;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    Card6.Visible = false;
                    DupCard6.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Card7.Image = Properties.Resources.Card7;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card7;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card7;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    Card7.Visible = false;
                    DupCard7.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            DupCard7.Image = Properties.Resources.Card7;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard7;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard7;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    Card7.Visible = false;
                    DupCard7.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            Card8.Image = Properties.Resources.Card8;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card8;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card8;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    Card8.Visible = false;
                    DupCard8.Visible = false; ses();
                    MessageBox.Show("Doğru Çift");
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            DupCard8.Image = Properties.Resources.Card8;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard8;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard8;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    Card8.Visible = false;
                    DupCard8.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            Card9.Image = Properties.Resources.Card9;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card9;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card9;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card9.Enabled = false;
                    DupCard9.Enabled = false;
                    Card9.Visible = false;
                    DupCard9.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            DupCard9.Image = Properties.Resources.Card9;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard9;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard9;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card9.Enabled = false;
                    DupCard9.Enabled = false;
                    Card9.Visible = false;
                    DupCard9.Visible = false; ses();
                    MessageBox.Show("Doğru Çift");
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Card10.Image = Properties.Resources.Card10;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card10;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card10;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card10.Enabled = false;
                    DupCard10.Enabled = false;
                    Card10.Visible = false;
                    DupCard10.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            DupCard10.Image = Properties.Resources.Card10;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard10;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard10;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card10.Enabled = false;
                    DupCard10.Enabled = false;
                    Card10.Visible = false;
                    DupCard10.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Card11.Image = Properties.Resources.Card11;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card11;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card11;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card11.Enabled = false;
                    DupCard11.Enabled = false;
                    Card11.Visible = false;
                    DupCard11.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            DupCard11.Image = Properties.Resources.Card11;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard11;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard11;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card11.Enabled = false;
                    DupCard11.Enabled = false;
                    Card11.Visible = false;
                    DupCard11.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Card12.Image = Properties.Resources.Card12;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card12;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card12;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card12.Enabled = false;
                    DupCard12.Enabled = false;
                    Card12.Visible = false;
                    DupCard12.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            DupCard12.Image = Properties.Resources.Card12;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard12;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard12;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card12.Enabled = false;
                    DupCard12.Enabled = false;
                    Card12.Visible = false;
                    DupCard12.Visible = false; ses();
                    MessageBox.Show("Doğru Çift"); 
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    oyunbitti();
                }
                else
                {
                    yanlıs_ses();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    MessageBox.Show("Yanlış Çift");
                    timer3.Start();
                }
            }
        }
        

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            PendingImage1.Image = Properties.Resources.Cover;
            PendingImage2.Image = Properties.Resources.Cover;
            PendingImage1 = null;
            PendingImage2 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameWindow_Load(sender, e);
        }


        private void timer4_Tick_1(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label3.Text);
            timer = timer - 1;
            label3.Text = Convert.ToString(timer);
            if (timer == 0)
            {

                timer4.Stop();
                DialogResult secenek = MessageBox.Show("Süreniz Bitti! Yeniden Oynamak İstiyor musunuz?", "Oyun Bitti!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    GameWindow_Load(sender, e);
                }
                else if (secenek == DialogResult.No)
                {
                    this.Close();
                }
            }
        }
    }
}
#endregion