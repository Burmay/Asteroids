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
            Form form = new Form();
            form.Width = 1980;
            form.Height = 1080;
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}