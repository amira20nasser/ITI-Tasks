using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab08WinForms
{
    public partial class DrawingForm : Form
    {
        public DrawingForm()
        {
            InitializeComponent();
        }
    
        private void DrawingForm_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine();
        }

        bool mouseDown = false;
        Point location;
        private void DrawingForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            location = e.Location;
            Pen myPen = new Pen(Color.Blue, 5);

            Graphics g = this.CreateGraphics();
            g.DrawRectangle(myPen, new Rectangle(location.X, location.Y, 50, 100));
            //g.DrawRectangle(myPen, new Rectangle(location,));
        }

        private void DrawingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {

                Graphics g = this.CreateGraphics();
                Pen myPen = new Pen(Color.Blue,5);

               


                //Point location2 = e.Location;
                //g.DrawLine(myPen, location, location2);
                //location = e.Location;
            }
        }

        private void DrawingForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
