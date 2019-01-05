using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld
{
    class Enemy
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;
        Vector2 origin;
        Vector2 velocity;

        float rotation = 0f;

        bool right;
        float distance;
        float oldDistance;

        public Enemy (Texture2D newTexture, Vector2 newPosition, float newDistance)
        {
            texture = newTexture;
            position = newPosition;
            distance = newDistance;

            oldDistance = distance;
        }
        float playerDistance;
        public void Update(Player player)
        {
            
            position += velocity;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            if (distance <= 0)
            {
                right = true;
                velocity.X = 1f;
            }
            else if (distance <= oldDistance)
            {
                right = false;
                velocity.X = -1f;
            }
            if(right)
            {
                distance += 1; 
            }
            else
            {
                distance -= 1;
            }


            
            playerDistance = player.Position.X - position.X;

            if (playerDistance >= -200 && playerDistance <= 200)
            {
                if (playerDistance < -1)
                {
                    velocity.X = -1f;
                }
                else if (playerDistance >= 1)
                {
                    velocity.X = 1f; 
                }
                else if (playerDistance == 0)
                {
                    velocity.X = 0f;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
            {
                spriteBatch.Draw(texture, position, null, Color.Red, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);

            }
            else
            {
                spriteBatch.Draw(texture, position, null, Color.Red, rotation, origin, 1f, SpriteEffects.None, 0f);

            }
        }
    }
}
