using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Timer timer = new Timer { Interval = 45 };
        public static Random Rnd = new Random();

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString($"The End, your account: {score} ", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 300, 400);
            Buffer.Render();
        }

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(80, 100));
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            //Timer timer = new Timer { Interval = 45 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;
            if (Game.Height > 1000 || Game.Height < 0 || Game.Width > 3000 || Game.Height < 0)
            {
                throw new NotImplementedException();
            }
        }
        public static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet.Add(new Bullet(new Point(_ship.Rect.X + 30, _ship.Rect.Y + 80), new Point(4, 0), new Size(16, 4)));
            if (e.KeyValue == (char)Keys.Up) _ship.Up();
            if (e.KeyValue == (char)Keys.Down) _ship.Down();
            if (e.KeyValue == (char)Keys.Left) _ship.Left();
            if (e.KeyValue == (char)Keys.Right) _ship.Right();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        private static BaseObject[] _objs;
        private static List<Bullet> _bullet = new List<Bullet>(50);
        private static Asteroid[] _asteroid;
        private static Heal[] _heal;
        private static int score = 0;
        public static void Load()
        {
            Random random = new Random();
            _objs = new BaseObject[30];
            _asteroid = new Asteroid[60];
            _heal = new Heal[6];


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
            // генерация аптечек
            for (int i = 0; i < _heal.Length; i++)
            {
                int a = random.Next(300, 700);
                int b = random.Next(-700, 700);
                int c = random.Next(-3, 3);
                int f = random.Next(-3, 3);
                _heal[i] = new Heal(new Point(800 + b, a), new Point(c, f), new Size(40, 40));
            }

        }

        public static void Draw()
        {
            {

                Buffer.Graphics.Clear(Color.Black);
                foreach (BaseObject obj in _objs)
                    obj.Draw();
                foreach (Asteroid a in _asteroid)
                {
                    a?.Draw();
                }
                foreach (Bullet bullet in _bullet)
                {
                    bullet?.Draw();
                }
                _ship?.Draw();
                //if (_ship != null)
                    Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DialogFont, Brushes.White, 0, 0);
                for (int i = 0; i < _heal.Length; i++)
                {
                    if (_heal[i] != null)
                    {
                        _heal[i].Draw();
                    }
                }
                Buffer.Render();
            }
        }

        public static void Update()
        {
            _ship.Update();
            for (int i = 0; i != _heal.Length; i++)
            {
                if (_heal[i] != null && _ship.Collision(_heal[i]))
                {
                    _ship.Energy = _ship.Energy + 500;
                    _heal[i] = null;
                    continue;
                }
            }
            foreach (BaseObject obj in _objs) obj.Update();
          _ship.Draw();
            for(int i = 0; i != _bullet.Count; i++)
            {                
                _bullet[i]?.Update();
                for (var j = 0; j < _asteroid.Length; j++)
                {
                    if (_bullet[i] != null && _asteroid[j] != null && _bullet[i].Collision(_asteroid[j]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroid[j] = null;
                        _bullet[i] = null;
                        score = score + 3;
                        continue;
                    }
                }
                    
            }
            for (var i = 0; i < _asteroid.Length; i++)
            {
                
                if (_asteroid[i] == null) continue;
            _asteroid[i].Update();
            if (!_ship.Collision(_asteroid[i])) continue;
            //var rnd = new Random();
            _ship?.EnergyLow(50);
                _asteroid[i] = null;
                score++;
            System.Media.SystemSounds.Asterisk.Play();
            if (_ship.Energy <= 0) _ship?.Die();
            }
            for (int i = 0; i < _heal.Length; i++)
            {
                if(_heal[i] != null)
                {
                    _heal[i].Update();
                }
            }

        }

    }
}
