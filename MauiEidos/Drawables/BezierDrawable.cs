using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiEidos.Drawables
{
    internal class BezierDrawable : IDrawable
    {
        // x10 and Y moved down
        public static List<PointF> Points = new List<PointF>
        {
            new PointF(0, 250),
            new PointF(290, 170),
            new PointF(440, 390),
            new PointF(550, 140),
            new PointF(630, 390),
            new PointF(900, 250),
            new PointF(1000, 250),
        };

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.AliceBlue;
            canvas.StrokeSize = 1;
            PathF bezierPath = new PathF();
            bezierPath.MoveTo(Points[0]);
            bezierPath.CurveTo(Points[1], Points[2], Points[3]);
            bezierPath.CurveTo(Points[4], Points[5], Points[6]);
            canvas.DrawPath(bezierPath);
        }
    }
}
