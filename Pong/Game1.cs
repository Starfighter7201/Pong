using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class BasicGame: Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Texture2D player1, player2, bal;
    Texture2D background;
    Vector2 player1Positie, player2Positie, balPositie, balSnelheid;
    KeyboardState currentKeyboard;
    bool moving = false;

    [STAThread]
    static void Main()
    {
        BasicGame game = new BasicGame();
        game.Run();
    }

    public BasicGame()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = 1920;
        graphics.PreferredBackBufferHeight = 1080;
        graphics.IsFullScreen = true;
        graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        player1Positie = new Vector2(0, 468);
        player2Positie = new Vector2(1896, 468);
        balPositie = new Vector2(948, 528);
        balSnelheid = new Vector2(4, 4);       
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        player1 = Content.Load<Texture2D>("blauweSpelerBig");
        player2 = Content.Load<Texture2D>("rodeSpelerBig");
        background = Content.Load<Texture2D>("pongBackground");
        bal = Content.Load<Texture2D>("bigBal");
    }

    protected override void Update(GameTime gameTime)
    {       
        currentKeyboard = Keyboard.GetState();
        Rectangle player1Bounds = player1.Bounds;
        Rectangle player2Bounds = player2.Bounds;
        Rectangle balBounds = bal.Bounds;

        if (currentKeyboard.IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        if (currentKeyboard.IsKeyDown(Keys.W))
        { 
            player1Positie.Y -= 5;
        } 
        else if (currentKeyboard.IsKeyDown(Keys.S))
        {
            player1Positie.Y += 5;
        }

        if (currentKeyboard.IsKeyDown(Keys.Up))
        {
            player2Positie.Y -= 5;
        }
        else if (currentKeyboard.IsKeyDown(Keys.Down))
        {
            player2Positie.Y += 5;
        }
        
        if (player1Positie.Y < 0)
        {
            player1Positie.Y = 0;
        }
        else if (player1Positie.Y > 936)
        {
            player1Positie.Y = 936;
        }

        if (player2Positie.Y < 0)
        {
            player2Positie.Y = 0;
        }
        else if (player2Positie.Y > 936)
        {
            player2Positie.Y = 936;
        }

        if (moving == true)
        {
            if (balPositie.Y <= 0)
            {
                balSnelheid.Y *= -1;
            }
            if (balPositie.Y >= 1056)
            {
                balSnelheid.Y *= -1;
            }
            balPositie += balSnelheid;
        }
        else if (currentKeyboard.IsKeyDown(Keys.Space))
        {
            moving = true;
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(background, Vector2.Zero, Color.White);
        spriteBatch.Draw(player1, player1Positie, Color.White);
        spriteBatch.Draw(player2, player2Positie, Color.White);
        spriteBatch.Draw(bal, balPositie, Color.White);
        spriteBatch.End();
    }
}