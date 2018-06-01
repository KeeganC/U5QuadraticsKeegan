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
        double a, b, c, topP, topS, sqRtPre, sqRtPost, bottom, rootP, rootS, vertexX, vertexY;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(txbInputA.Text);
            b = Convert.ToDouble(txbInputB.Text);
            c = Convert.ToDouble(txbInputC.Text);

            sqRtPre = (b*b)-(4*a*c);
            sqRtPost = Math.Sqrt(sqRtPre);
            topP = (b * (-1)) + sqRtPost;
            topS = (b * (-1)) - sqRtPost;
            bottom = 2 * a;
            rootP = topP / bottom;
            rootS = topS / bottom;

            vertexX = (rootS + rootP) / 2;
            vertexY = a * (vertexX * vertexX) + b * vertexX + c;

            txbOutput.Text = "Entered value for a: "+ txbInputA.Text +"\r\nEntered value for b: "+ txbInputB.Text +"\r\nEntered value for c: "+ txbInputC.Text +"\r\nThe roots are "+ rootP.ToString() + " and " + rootS.ToString();

            //draw parabola
            Path p = new Path();
            p.Stroke = Brushes.Blue;
            p.StrokeThickness = 5;
            PathGeometry pg = new PathGeometry();
            PathFigureCollection pfg = new PathFigureCollection();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(rootP*15, 0);
            pathFigure.Segments = new PathSegmentCollection();

            QuadraticBezierSegment quadraticBezierSegment = new QuadraticBezierSegment();
            quadraticBezierSegment.Point1 = new Point(vertexX*15, -(vertexY*15));
            quadraticBezierSegment.Point2 = new Point(rootS*15, 0);

            pathFigure.Segments.Add(quadraticBezierSegment);

            pfg.Add(pathFigure);
            pg.Figures = pfg;
            p.Data = pg;
            myCanvas.Children.Add(p);
        }
    }
}