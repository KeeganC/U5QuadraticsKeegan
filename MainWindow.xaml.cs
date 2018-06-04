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
        double a, b, c, topP, topS, sqRtPre, sqRtPost, bottom, rootP, rootS, vertexX, vertexY, end1x, end2x, xVariable = -10.1, yVariable;
        double[,] myCells;

        public MainWindow()
        {
            InitializeComponent();
            drawGrid();

            //Create axis
            Line Xaxis = new Line();
            Xaxis.X1 = 0;
            Xaxis.Y1 = 150;
            Xaxis.X2 = 300;
            Xaxis.Y2 = 150;
            Xaxis.Stroke = Brushes.Black;
            Xaxis.StrokeThickness = 2;
            myCanvas2.Children.Add(Xaxis);
            Line Yaxis = new Line();
            Yaxis.X1 = 150;
            Yaxis.Y1 = 0;
            Yaxis.X2 = 150;
            Yaxis.Y2 = 300;
            Yaxis.Stroke = Brushes.Black;
            Yaxis.StrokeThickness = 2;
            myCanvas2.Children.Add(Yaxis);
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            //Clear old parabola
            myCanvas.Children.Clear();

            drawGrid();

            a = Convert.ToDouble(txbInputA.Text);
            b = Convert.ToDouble(txbInputB.Text);
            c = Convert.ToDouble(txbInputC.Text);

            sqRtPre = (b * b) - (4 * a * c);
            sqRtPost = Math.Sqrt(sqRtPre);
            topP = (b * (-1)) + sqRtPost;
            topS = (b * (-1)) - sqRtPost;
            bottom = 2 * a;
            rootP = topP / bottom;
            rootS = topS / bottom;

            vertexX = (rootS + rootP) / 2;
            vertexY = a * (vertexX * vertexX) + b * vertexX + c;

            // points where parabola leaves visible graph
            if (a >= 0)
            {
                sqRtPre = (b * b) - (4 * a * (c - 10));
                sqRtPost = Math.Sqrt(sqRtPre);
                topP = (b * (-1)) + sqRtPost;
                topS = (b * (-1)) - sqRtPost;
                bottom = 2 * a;
                end1x = topS / bottom;
                end2x = topP / bottom;
            }
            if (a <= -0.01)
            {
                sqRtPre = (b * b) - (4 * a * (c + 10));
                sqRtPost = Math.Sqrt(sqRtPre);
                topP = (b * (-1)) + sqRtPost;
                topS = (b * (-1)) - sqRtPost;
                bottom = 2 * a;
                end1x = topP / bottom;
                end2x = topS / bottom;
            }

            xVariable = end1x;

            txbOutput.Text = "Entered value for a: " + txbInputA.Text + "\r\nEntered value for b: " + txbInputB.Text + "\r\nEntered value for c: " + txbInputC.Text + "\r\nThe roots are " + rootP.ToString() + " and " + rootS.ToString();

            while (xVariable <= end2x)
            {
                Line line = new Line();
                line.Stroke = Brushes.Blue;

                yVariable = a * (xVariable * xVariable) + b * xVariable + c;

                line.X1 = xVariable * 15;
                line.Y1 = yVariable * -15;

                xVariable += 0.01;
                yVariable = a * (xVariable * xVariable) + b * xVariable + c;

                line.X2 = xVariable * 15;
                line.Y2 = yVariable * -15;

                myCanvas.Children.Add(line);
            }

            //reset x values
            xVariable = end1x -0.1;
        }

        private void drawGrid()
        {
            myCells = new double[20, 20];
            double offset = -1.7;
            Rectangle[,] myRectangles = new Rectangle[20, 20];

            for (int col = 0; col < myCells.GetLength(0); col++)
            {
                for (int row = 0; row < myCells.GetLength(1); row++)
                {
                    //create grid
                    myRectangles[row, col] = new Rectangle();
                    myRectangles[row, col].Stroke = Brushes.LightGray;
                    myRectangles[row, col].Fill = Brushes.White;
                    if (this.Width < this.Height)
                    {
                        myRectangles[row, col].Width = this.Width / 30 - offset;
                        myRectangles[row, col].Height = this.Width / 30 - offset;
                    }
                    else
                    {
                        myRectangles[row, col].Width = this.Height / 30 - offset;
                        myRectangles[row, col].Height = this.Height / 30 - offset;
                    }
                    myCanvas.Children.Add(myRectangles[row, col]);
                    Canvas.SetTop(myRectangles[row, col], row * myRectangles[row, col].Height - 150);
                    Canvas.SetLeft(myRectangles[row, col], col * myRectangles[row, col].Width - 150);
                    myCells[row, col] = 0;
                }
            }
        }
    }
}
