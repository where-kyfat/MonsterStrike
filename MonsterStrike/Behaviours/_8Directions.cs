using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterStrike.Classes;

namespace MonsterStrike.Behaviours
{
    class _8Directions : Behaviour
    {
        Sprite _target;
        float _speed;

        public _8Directions(Sprite target, float speed = 4)
        {
            _target = target;
            _speed = speed;
        }
        public override void Execute()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                _target.Position.Y -= _speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                _target.Position.Y += _speed;

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                _target.Position.X -= _speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                _target.Position.X += _speed;
        }
    }
}
