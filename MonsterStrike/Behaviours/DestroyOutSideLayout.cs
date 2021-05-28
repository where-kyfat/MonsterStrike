using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterStrike.Classes;

namespace MonsterStrike.Behaviours
{
    class DestroyOutSideLayout : Behaviour
    {
        Sprite target;
        Vector2 layoutSize;

        public DestroyOutSideLayout(Sprite target, Vector2 layoutSize) 
        {
            this.target = target;
            this.layoutSize = layoutSize;
        }

        public override void Execute()
        {
            if (Conditions.IsOutsideLayout(target, layoutSize))
            {
                target.IsRemove = true;
            }
        }
    }
}
