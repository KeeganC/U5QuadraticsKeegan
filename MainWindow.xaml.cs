/*
 * Keegan Chan
 * U5QuadraticsKeegan
 * May 31, 2018
 * Factors a quadratic formula
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Create the path with the geometry
            Path p = new Path();
            p.Stroke = Brushes.Red;
            p.StrokeThickness = 15;
            PathGeometry pg = new PathGeometry();
            PathFigureCollection pfg = new PathFigureCollection();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(10, 100);
            pathFigure.Segments = new PathSegmentCollection();

            QuadraticBezierSegment quadraticBezierSegment = new QuadraticBezierSegment();
            quadraticBezierSegment.Point1 = new Point(150, 500);
            quadraticBezierSegment.Point2 = new Point(700, 100);
            //everything gets put together
            pathFigure.Segments.Add(quadraticBezierSegment);
            pfg.Add(pathFigure);
            pg.Figures = pfg;
            p.Data = pg;
            //add it to the canvas - xaml has a Canvas with the x:Name canvas
            canvas.Children.Add(p);

        }
    }
}