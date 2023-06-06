using Microsoft.Maui.Controls.Shapes;

namespace MauiEidos;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        RedrawBezier();
    }

    public void RedrawBezier()
    {
        var graphicsView = this.BezierGraphicsView;
        graphicsView.Invalidate();
    }
}

