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
            if(Game.Height > 1000 || Game.Height < 0 || Game.Width > 3000 || Game.Height < 0)
            {
                throw new NotImplementedException();
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroid;
        public static void Load()
        {
            Random random = new Random();
            _objs = new BaseObject[30];
            _asteroid = new Asteroid[20];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));


            // генерация астероидов
            for (int i = 0; i < _asteroid.Length; i++)
            {
                int b = random.Next(-300, 400);
                int c = random.Next(-7, 7);
                int d = random.Next(-7, 7);
                int f = random.Next(-300, 300);
                _asteroid[i] = new Asteroid(new Point(1200 + b, 300 + f), new Point(c, d), new Size(24, 32));
            }
            // генерация объектов, летящих прямо
            for (int i = 0; i < _objs.Length; i++)
            {
                int a = random.Next(-2, 2);
                int b = random.Next(-800, 800);
                int c = random.Next(-15, -5);
                _objs[i] = new Star(new Point(800 + b, i * (18 + a)), new Point(-2 + c, 0), new Size(20, 20));
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroid)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid obj in _asteroid)
            {
                obj.Update();
                if (obj.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    obj.Reload();
                    _bullet.Reload();
                }
            }
                _bullet.Update();
        }
    }

}
