using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GamePractice
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D black;
        private Texture2D red;
        private MouseState oldState;
        int playerTurn = 1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Images/connect4");
            black = Content.Load<Texture2D>("Images/blackchip");
            red = Content.Load<Texture2D>("Images/redchip");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();

            
            int x = mouseState.X;
            int y = mouseState.Y;

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                if (x >= 200)
                {
                    Mouse.SetPosition(0, 0);
                }
            }

            oldState = newState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();


            spriteBatch.Draw(black, new Vector2(118, 237), Color.White);
            spriteBatch.Draw(red, new Vector2(430, 250), Color.White);
            spriteBatch.Draw(background, new Rectangle(80, 130, 600, 360), Color.White);
            
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
