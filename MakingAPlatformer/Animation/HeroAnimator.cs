using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class HeroAnimator : Animator
    {

        public override Animation Animate(PossibleAnimations animToPlay)
        {
            previousAnimation = animToPlay;

            if (animToPlay == PossibleAnimations.RunLeft)
            {
                return Animations[2];
            }
            if (animToPlay == PossibleAnimations.RunRight)
            {
                return Animations[3];
            }
            if (animToPlay == PossibleAnimations.IdleLeft)
            {
                 return Animations[0];
            }
            if (animToPlay == PossibleAnimations.IdleRight)
            {
                return Animations[1];
            }
            if (animToPlay == PossibleAnimations.JumpRight)
            {
                return Animations[5];
            }
            if (animToPlay == PossibleAnimations.JumpLeft)
            {
                return Animations[4];
            }
            // default;
            return Animations[0];
        }
    }
}
