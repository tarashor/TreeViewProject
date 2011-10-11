using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TreeControls
{
    public class CustomRendered :UIElement
    {
        static CustomRendered()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRendered), new FrameworkPropertyMetadata(typeof(CustomRendered)));
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawEllipse(Brushes.Green, new Pen(Brushes.Gold, 3), new Point(0, 0), 50, 80);
        }
    }
}
