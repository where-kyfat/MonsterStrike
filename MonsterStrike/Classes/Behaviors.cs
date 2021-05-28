using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonsterStrike.Classes
{
    static class Behaviors
    {
        public static void _8Directions(Sprite target, float speed = 4)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                target.Position.Y -= speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                target.Position.Y += speed;

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                target.Position.X -= speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                target.Position.X += speed;
        }

        public static void _4Directions(Sprite target, float speed = 4)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                target.Position.Y -= speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                target.Position.Y += speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                target.Position.X -= speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                target.Position.X += speed;
        }

        public static void LRDirections(Sprite target, float speed = 4)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                target.Position.X -= speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                target.Position.X += speed;
        }

        public static void UDDirections(Sprite target, float speed = 4)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                target.Position.Y -= speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                target.Position.Y += speed;
        }

        public static void ScrollTo(Sprite target, Camera camera, Vector2 middlePoint, Vector2 layoutSize)
        {
            //var middlePoint = new Vector2(windowSize.X / 2, windowSize.Y / 2);
            camera.Follow(target.Position, middlePoint, layoutSize);
            target.transformMatrix = camera.Transform;
        }

        public static void BoundToLayout(Sprite target, Vector2 layoutSize, bool IsEdge = true)
        {
            if (IsEdge) BoundEdge(target, layoutSize);
            else BoundOrigin(target, layoutSize);
        }

        private static void BoundEdge(Sprite target, Vector2 layoutSize)
        {
            var Left = target.Texture.Bounds.Right / 2 * target.Scale;
            var Right = target.Texture.Bounds.Right / 2 * target.Scale;
            var Bottom = target.Texture.Bounds.Bottom / 2 * target.Scale;
            var Top = target.Texture.Bounds.Bottom / 2 * target.Scale;

            if (target.Position.X < Left) target.Position.X = Left;
            if (target.Position.Y < Top) target.Position.Y = Top;
            if (target.Position.X > layoutSize.X - Bottom) target.Position.X = layoutSize.X - Bottom;
            if (target.Position.Y > layoutSize.Y - Right) target.Position.Y = layoutSize.Y - Right;
        }

        private static void BoundOrigin(Sprite target, Vector2 layoutSize)
        {
            if (target.Position.X < 0) target.Position.X = 0;
            if (target.Position.Y < 0) target.Position.Y = 0;
            if (target.Position.X > layoutSize.X) target.Position.X = layoutSize.X;
            if (target.Position.Y > layoutSize.Y) target.Position.Y = layoutSize.Y;
        }

        public static void BulletMovement(Sprite target, float speed = 5f, int angleDegrees = 0)
        {
            var Direction = new Vector2((float)Math.Cos(target.Rotation), (float)Math.Sin(target.Rotation));
            target.Position += Direction * speed;
        }

        public static void BulletMovement(List<Sprite> targets, float speed = 5f, int angleDegress = 0)
        {
            foreach (var target in targets)
            {
                BulletMovement(target, speed, angleDegress);
            }
        }
    }
}
