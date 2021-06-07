using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace GAMA
{
    public static class ControlEdgeRounder
    {
        public static GraphicsPath GetRoundPath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r2 = radius / 2f;

            //.........→↓.........
            //.........↑←.........

            AddTopLeftCorner(rect, path, radius);
            path.AddLine(rect.X + r2, rect.Y, rect.Width - r2, rect.Y);
            AddTopRightCorner(rect, path, radius);
            path.AddLine(rect.Width, rect.Y + r2, rect.Width, rect.Height - r2);
            AddBottomRightCorner(rect, path, radius);
            path.AddLine(rect.Width - r2, rect.Height, rect.X + r2, rect.Height);
            AddBottomLeftCorner(rect, path, radius);
            path.AddLine(rect.X, rect.Height - r2, rect.X, rect.Y + r2);

            path.CloseFigure();
            return path;
        }

        public static void RoundCorners(Control control, int radius)
        {
            RectangleF rect = control.ClientRectangle;
            GraphicsPath path = GetRoundPath(rect, radius);
            control.Region = new Region(path);
        }

        public static GraphicsPath GetCustomRoundPath(RectangleF rect, RadiusCollection radiuses)
        {
            GraphicsPath path = new GraphicsPath();
            float rTopLeft = radiuses.TopLeft / 2f;
            float rTopRight = radiuses.TopRight / 2f;
            float rBottomRight = radiuses.BottomRight / 2f;
            float rBottomLeft = radiuses.BottomLeft / 2f;

            AddTopLeftCorner(rect, path, radiuses.TopLeft);
            path.AddLine(rect.X + rTopLeft, rect.Y, rect.Width - rTopRight, rect.Y);
            AddTopRightCorner(rect, path, radiuses.TopRight);
            path.AddLine(rect.Width, rect.Y + rTopRight, rect.Width, rect.Height - rBottomRight);
            AddBottomRightCorner(rect, path, radiuses.BottomRight);
            path.AddLine(rect.Width - rBottomRight, rect.Height, rect.X + rBottomLeft, rect.Height);
            AddBottomLeftCorner(rect, path, radiuses.BottomLeft);
            path.AddLine(rect.X, rect.Height - rBottomLeft, rect.X, rect.Y + rTopLeft);

            path.CloseFigure();
            return path;
        }

        private static void AddTopLeftCorner(RectangleF rect, GraphicsPath path, int radius)
        {
            float r2 = radius / 2f;
            if (radius != 0)
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        }

        private static void AddTopRightCorner(RectangleF rect, GraphicsPath path, int radius)
        {
            float r2 = radius / 2f;
            if (radius != 0)
                path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
        }

        private static void AddBottomRightCorner(RectangleF rect, GraphicsPath path, int radius)
        {
            float r2 = radius / 2f;
            if (radius != 0)
                path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
        }

        private static void AddBottomLeftCorner(RectangleF rect, GraphicsPath path, int radius)
        {
            float r2 = radius / 2f;
            if (radius != 0)
                path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
        }
    }
}
