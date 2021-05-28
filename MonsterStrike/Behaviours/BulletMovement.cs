using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterStrike.Classes;

namespace MonsterStrike.Behaviours
{
    class BulletMovement : Behaviour
    {
        Sprite target;
        float speed;
        int angleDegrees;

        public BulletMovement(Sprite target, float speed = 5f, int angleDegrees = 0)
        {
            this.target = target;
            this.speed = speed;
            this.angleDegrees = angleDegrees;
        }

        public override void Execute()
        {
            var Direction = new Vector2((float)Math.Cos(target.Rotation), (float)Math.Sin(target.Rotation));
            target.Position += Direction * speed;
        }
    }
}
