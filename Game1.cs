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
        private SpriteFont font;
        private SpriteFont winFont;
        bool gameRunning = true;
        int playerTurn;
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
            playerTurn = 1;
            board = new int[8][];
            for(int i = 0; i < 8; i++) 
            {
                board[i] = new int[7];
            }


            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Player Turn");
            winFont = Content.Load<SpriteFont>("Win Font");
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
            KeyboardState state = Keyboard.GetState();

            int mouseX = mouseState.X;

            if (gameRunning)
            {
                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    if (mouseX >= 138 && mouseX <= 212)
                    {

                        if (playerTurn == 1 && board[0][0] < 6)
                        {
                            board[0][0] += 1;
                            board[0][board[0][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[0][0] < 6)
                        {
                            board[0][0] += 1;
                            board[0][board[0][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }

                    }

                    if (mouseX >= 213 && mouseX <= 287)
                    {
                        if (playerTurn == 1 && board[1][0] < 6)
                        {
                            board[1][0] += 1;
                            board[1][board[1][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[1][0] < 6)
                        {
                            board[1][0] += 1;
                            board[1][board[1][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }
                    }

                    if (mouseX >= 288 && mouseX <= 362)
                    {
                        if (playerTurn == 1 && board[2][0] < 6)
                        {
                            board[2][0] += 1;
                            board[2][board[2][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[2][0] < 6)
                        {
                            board[2][0] += 1;
                            board[2][board[2][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }
                    }

                    if (mouseX >= 363 && mouseX <= 437)
                    {
                        if (playerTurn == 1 && board[3][0] < 6)
                        {
                            board[3][0] += 1;
                            board[3][board[3][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[3][0] < 6)
                        {
                            board[3][0] += 1;
                            board[3][board[3][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }
                    }

                    if (mouseX >= 438 && mouseX <= 512)
                    {
                        if (playerTurn == 1 && board[4][0] < 6)
                        {
                            board[4][0] += 1;
                            board[4][board[4][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[4][0] < 6)
                        {
                            board[4][0] += 1;
                            board[4][board[4][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }
                    }

                    if (mouseX >= 513 && mouseX <= 587)
                    {
                        if (playerTurn == 1 && board[5][0] < 6)
                        {
                            board[5][0] += 1;
                            board[5][board[5][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[5][0] < 6)
                        {
                            board[5][0] += 1;
                            board[5][board[5][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }
                    }

                    if (mouseX >= 588 && mouseX <= 662)
                    {
                        if (playerTurn == 1 && board[6][0] < 6)
                        {
                            board[6][0] += 1;
                            board[6][board[6][0]] = 1;
                            DetectWin();
                            playerTurn = 2;
                        }

                        else if (playerTurn == 2 && board[6][0] < 6)
                        {
                            board[6][0] += 1;
                            board[6][board[6][0]] = 2;
                            DetectWin();
                            playerTurn = 1;
                        }
                    }
                }
            }
            
            //Reset Function
            if (gameRunning == false && state.IsKeyDown(Keys.Enter))
            {
                for (int i = 0; i <= 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        board[i][j] = 0;
                    }
                }
                playerTurn = 1;
                gameRunning = true;
            }
            oldState = newState;
            
                base.Update(gameTime);            
        }  

        private void DetectWin()
        {
            if (gameRunning)
            {
                //Vertical Detection
                for (int i = 0; i <= 6; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (board[i][j] == playerTurn && board[i][j + 1] == playerTurn && board[i][j + 2] == playerTurn && board[i][j + 3] == playerTurn)
                        {
                            gameRunning = false;
                        }
                    }
                }

                //Horizontal Detection
                for (int j = 1; j <= 4; j++)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (board[i][j] == playerTurn && board[i + 1][j] == playerTurn && board[i + 2][j] == playerTurn && board[i + 3][j] == playerTurn)
                        {
                            gameRunning = false;
                        }


                    }
                }

                //Diagonal Detection (Right)
                for (int j = 1; j <= 3; j++)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (board[i][j] == playerTurn && board[i + 1][j + 1] == playerTurn && board[i + 2][j + 2] == playerTurn && board[i + 3][j + 3] == playerTurn)
                        {
                            gameRunning = false;
                        }
                    }
                }

                //Diagonal Detection (Left)
                for (int j = 1; j <= 3; j++)
                {
                    for (int i = 3; i <= 6; i++)
                    {
                        if (board[i][j] == playerTurn && board[i - 1][j + 1] == playerTurn && board[i - 2][j + 2] == playerTurn && board[i - 3][j + 3] == playerTurn)
                        {
                            gameRunning = false;
                        }
                    }
                }
            }            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();
            if (gameRunning)
            {
                if (playerTurn == 1)
                {
                    spriteBatch.DrawString(font, "Player " + playerTurn + "'s turn", new Vector2(275, 70), Color.Red);
                }

                else if (playerTurn == 2)
                {
                    spriteBatch.DrawString(font, "Player " + playerTurn + "'s turn", new Vector2(275, 70), Color.Black);
                }

                for (int x = 0; x < 7; x++)
                {
                    for (int y = 1; y < 7; y++)
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
            }
            
            if (gameRunning == false)
            {
                if (playerTurn == 1)
                {
                    GraphicsDevice.Clear(Color.Black);
                    spriteBatch.DrawString(winFont, "Player " + playerTurn + " wins", new Vector2(250, 90), Color.Red);
                    spriteBatch.DrawString(winFont, "Press enter to play again", new Vector2(150, 260), Color.Red);
                }
                if (playerTurn == 2)
                {
                    GraphicsDevice.Clear(Color.Red);
                    spriteBatch.DrawString(winFont, "Player " + playerTurn + " wins", new Vector2(250, 90), Color.Black);
                    spriteBatch.DrawString(winFont, "Hit enter to play again", new Vector2(150, 260), Color.Black);
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
