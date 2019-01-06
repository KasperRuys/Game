using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameWorld
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera camera;
        Map level;
        List<Spike> spikes;
        Enemy enemy;

        //Map map;
        Player player;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            level = new Map();
            player = new Player();
            enemy = new Enemy();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            //enemy = new Enemy(Content.Load<Texture2D>("Player"), new Vector2(900, 100),150);
        
            Tiles.Content = Content;
            Texture2D blokText = Content.Load<Texture2D>("Tile1");
            camera = new Camera(GraphicsDevice.Viewport);

            level.Level2();
            /*map.Generate(new int[,]{
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,1,2,2,0,1,0,0,0,0,0,0,0},
                { 0,1,1,0,0,1,2,2,2,0,0,0,0,0,0,0,0,0},
                { 1,2,2,3,3,2,2,2,2,2,2,2,3,2,1,3,2,1},
               
            }, 64);*/

            /*  level = new Map();
              level.texture = blokText;
              level.CreateWorld();*/
            enemy.Load(Content);
            player.Load(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            enemy.Update(gameTime, player);
            foreach (CollisionTiles tile in level.CollisionTiles)
            {
                player.Collision(tile.Rectangle, level.Width, level.Height, enemy);
                camera.Update(player.Position, level.Width, level.Height);
                enemy.Collision(tile.Rectangle, level.Width, level.Height);
                
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,camera.Transform);
            
            enemy.Draw(spriteBatch);
            level.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
