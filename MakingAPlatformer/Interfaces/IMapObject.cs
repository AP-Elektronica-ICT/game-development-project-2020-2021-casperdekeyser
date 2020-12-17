using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public interface IMapObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Spritesheet { get; set; }
        public string SpritesheetPath { get; set; }
        public BoxCollider Collider { get; set; }
        void Draw(SpriteBatch spriteBatch);
    }
}
