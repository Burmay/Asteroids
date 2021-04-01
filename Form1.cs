using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Height = 600;
            this.Width = 1600;
            this.BackColor = Color.Black;
            Game.Init(this);
            Game.Load();
            Game.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public static int? Close { get; set; } = 0;
        public void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Close = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Image Background = Image.FromFile("Apocalypse.png");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackgroundImage = Background;
        }
    }
}
