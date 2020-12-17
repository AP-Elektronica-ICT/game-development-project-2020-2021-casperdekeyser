using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public interface IAnimateable
    {
        PossibleAnimations AnimToPlay { get; set; }
        Animator Animator { get; set; }
    }
}
