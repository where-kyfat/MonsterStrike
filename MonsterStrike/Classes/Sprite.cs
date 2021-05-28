using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterStrike.Behaviours;

namespace MonsterStrike.Classes
{
    public class Sprite
    {
        public Texture2D Texture;
        private Rectangle DestinationRectangle;
        public Color Color = Color.White;
        public float Rotation;
        public Vector2 Origin;
        public float Scale = 1;
        public SpriteEffects SpriteEffects;
        public float LayerDepth;
        public Matrix transformMatrix;
        public Vector2 Position;
        public float _forwardAngle = 0f;
        public bool IsRemove = false;

        public List<Behaviour> Behaviours;

        public Vector2 transformPosition
        {
            get
            {
                var res = Position;
                res.X = transformMatrix.M41 + Position.X;
                res.Y = transformMatrix.M42 + Position.Y;

                return res;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public Sprite(Texture2D Texture, Vector2 Position)
        {
            this.Texture = Texture;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            this.Position = Position;
            DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            Behaviours = new List<Behaviour>();
        }

        public Sprite(Sprite copy)
        {
            this.Texture = copy.Texture;
            this.DestinationRectangle = copy.DestinationRectangle;
            this.Color = copy.Color;
            this.Rotation = copy.Rotation;
            this.Origin = copy.Origin;
            this.Scale = copy.Scale;
            this.SpriteEffects = copy.SpriteEffects;
            this.LayerDepth = copy.LayerDepth;
            this.transformMatrix = copy.transformMatrix;
            this.Position = copy.Position;
            this._forwardAngle = copy._forwardAngle;
            this.Behaviours = copy.Behaviours;
        }

        public void Update()  
        {
            foreach (var behaviour in Behaviours)
            {
                behaviour.Execute();
            }
        }

        private void UpdateDestinationRectangle()
        {
            DestinationRectangle.X = (int)Position.X;
            DestinationRectangle.Y = (int)Position.Y;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Scale != 1)
            {
                spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            }
            else
            {
                UpdateDestinationRectangle();
                spriteBatch.Draw(Texture, DestinationRectangle, null, Color, Rotation, Origin, SpriteEffects, LayerDepth);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(Texture, position, null, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
