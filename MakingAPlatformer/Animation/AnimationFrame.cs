using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class AnimationFrame
    {
        public Rectangle sourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            sourceRectangle = rectangle;
        }

    }
}
