using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public enum Movement { MoveRight, MoveLeft, Idle, Jump }
    public enum PossibleAnimations { RunRight, RunLeft, IdleRight, IdleLeft, AttackRight, AttackLeft, JumpLeft, JumpRight }
    public enum States { Jumping, Idling, Falling}

    public class Hero : IGameObject, ITransform, IAnimateable
    {
        public static States State = States.Idling;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Movement MoveDirection;
        public Animator Animator { get; set; }
        public PossibleAnimations AnimToPlay { get; set; }


        public IInputReader KeyboardReader;
        public MoveCommand MoveCommand;
        public JumpCommand JumpCommand;
        public AnimateCommand AnimateCommand;

        private int runSpeed = 3;
        private Animation currentAnimation;
        private int jumpSpeed = 5;
        private int jumpHeight = 150;

        // Colliders
        public BoxCollider Collider { get; set; }
        int Xoffset = 60;
        int Yoffset = 45;


        public Hero()
        {
            // Startposition
            Position = new Vector2(100, 250);

            // TODO: dependency-injection
            Animator = new HeroAnimator();
            KeyboardReader = new KeyboardReader();
            MoveCommand = new MoveCommand(runSpeed);
            JumpCommand = new JumpCommand(jumpSpeed, jumpHeight, Position.Y);
            AnimateCommand = new AnimateCommand();

            // Add animations that need to be used
            Animator.Animations.Add(new NormalAnimation("Hero-Idle-Right", "Hero/Normal/Idle", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Idle-Left", "Hero/Mirrored/Idle-MIRRORED", 8, 150));
            Animator.Animations.Add(new NormalAnimation("Hero-Run-Right", "Hero/Normal/Run", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Run-Left", "Hero/Mirrored/Run-MIRRORED", 8, 150));
            Animator.Animations.Add(new NormalAnimation("Hero-Jump-Right", "Hero/Normal/Jump", 2, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Jump-Left", "Hero/Mirrored/Jump-MIRRORED", 2, 150));

            // Initialize animations
            Animator.InitializeAnimations();

            // Set start animation
            currentAnimation = Animator.Animations[0];

            // Collision
            Collider = new BoxCollider(Position, "Hero-Collider", 30, 50, Xoffset, Yoffset);
        }

        public void Update(GameTime gameTime)
        {
            // Read input
            MoveDirection = KeyboardReader.ReadInput();

            // Jumping
            JumpCommand.CheckJumping();
            JumpCommand.Execute(this);

            // Move character
            Direction = MoveCommand.Execute(this, MoveDirection);


            // Update collider
            Collider = CollisionManager.UpdateCollider(Position, Collider, Xoffset, Yoffset);

            // Choose animation according to direction
            AnimateCommand.Execute(this, MoveDirection);

            // Animate accordingly
            currentAnimation = Animator.Animate(AnimToPlay);

            Animator.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.SpriteSheet, Position, currentAnimation.CurrentFrame.sourceRectangle, Color.White);

        }
    }
}