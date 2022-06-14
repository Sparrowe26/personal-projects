using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Disco_Factory
{
    //for tracking the state of tiles
    enum TileState
    {
        Off,
        Blue,
        Purple,
        Red,
        Orange,
        Green,
    }
    class Tile
    {
        //fields
        private TileState tileColor;
        private bool isPressed;
        private Rectangle rectangle;
        private int size = 80;

        //properties
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public TileState TileColor
        {
            get { return tileColor; }
            set { tileColor = value; }
        }

        public int Size
        {
            get { return size; }
        }

        //constructor
        public Tile(Rectangle rectangle)
        {
            tileColor = TileState.Off;

            this.rectangle = rectangle;
        }

        /// <summary>
        /// Increments the tile's color if the player is on top of it
        /// </summary>
        /// <param name="player"></param>
        public void TilePress(Player player)
        {
            //check if the player is touching the center of the tile
            if (player.Position.Contains(this.Rectangle.Center))
            {
                //increment the tile color if it hasn't already
                if (tileColor == TileState.Green && isPressed == false)
                {
                    tileColor = TileState.Off;
                }
                else if (isPressed == false)
                {
                    tileColor++;
                }

                //so it only happens once
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }
    }
}
