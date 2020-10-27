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
        int i;
        private int x;
        private int y;
        int playerTurn = 1;
        int[][] board;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            board = new int[8][];
            for(i = 0; i < 8; i++) 
            {
                board[i] = new int[7];
            }


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

            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                if (mouseX >= 138 && mouseX <= 212)
                {
                    if (playerTurn == 1 && board[0][0] < 8)
                    {
                        board[0][0] += 1;
                        board[0][board[0][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[0][0] < 8)
                    {
                        board[0][0] += 1;
                        board[0][board[0][0]] = 2;
                        playerTurn = 1;
                    }
                    
                }

                if (mouseX >= 213 && mouseX <= 287)
                {
                    if (playerTurn == 1 && board[1][0] < 8)
                    {
                        board[1][0] += 1;
                        board[1][board[1][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[1][0] < 8)
                    {
                        board[1][0] += 1;
                        board[1][board[1][0]] = 2;
                        playerTurn = 1;
                    }
                }

                if (mouseX >= 288 && mouseX <= 362)
                {
                    if (playerTurn == 1 && board[2][0] < 8)
                    {
                        board[2][0] += 1;
                        board[2][board[2][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[2][0] < 8)
                    {
                        board[2][0] += 1;
                        board[2][board[2][0]] = 2;
                        playerTurn = 1;
                    }
                }

                if (mouseX >= 363 && mouseX <= 437)
                {
                    if (playerTurn == 1 && board[3][0] < 8)
                    {
                        board[3][0] += 1;
                        board[3][board[3][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[3][0] < 8)
                    {
                        board[3][0] += 1;
                        board[3][board[3][0]] = 2;
                        playerTurn = 1;
                    }
                }

                if (mouseX >= 438 && mouseX <= 512)
                {
                    if (playerTurn == 1 && board[4][0] < 8)
                    {
                        board[4][0] += 1;
                        board[4][board[4][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[4][0] < 8)
                    {
                        board[4][0] += 1;
                        board[4][board[4][0]] = 2;
                        playerTurn = 1;
                    }
                }

                if (mouseX >= 513 && mouseX <= 587)
                {
                    if (playerTurn == 1 && board[5][0] < 8)
                    {
                        board[5][0] += 1;
                        board[5][board[5][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[5][0] < 8)
                    {
                        board[5][0] += 1;
                        board[5][board[5][0]] = 2;
                        playerTurn = 1;
                    }
                }

                if (mouseX >= 588 && mouseX <= 662)
                {
                    if (playerTurn == 1 && board[6][0] < 8)
                    {
                        board[6][0] += 1;
                        board[6][board[6][0]] = 1;
                        playerTurn = 2;
                    }

                    else if (playerTurn == 2 && board[6][0] < 8)
                    {
                        board[6][0] += 1;
                        board[6][board[6][0]] = 2;
                        playerTurn = 1;
                    }
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

            for (x = 0; x < 7; x++)
            {
                for (y = 1; y < 7; y++)
                {
                    if (board[x][y] == 1)
                    {
                        spriteBatch.Draw(red, new Vector2(x * 74 + 138, 466 - (y * 56)), Color.White);
                    }

                    if (board[x][y] == 2)
                    {
                        spriteBatch.Draw(black, new Vector2(x * 74 + 138, 466 - (y * 56)), Color.White);
                    }
                }
            }
            
            spriteBatch.Draw(background, new Rectangle(100, 130, 600, 360), Color.White);
            
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
