﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MakingAPlatformer
{
    public class CollisionManager
    {
        public static bool Colliding;

        public List<BoxCollider> Colliders;
        public IGameObject Hero;
        
        private int amountOfCollisions;

        public CollisionManager(List<BoxCollider> collliders, IGameObject hero)
        {
            Colliders = collliders;
            Hero = hero;
        }

        public void Execute()
        {
            SyncColliders();
            BasicCollision();
            Debug.WriteLine($"Position HeroCollider: {Hero.Collider.Position.X} / {Hero.Collider.Position.Y} ");
        }

        private void BasicCollision()
        {
            foreach (var collider in Colliders)
            {
                if (CheckCollision(Hero.Collider.Rectangle, collider.Rectangle))
                {
                    amountOfCollisions++;
                    Debug.WriteLine($"COLLISION {amountOfCollisions} with {collider.Name} on {DateTime.Now}");
                }
            }
        }

        private void FutureCollision()
        {
            Vector2 futurePosition = new Vector2(Hero.Position.X + Hero.Direction.X, Hero.Position.Y + Hero.Direction.Y);
            Rectangle futureRectangle = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, Hero.Collider.Width, Hero.Collider.Height);

            foreach (var collider in Colliders)
            {
                if (CheckCollision(futureRectangle, collider.Rectangle))
                {
                    amountOfCollisions++;
                    Debug.WriteLine($"COLLISION {amountOfCollisions} with {collider.Name} on {DateTime.Now}");
                }
            }
        }

        private bool CheckCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
                return true;
            return false;
        }

        public void DrawColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Hero.Collider.Draw(spriteBatch, graphicsDevice);

            foreach (var collider in Colliders)
            {
                collider.Draw(spriteBatch, graphicsDevice);
            }
        }

        public void SyncColliders()
        {
            Hero.Collider.Update();
            foreach (var collider in Colliders)
            {
                collider.Update();
            }
        }


        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider)
        {
            Collider.Rectangle.X = (int)Position.X;
            Collider.Rectangle.Y = (int)Position.Y;
            return Collider;
        }

        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider, int Xoffset, int Yoffset)
        {
            Collider.Rectangle.X = (int)Position.X + Xoffset;
            Collider.Rectangle.Y = (int)Position.Y + Yoffset;
            return Collider;
        }

        public static Vector2 OffsetCollider(Vector2 currentPos, int horizontalOffset, int verticalOffset)
        {
            return new Vector2(currentPos.X+horizontalOffset, currentPos.Y+verticalOffset);
        }

    }
}
