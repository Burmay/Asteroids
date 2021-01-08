using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if(Form1.Close != null)
            {
                Form form = new Form();
                form.Width = 1600;
                form.Height = 600;
                Game.Init(form);
                form.Show();
                Game.Load();
                Game.Draw();
                Application.Run(form);
            }
        }
    }
}