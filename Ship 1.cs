using System;
using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        public static event Message MessageDie;

        Image ship;

        public int Energy { get; internal set; } = 10;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            ship = Image.FromFile("Pok.jpg");
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public override void Draw()
        {

            RectangleF rect = new RectangleF(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(ship, rect);
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }

        public override void Update()
        {
            if (Pos.X > 1500) Pos.X = 1500;
            if (Pos.X < 0) Pos.X = 0;
            if (Pos.Y > 500) Pos.Y = 500;
            if (Pos.Y < 0) Pos.Y = 0;
        }

        internal void EnergyLow(int v)
        {
            Energy = Energy - v;
            if(Energy == 0)
            {
                Die();
            }

        }

        internal void Up()
        {
            Pos.Y = Pos.Y - 30;
        }

        internal void Down()
        {
            Pos.Y = Pos.Y + 30;
        }

        internal void Left()
        {
            Pos.X = Pos.X - 30;
        }
        internal void Right()
        {
            Pos.X = Pos.X + 30;
        }
    }
}
