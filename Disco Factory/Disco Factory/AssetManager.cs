using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Disco_Factory
{
    class AssetManager
    {
        //assets
        public Texture2D blueTile;
        public Texture2D purpleTile;
        public Texture2D redTile;
        public Texture2D orangeTile;
        public Texture2D greenTile;
        public Texture2D background;
        public Texture2D border;
        public Texture2D menuButton;
        public Texture2D doneButton;
        public Texture2D doneButtonPressed;
        public Texture2D redoButton;
        public Texture2D redoButtonPressed;
        public SpriteFont font;

        //animation fields
        private int frame;
        private double timeCounter;
        private double fps;
        private double timePerFrame;
        private int frameCount;
        private int frameHeight;
        private int frameWidth;

        public AssetManager() { }

        /// <summary>
        /// Loads all game assets
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            //load all assets in here
            blueTile = content.Load<Texture2D>("blueTile");
            purpleTile = content.Load<Texture2D>("purpleTile");
            redTile = content.Load<Texture2D>("redTile");
            orangeTile = content.Load<Texture2D>("orangeTile");
            greenTile = content.Load<Texture2D>("greenTile");
            background = content.Load<Texture2D>("factory");
            border = content.Load<Texture2D>("border");
            menuButton = content.Load<Texture2D>("menuButton");
            doneButton = content.Load<Texture2D>("doneButton");
            doneButtonPressed = content.Load<Texture2D>("doneButtonPressed");
            redoButton = content.Load<Texture2D>("redoButton");
            redoButtonPressed = content.Load<Texture2D>("redoButtonPressed");
            font = content.Load<SpriteFont>("font");
        }
    }
}
