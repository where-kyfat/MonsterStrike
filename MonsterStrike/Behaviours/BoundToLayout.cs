using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterStrike.Classes;

namespace MonsterStrike.Behaviours
{
    class BoundToLayout : Behaviour
    {
        Sprite target;
        Vector2 layoutSize;
        bool IsEdge;

        public BoundToLayout(Sprite target, Vector2 layoutSize, bool IsEdge = true)
        {
            this.target = target;
            this.layoutSize = layoutSize;
            this.IsEdge = IsEdge;
        }

        public override void Execute()
        {
            if (IsEdge) BoundEdge(target, layoutSize);
            else BoundOrigin(target, layoutSize);
        }

        private void BoundEdge(Sprite target, Vector2 layoutSize)
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

        private void BoundOrigin(Sprite target, Vector2 layoutSize)
        {
            if (target.Position.X < 0) target.Position.X = 0;
            if (target.Position.Y < 0) target.Position.Y = 0;
            if (target.Position.X > layoutSize.X) target.Position.X = layoutSize.X;
            if (target.Position.Y > layoutSize.Y) target.Position.Y = layoutSize.Y;
        }
    }
}
