using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project7;
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D charTexture;
    private Texture2D ballTexture;
    Vector2 charPosition = new Vector2(0, 250);
    private int frame;
    private float totalElapsed;
    private float timePerFrame;
    private int framePerSec;
    private int direction;

    Ball ball1 = new Ball();
    Ball ball2 = new Ball();
    Ball ball3 = new Ball();
    Ball ball4 = new Ball();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        charTexture = Content.Load<Texture2D>("Char01");
        ballTexture = Content.Load<Texture2D>("ball");
        framePerSec = 2;
        timePerFrame = (float)1 / framePerSec;
        frame = 0;
        direction = 0;
        totalElapsed = 0;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        GraphicsDevice device = _graphics.GraphicsDevice;
        KeyboardState keyboard = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        if (keyboard.IsKeyDown(Keys.S))
        {
            direction = 0;
            charPosition.Y = charPosition.Y + 4;
        }
        if (keyboard.IsKeyDown(Keys.A))
        {
            direction = 1;
            charPosition.X = charPosition.X - 4;
        }
        if (keyboard.IsKeyDown(Keys.D))
        {
            direction = 2;
            charPosition.X = charPosition.X + 4;
        }
        if (keyboard.IsKeyDown(Keys.W))
        {
            direction = 3;
            charPosition.Y = charPosition.Y - 4;
        }

        ball1.intersectCheck((int)charPosition.X,
            (int)charPosition.Y, 32, 48);
        ball2.intersectCheck((int)charPosition.X,
            (int)charPosition.Y, 32, 48);
        ball3.intersectCheck((int)charPosition.X,
            (int)charPosition.Y, 32, 48);
        ball4.intersectCheck((int)charPosition.X,
            (int)charPosition.Y, 32, 48);


        UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(ballTexture, ball1.ballPosistion, new Rectangle
            (ball1.colorNumber * 24, 0, 24, 24), Color.White);
        _spriteBatch.Draw(ballTexture, ball2.ballPosistion, new Rectangle
            (ball2.colorNumber * 24, 0, 24, 24), Color.White);
        _spriteBatch.Draw(ballTexture, ball3.ballPosistion, new Rectangle
            (ball3.colorNumber * 24, 0, 24, 24), Color.White);
        _spriteBatch.Draw(ballTexture, ball4.ballPosistion, new Rectangle
            (ball4.colorNumber * 24, 0, 24, 24), Color.White);
        _spriteBatch.Draw(charTexture, charPosition, new Rectangle(frame * 32, direction * 48, 32, 48),
            Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    void UpdateFrame(float elapsed)
    {
        totalElapsed += elapsed;
        if (totalElapsed > timePerFrame)
        {
            frame = (frame + 1) % 4;
            totalElapsed -= timePerFrame;
        }
    }
}
