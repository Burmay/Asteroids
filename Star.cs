﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    class Star: BaseObject
    {
        Image meteor;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            meteor = Image.FromFile("Aster.jpeg");
        }
        public override void Draw()
        {
            RectangleF rect = new RectangleF(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(meteor, rect);

            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X > Game.Width) Pos.X = 0;
        }

    }
}
