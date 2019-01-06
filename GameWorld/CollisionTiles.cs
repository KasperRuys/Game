using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld
{
    class CollisionTiles : Tiles
    {
        public CollisionTiles(int tileId, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Tile" + tileId);
           
            this.Rectangle = newRectangle;
            
        }
    }
}
