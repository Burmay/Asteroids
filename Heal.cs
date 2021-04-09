using System;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids
{
    class Heal : BaseObject
    {
        Image burger;
        public Heal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            burger = Image.FromFile("Burger.jpg");
        }
        public override void Draw()
        {

            RectangleF rect = new RectangleF(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(burger, rect);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

        }

    }
}
