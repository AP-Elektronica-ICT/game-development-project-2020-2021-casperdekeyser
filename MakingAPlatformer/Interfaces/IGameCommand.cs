using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public interface IGameCommand
    {
        void Execute(ITransform transform, Movement direction);
    }
}
