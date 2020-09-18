using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class BasicGame: Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Texture2D player1, player2;
    Texture2D background;
    Vector2 player1Positie, player2Positie;
    KeyboardState currentKeyboard;

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
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        player1 = Content.Load<Texture2D>("blauweSpelerBig");
        player2 = Content.Load<Texture2D>("rodeSpelerBig");
        background = Content.Load<Texture2D>("pongBackground");
    }

    protected override void Update(GameTime gameTime)
    {       
        currentKeyboard = Keyboard.GetState();

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
    }

    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(background, Vector2.Zero, Color.White);
        spriteBatch.Draw(player1, player1Positie, Color.White);
        spriteBatch.Draw(player2, player2Positie, Color.White);
        spriteBatch.End();
    }
}