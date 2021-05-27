using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class Giris_form : Form
    {
        public Giris_form()
        {
            InitializeComponent();
        }

        GameWindow frm1 = new GameWindow();
        GameWindow2 frm2 = new GameWindow2();
        GameWindow3 frm3 = new GameWindow3();

        private void button3_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Hide();
        }
    }
}
