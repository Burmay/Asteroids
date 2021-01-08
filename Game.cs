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
            Timer timer = new Timer { Interval = 45 };
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
            _objs = new BaseObject[40];


            // генерация объектов, отталкивающхся от границ экрана
            for (int i = (_objs.Length/4) * 3; i < _objs.Length; i++)
            {
                int b = random.Next(-300, 300);
                int c = random.Next(-7, 7);
                int d = random.Next(-7, 7);
                int f = random.Next(-200, 200);
                _objs[i] = new BaseObject(new Point(400 + b, 400 + f), new Point(c, d), new Size(25, 32));
            }
            // генерация объектов, летящих прямо
            for (int i = 0; i < _objs.Length / 4 * 3; i++)
            {
                int a = random.Next(-2, 2);
                int b = random.Next(-800, 800);
                int c = random.Next(-15, -5);
                _objs[i] = new Star(new Point(800 + b, i * (18 + a)), new Point(-2 + c, 0), new Size(50, 20));
            }
        }

        public static void Draw()
        {
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
