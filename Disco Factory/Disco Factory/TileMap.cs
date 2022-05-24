using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Disco_Factory
{
    class TileMap
    {
        //fields
        private Tile[,] dancefloor;
        private int size = 6;
        private Dictionary<TileState, Texture2D> tiles;

        //properties
        public Tile[,] DanceFloor
        {
            get { return dancefloor; }
        }

        //constructor
        public TileMap(AssetManager assets)
        {
            dancefloor = new Tile[size, size];
            tiles = new Dictionary<TileState, Texture2D>();

            //fill tile type dictionary
            tiles.Add(TileState.Off, null);
            tiles.Add(TileState.Blue, assets.blueTile);
            tiles.Add(TileState.Purple, assets.purpleTile);
            tiles.Add(TileState.Red, assets.redTile);
            tiles.Add(TileState.Orange, assets.orangeTile);
            tiles.Add(TileState.Green, assets.greenTile);

            //fill array
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dancefloor[j, i] = new Tile(new Rectangle(140 + (j * 80), 160 + (i * 80), 
                        assets.blueTile.Width, assets.blueTile.Height));
                }
            }
        }

        public void UpdateFloor(Player player)
        {
            foreach (Tile tile in dancefloor)
            {
                tile.TilePress(player);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            //Draw tilemap at 70,80 x 2 to line up with background
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //consult the dictionary to grab the corresponding asset
                    if (tiles[dancefloor[j, i].TileColor] != null)
                    {
                        sb.Draw(
                            tiles[dancefloor[j, i].TileColor],
                            dancefloor[j, i].Rectangle,
                            Color.White);
                    }
                }
            }


            //reference is drawn at 350,120 x 2
            //done button: 350,280 x 2
            //redo button: 430,280 x 2
            //menu button: 500,15 x 2
        }
    }
}
