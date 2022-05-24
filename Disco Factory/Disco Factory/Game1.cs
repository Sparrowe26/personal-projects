using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Disco_Factory
{
    //for gamestate FSM
    enum GameState
    {
        MainMenu,
        LevelSelect,
        Gameplay,
        Pause,
        LevelComplete
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private const int WindowWidth = 1080;
        private const int WindowHeight = 720;
        private GameState currentState;
        private TileMap danceFloor;
        private Player player;
        //keep track of current level
        private int level;

        private AssetManager assets;
        private KeyboardState kbState;
        private KeyboardState prevKbState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //window size
            _graphics.PreferredBackBufferWidth = WindowWidth;
            _graphics.PreferredBackBufferHeight = WindowHeight;
            _graphics.ApplyChanges();

            currentState = GameState.MainMenu;
            level = 1;

            assets = new AssetManager();
            kbState = new KeyboardState();
            prevKbState = new KeyboardState();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            assets.LoadContent(Content);

            danceFloor = new TileMap(assets);
            player = new Player(new Rectangle(140, 160, assets.doneButton.Width, assets.doneButton.Height), assets);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            kbState = Keyboard.GetState();

            //FSM
            switch (currentState)
            {
                case GameState.MainMenu:
                    
                    if(kbState.IsKeyUp(Keys.Space) && prevKbState.IsKeyDown(Keys.Space))
                    {
                        currentState = GameState.Gameplay;
                    }

                    break;

                case GameState.Gameplay:

                    player.Update(gameTime);
                    danceFloor.UpdateFloor(player);

                    if (kbState.IsKeyUp(Keys.Space) && prevKbState.IsKeyDown(Keys.Space))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                case GameState.LevelComplete:
                    break;

                case GameState.LevelSelect:
                    break;

                case GameState.Pause:
                    break;
            }
            prevKbState = kbState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);
            _spriteBatch.Begin();

            // FSM
            switch (currentState)
            {
                case GameState.MainMenu:
                    _spriteBatch.DrawString(assets.font, "HomeScreen", new Vector2(10, 10), Color.White);
                    break;

                case GameState.Gameplay:
                    _spriteBatch.Draw(assets.background, new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);

                    danceFloor.Draw(_spriteBatch);
                    player.Draw(_spriteBatch);
                    
                    _spriteBatch.Draw(assets.border, new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);
                    break;

                case GameState.LevelComplete:
                    break;

                case GameState.LevelSelect:
                    break;

                case GameState.Pause:
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
