using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class BoxCollider
    {
        public Rectangle Rectangle;
        public Vector2 Position;
        public string Name;
        public int Width;
        public int Height;


        public BoxCollider(Vector2 position, string name, int width, int height)
        {
            Position = position;
            Name = name;
            Width = width;
            Height = height;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public BoxCollider(Vector2 position, string name, int width, int height, int Xoffset, int Yoffset)
        {
            Position = new Vector2(position.X + Xoffset, position.Y + Yoffset);
            Name = name;
            Width = width;
            Height = height;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1, true, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Draw(pixel, Rectangle, Color.Green);
        }

        public void Update()
        {
            Position = new Vector2(Rectangle.X, Rectangle.Y);
        }

    }
}
