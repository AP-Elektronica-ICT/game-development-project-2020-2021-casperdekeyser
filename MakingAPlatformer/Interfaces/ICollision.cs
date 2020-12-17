using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public interface ICollision
    {
        public Rectangle CollisionRectangle { get; set; }
    }
}
