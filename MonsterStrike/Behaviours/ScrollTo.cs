using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterStrike.Classes;


namespace MonsterStrike.Behaviours
{
    class ScrollTo : Behaviour
    {
        Sprite target;
        Camera camera;
        Vector2 middlePoint;
        Vector2 layoutSize;

        public ScrollTo(Sprite target, Camera camera, Vector2 middlePoint, Vector2 layoutSize)
        {
            this.target = target;
            this.camera = camera;
            this.middlePoint = middlePoint;
            this.layoutSize = layoutSize;
        }

        public override void Execute()
        {
            //var middlePoint = new Vector2(windowSize.X / 2, windowSize.Y / 2);
            camera.Follow(target.Position, middlePoint, layoutSize);
            target.transformMatrix = camera.Transform;
        }
    }
}
