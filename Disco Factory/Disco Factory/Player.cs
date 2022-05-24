using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Disco_Factory
{
    class Player
    {
        //fields
        private int speed = 3;
        private Rectangle position;
        private AssetManager assets;

        //properties
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        //constructor
        public Player(Rectangle position, AssetManager assets)
        {
            this.position = position;
            this.assets = assets;
        }

        public void Update(GameTime gameTime)
        {
            //create KeyboardState object for user input
            KeyboardState kbState = Keyboard.GetState();

            //move rectangle up
            if (kbState.IsKeyDown(Keys.Up))
            {
                position.Y -= speed;
            }
            //moves rectangle left
            if (kbState.IsKeyDown(Keys.Left))
            {
                position.X -= speed;
            }
            //moves rectangle down
            if (kbState.IsKeyDown(Keys.Down))
            {
                position.Y += speed;
            }
            //moves rectangle right
            if (kbState.IsKeyDown(Keys.Right))
            {
                position.X += speed;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(assets.doneButton, Position, Color.White);
        }
    }
}
