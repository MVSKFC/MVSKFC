using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSprites
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        SpriteManager spriteManager;
        GameStarManager Button_control;
        MouseState ms = Mouse.GetState();

        enum GameState {Star, InGame, GameOver };
        GameState currentGameState = GameState.Star;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteManager = new SpriteManager(this);
            Button_control = new GameStarManager(this);
            Components.Add(spriteManager);
            Components.Add(Button_control);
            spriteManager.Enabled = false;
            spriteManager.Visible = false;
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>(@"Images/background");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            switch (currentGameState)
            {
                case GameState.Star:
                    break;
                case GameState.InGame:
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        {
                            currentGameState = GameState.GameOver;
                            spriteManager.Enabled = false;
                            spriteManager.Visible = false;                            
                        }
                    }
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameState.Star:
                    {
                        
                    }
                    break;
                case GameState.InGame:
                    {
                        spriteBatch.Begin();
                        //GraphicsDevice.Clear(Color.White);
                        spriteBatch.Draw(background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height)
                            , null, Color.White);
                        spriteBatch.End();
                    }
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
            base.Draw(gameTime);

        }
    }
}