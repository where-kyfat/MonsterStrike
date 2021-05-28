using System;
using System.Collections.Generic;
using System.Text;
using MonsterStrike.Classes;
using MonsterStrike.Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonsterStrike
{
    // Create sprites logic section--------------------------------------------------
    class Player: Sprite
    {
        public Player(Texture2D texture, Vector2 position, Camera camera, Vector2 middlePoint, Vector2 layoutSize) : base(texture, position) 
        {
            Behaviours.Add(new _8Directions(this));
            Behaviours.Add(new ScrollTo(this, camera, middlePoint, layoutSize));
            Behaviours.Add(new BoundToLayout(this, layoutSize));
        }  
    }

    class Bullet : Sprite
    {
        public Bullet(Texture2D texture, Vector2 position, Vector2 layoutSize) : base(texture, position)
        {
            Behaviours.Add(new BulletMovement(this, 10));
            Behaviours.Add(new DestroyOutSideLayout(this, layoutSize));
        }
    }

    class Monster : Sprite
    {
        public Monster(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Behaviours.Add(new BulletMovement(this, 3));
        }
    }

    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

    class MonsterStrike: ConstructorGame
    {
        //Textures
        private Texture2D playerTexture;
        private Texture2D bulletTexture;
        private Texture2D monsterTexture;

        // Player values initialize
        private Sprite _player;

        protected override void Initialize()
        {
            _windowSize = new Vector2(1920, 1080);
            _backgroundSize = new Vector2(3840, 2160);

            base.Initialize();

            _player = new Player(playerTexture, new Vector2(10, 10), _camera, _middleScreen, _backgroundSize)
            {
                _forwardAngle = (float)Math.PI
            };
            sprites.Add(_player);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _layout = LoadTextrure("Sprites/TiledBackground");
            bulletTexture = LoadTextrure("Sprites/bullet");
            monsterTexture = LoadTextrure("Sprites/monster");
            playerTexture = LoadTextrure("Sprites/player");
        }

        protected override void Update(GameTime gameTime)
        {
            // Events-----------------------------------------------------------------

            // Player rotates to Mouse
            if (Conditions.EveryTick()) Actions.SetAngleForward(_player, Mouse.GetState().X, Mouse.GetState().Y, false);

            // Create new Bullet when Mouse.LeftButton clicked
            if (Conditions.OnMouseXButtonClicked(Conditions.MouseButton.Left, gameTime))
            {
                var newBullet = new Bullet(bulletTexture, _player.Position, _backgroundSize) { Rotation = _player.Rotation };
                sprites.Add(newBullet);
            }

            // Every 3 seconds create new Monster 
            if (Conditions.EveryXSeconds(gameTime, 3f))
            {
                var newMonster = new Monster(monsterTexture, new Vector2(1400, random.Next(1024))) { Rotation = (float)Math.PI };
                sprites.Add(newMonster);
            }


            for (int i = 0; i < sprites.Count; i++)
            {
                // If any Bullet collides with any Monster -> remove this Bullet and this Monster
                if (sprites[i] is Bullet)
                {
                    for (int monsterIndex = 0; monsterIndex < sprites.Count; monsterIndex++)
                    {
                        if (sprites[monsterIndex] is Monster)
                        {
                            if (Conditions.InCollisionWith(sprites[i], sprites[monsterIndex]))
                            {
                                sprites[i].IsRemove = true;
                                sprites[monsterIndex].IsRemove = true;
                                break;
                            }
                        }
                    }
                }

                // If Monster is out side layout -> rotate to Players position
                // If Monster collides with Player -> remove Player
                if (sprites[i] is Monster)
                {
                    if (Conditions.IsOutsideLayout(sprites[i], _backgroundSize))
                    {
                        Actions.SetAngleForward(sprites[i], _player.Position.X, _player.Position.Y, true);
                    }
                    if (Conditions.InCollisionWith(sprites[i], _player))
                    {
                        _player.IsRemove = true;
                    }
                }
            }

            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            base.Update(gameTime);
        }
    }
}