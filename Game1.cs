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
        private Texture2D shuttle;
        private Texture2D earth;
        private SpriteFont font;
        private Texture2D arrow;
        private float angle = 0;
        private int score = 0;
        private int x_coord = 450;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Images/stars");
            shuttle = Content.Load<Texture2D>("Images/shuttle");
            earth = Content.Load<Texture2D>("Images/earth");
            font = Content.Load<SpriteFont>("Score");
            arrow = Content.Load<Texture2D>("arrow");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //score++;
            angle += 0.01f;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                x_coord -= 2;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                x_coord += 2;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            spriteBatch.Draw(shuttle, new Vector2(x_coord, 240), Color.White);
            //spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.White);

            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height);


            spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
