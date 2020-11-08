﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public enum Movement { MoveRight, MoveLeft, Idle, Jump}
    public class KeyboardReader : IInputReader
    {
        public bool CheckInput()
        {
            throw new NotImplementedException();
        }

        public Movement ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                return Movement.MoveLeft;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                return Movement.MoveRight;
            }
            // default
            return Movement.Idle;
        }
    }
}
