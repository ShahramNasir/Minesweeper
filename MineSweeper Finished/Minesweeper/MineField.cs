using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
   public class Tile
    {
       //Setting variables 
       private int mSize;
       private Bitmap mBackgroundColour;
       private Bitmap mForegroundColour;
       private bool mBomb;
       private int mBombCount;
       private bool mClick;
       private bool mFlag;
       private bool mQuest;
       
       //Constructors
       public Tile()
       {
           this.mSize = 30;
           this.mBackgroundColour = Resource1._76px_Minesweeper_0_svg;
           this.mForegroundColour = Resource1._76px_Minesweeper_unopened_square_svg;

           
       }
       
       public Tile(int Size, Bitmap BackgroundColour, Color BorderColour)
       {
           this.mSize = Size;
           this.mBackgroundColour = BackgroundColour;
           this.mForegroundColour = ForegroundColour;

       }

       //Methods 
       public void Draw(Graphics g, int X, int Y)
       {
           //will draw a cell on graphics object
           //x and y represent the location of 
           //top left corner of the cell

           //create a pen and a brush to draw with
          
           TextureBrush BackBrush = new TextureBrush(this.mForegroundColour);

           //draw cell
           g.FillRectangle(BackBrush, X, Y - 30, this.mSize, this.mSize);
            

           //dispose of drawing objects
           BackBrush.Dispose();

       }

       //Properties
       public int Size
        {
            set { this.mSize = value; }
            get { return this.mSize; }
        }

        public Bitmap BackgroundColour
        {
            set { this.mBackgroundColour = value; }
            get { return this.mBackgroundColour; }

        }

        public Bitmap ForegroundColour
        {
            set { this.mForegroundColour = value; }
            get { return this.mForegroundColour; }

        }
       
        public bool Bomb
        {
            set { this.mBomb = value; }
            get { return this.mBomb; }

        }
        
        public bool Click
        {
            set { this.mClick = value; }
            get { return this.mClick; }

        }

        public bool Flag
        {
            set { this.mFlag = value; }
            get { return this.mFlag; }

        }

        public bool Quest
        {
            set { this.mQuest = value; }
            get { return this.mQuest; }

        }

        public int BombCount
        {
            set { this.mBombCount = value; }
            get { return this.mBombCount; }
        }

    }
}
