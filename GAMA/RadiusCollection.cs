using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class RadiusCollection
    {
        // -----------------------------↓Fields↓-----------------------------
        int _topLeft;
        int _topRight;
        int _bottomRight;
        int _bottomLeft;
        // -----------------------------↓Properties↓-----------------------------
        public int TopLeft
        {
            get { return _topLeft; }
            set
            {
                _topLeft = value;
                PropertyChanged?.Invoke(this, new EventArgs());
            }
        }
        public int TopRight
        {
            get { return _topRight; }
            set
            {
                _topRight = value;
                PropertyChanged?.Invoke(this, new EventArgs());
            }
        }
        public int BottomRight
        {
            get { return _bottomRight; }
            set
            {
                _bottomRight = value;
                PropertyChanged?.Invoke(this, new EventArgs());
            }
        }
        public int BottomLeft
        {
            get { return _bottomLeft; }
            set
            {
                _bottomLeft = value;
                PropertyChanged?.Invoke(this, new EventArgs());
            }
        }
        // -----------------------------↓Functions↓-----------------------------
        public RadiusCollection(int topLeft, int topRight, int bottomRight, int bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
        public RadiusCollection()
        {
            TopLeft = 0;
            TopRight = 0;
            BottomRight = 0;
            BottomLeft = 0;
        }
        // -----------------------------↓Events↓-----------------------------
        public event EventHandler PropertyChanged;
    }
}
