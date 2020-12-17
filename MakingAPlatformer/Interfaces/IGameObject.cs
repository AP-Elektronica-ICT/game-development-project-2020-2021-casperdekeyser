using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public interface IGameObject
    {
        Animator Animator { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        public BoxCollider Collider { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
    }
}
