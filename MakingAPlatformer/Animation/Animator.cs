﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Animator
    {
        public List<Animation> Animations;

        public Animator()
        {
            Animations = new List<Animation>();
            Animations.Add(new Animation("Hero/Normal/Run"));
            Animations.Add(new Animation("Hero/Mirrored/Run-MIRRORED"));

            foreach (Animation animation in Animations)
            {
                for (int i = 0; i <= 1050; i = i + 150)
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 150, 150)));
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Animation animation in Animations)
            {
                animation.Update(gameTime);
            }
        }
    }
}
