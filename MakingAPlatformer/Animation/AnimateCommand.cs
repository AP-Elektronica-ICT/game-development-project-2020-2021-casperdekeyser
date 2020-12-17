using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class AnimateCommand
    {
        public void Execute(IAnimateable transform, Movement moveDirection)
        {
            if (Hero.State == States.Jumping)
            {
                if (transform.Animator.previousAnimation == PossibleAnimations.RunLeft || transform.Animator.previousAnimation == PossibleAnimations.IdleLeft)
                    transform.AnimToPlay = PossibleAnimations.JumpLeft;
                if (transform.Animator.previousAnimation == PossibleAnimations.RunRight || transform.Animator.previousAnimation == PossibleAnimations.IdleRight)
                    transform.AnimToPlay = PossibleAnimations.JumpRight;
            }
            else
            {
                if (moveDirection == Movement.MoveRight)
                    transform.AnimToPlay = PossibleAnimations.RunLeft;
                if (moveDirection == Movement.MoveLeft)
                    transform.AnimToPlay = PossibleAnimations.RunRight;
                if (moveDirection == Movement.Idle)
                {
                    if (transform.Animator.previousAnimation == PossibleAnimations.RunLeft || transform.Animator.previousAnimation == PossibleAnimations.JumpLeft)
                        transform.AnimToPlay = PossibleAnimations.IdleLeft;
                    if (transform.Animator.previousAnimation == PossibleAnimations.RunRight || transform.Animator.previousAnimation == PossibleAnimations.JumpRight)
                        transform.AnimToPlay = PossibleAnimations.IdleRight;
                }
            }

        }
    }
}
