using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 40 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static BaseObject[] _objs;
        public static void Load()
        {
            Random random = new Random();
            _objs = new Star[80];
            for (int i = 0; i < _objs.Length; i++)
            {
                int x = random.Next(0, 10);
                _objs[i] = new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(10 + x, 10 + x));
            }
        }

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

    }

}
