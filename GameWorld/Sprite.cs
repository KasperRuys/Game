using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld
{
    class Sprite
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; set; }

        protected Sprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
