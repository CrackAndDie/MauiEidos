using MauiEidos.Drawables;
using Microsoft.Maui.Controls.Shapes;

namespace MauiEidos;

public partial class MainPage : ContentPage
{
    private Ellipse draggingElement = null;
    private List<Ellipse> ellipses = new List<Ellipse>();

    public MainPage()
    {
        InitializeComponent();

        InitializeCursedCanvas(1000, 500);
        InitializeEllipse(290, 170, 10, Colors.Green);
        InitializeEllipse(440, 390, 10, Colors.Green);
        InitializeEllipse(550, 140, 10, Colors.Green);
        InitializeEllipse(630, 390, 10, Colors.Green);
        InitializeEllipse(900, 250, 10, Colors.Green);

        RedrawBezier();
    }

    public void RedrawBezier()
    {
        var graphicsView = this.BezierGraphicsView;
        graphicsView.Invalidate();
    }

    private void InitializeCursedCanvas(int columns, int rows)
    {
        for (int column = 0; column < columns; column++)
        {
            CanvasGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int row = 0; row < rows; row++)
        {
            CanvasGrid.RowDefinitions.Add(new RowDefinition());
        }

        for (int column = 0; column < columns; column += 10)
        {
            for (int row = 0; row < rows; row += 10)
            {
                var cell = new StackLayout() { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Transparent };
                var dropGesture = new DropGestureRecognizer() { AllowDrop = true };
                dropGesture.Drop += (s, e) =>
                {
                    var gr = s as GestureRecognizer;
                    int x = Grid.GetColumn(gr.Parent as StackLayout);
                    int y = Grid.GetRow(gr.Parent as StackLayout);
                    Grid.SetColumn(draggingElement, x);
                    Grid.SetRow(draggingElement, y);

                    var p = new PointF(x, y);
                    BezierDrawable.Points[ellipses.IndexOf(draggingElement) + 1] = p;

                    RedrawBezier();
                };
                cell.GestureRecognizers.Add(dropGesture);
                Grid.SetColumn(cell, column);
                Grid.SetRow(cell, row);
                Grid.SetColumnSpan(cell, 10);
                Grid.SetRowSpan(cell, 10);
                CanvasGrid.Children.Add(cell);
            }
        }
    }

    private void InitializeEllipse(int x, int y, int size, Color color)
    {
        var point = new Ellipse() { Fill = color, HeightRequest = size, WidthRequest = size };
        ellipses.Add(point);
        var dragGesture = new DragGestureRecognizer();
        dragGesture.DragStarting += (s, e) =>
        {
            draggingElement = (s as GestureRecognizer).Parent as Ellipse;
        };
        point.GestureRecognizers.Add(dragGesture);
        Grid.SetColumn(point, x);
        Grid.SetRow(point, y);
        CanvasGrid.Children.Add(point);

    }
}

