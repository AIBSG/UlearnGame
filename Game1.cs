using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MagicBalls;

public class Game1 : Game
{
    public static GraphicsDeviceManager GraphicsDM;
    public static SpriteBatch SpriteBatch;
    public static Texture2D GroundTexture;
    public static Texture2D Pointer;
    public static Texture2D DoorDown;
    public static Texture2D DoorUp;
    public static Texture2D DoorLeft;
    public static Texture2D DoorRight;
    private static Rectangle _startFieldElementLocation; 
    public static Room NowRoom;

    public Game1()
    {
        GraphicsDM = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        GraphicsDM.IsFullScreen = false;
        GraphicsDM.PreferredBackBufferWidth = 1280;
        GraphicsDM.PreferredBackBufferHeight = 980;
        _startFieldElementLocation = new (100, 100, 70, 70);
        GraphicsDM.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        GroundTexture = Content.Load<Texture2D>("ground");
        Pointer = Content.Load<Texture2D>("pointer");
        DoorDown = Content.Load<Texture2D>("doorDown");
        DoorLeft = Content.Load<Texture2D>("doorLeft");
        DoorRight = Content.Load<Texture2D>("doorRight");
        DoorUp = Content.Load<Texture2D>("doorUp");


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        NowRoom = Levels.TestRoom;
        NowRoom = Room.ChangeRoom(Mouse.GetState(), NowRoom);
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        //FieldElement.PointToField(Mouse.GetState(),_fe);

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
       GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin();
        Room.DrawRoom(NowRoom,_startFieldElementLocation);
        
        SpriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}