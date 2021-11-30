using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
   public class MineFields
    {
       //private fields
       private Tile[,] mGrid;
       private int mRows, mColumns;
       private int mTileSize;


       //Constructors

       public MineFields(int Rows, int Columns, int TileSize)
       {
            this.mRows = Rows;
            this.mColumns = Columns;
            this.mTileSize = TileSize;
           
            mGrid = new Tile[this.mRows, this.mColumns];
           //Creates the grid
            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mColumns; j++)
                {
                    mGrid[i, j] = new Tile();
                }
            }

           //Establishes how many bombs will be put into each level
            int eBombs = 10;
            int iBombs = 40;
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    if (mGrid.GetLength(0) == 9) //if player selects the easy grid
                    {
                        if (eBombs > 0)
                        {
                            
                            eBombs--;
                            mGrid[i, j].BackgroundColour = Resource1.Bomb;
                            mGrid[i, j].Bomb = true;
                        }
                    }
                    if (mGrid.GetLength(0) == 16) //if player selects the intermediate grid
                    {
                        if (iBombs > 0)
                        {
                            
                            iBombs--;
                            mGrid[i, j].BackgroundColour = Resource1.Bomb;
                            mGrid[i, j].Bomb = true;
                        }
                    }
                }
            }

           //Randomizing the bombs on the grid
            Tile Temp = new Tile();
            Random Index = new Random();
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    int Row = Index.Next(0, mGrid.GetLength(0) - 1);
                    int Column = Index.Next(0, mGrid.GetLength(1) - 1);


                    Temp = mGrid[i, j];
                    mGrid[i, j] = mGrid[Row, Column];
                    mGrid[Row, Column] = Temp;

                }   
            }

            
           //Checks every tile and its surrounding tiles for bombs and it adds to its property
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            if (mGrid[i, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }

                        }
                        else if (j == mGrid.GetLength(1) - 1)
                        {
                            if (mGrid[i + 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }

                        }
                        else
                        {
                            if (mGrid[i, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                        }

                    }
                    else if (i == mGrid.GetLength(0) - 1)
                    {
                        if (j == 0)
                        {
                            if (mGrid[i - 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                        }
                        else if (j == mGrid.GetLength(1) - 1)
                        {
                            if (mGrid[i - 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                        }
                        else
                        {
                            if (mGrid[i - 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            if (mGrid[i - 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                        }
                        else if (j == mGrid.GetLength(1) - 1)
                        {
                            if (mGrid[i - 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }

                        }
                        else
                        {
                            if (mGrid[i - 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i - 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j - 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                            if (mGrid[i + 1, j + 1].Bomb == true)
                            {
                                mGrid[i, j].BombCount++;
                            }
                        }
                    }       
                }
            }

           //If there is no bomb on a tile, it will change its picture to whatever its bombcount is
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    if (mGrid[i, j].Bomb == false)
                    {


                        if (mGrid[i, j].BombCount == 1)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_1_svg;
                        }
                        if (mGrid[i, j].BombCount == 2)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_2_svg;
                        }
                        if (mGrid[i, j].BombCount == 3)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_3_svg;
                        }
                        if (mGrid[i, j].BombCount == 4)
                        {
                            mGrid[i, j].BackgroundColour = Resource1.Minesweeper_4_svg;
                        }
                        if (mGrid[i, j].BombCount == 5)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_5_svg;
                        }
                        if (mGrid[i, j].BombCount == 6)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_6_svg;
                        }
                        if (mGrid[i, j].BombCount == 7)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_7_svg;
                        }
                        if (mGrid[i, j].BombCount == 8)
                        {
                            mGrid[i, j].BackgroundColour = Resource1._76px_Minesweeper_8_svg;
                        }
                    }
                }
            }
       }

       //Methods

       //Gets tile location
       public Tile GetTile(int Row, int Columns)
       {
           return mGrid[Row, Columns];
       }

       //Draws the grid
       public void Draw(Graphics g, int X, int Y)
       {
           int pX = X;
           int pY = Y;

           for (int i = 0; i < this.mRows; i++)
           {

               pY = Y + (i * this.mTileSize);

               for (int j = 0; j < this.mColumns; j++)
               {
                   pX = X + (j * this.mTileSize);
                   mGrid[i, j].Draw(g, pX, pY);

               }
           }
       }    
    }
}
