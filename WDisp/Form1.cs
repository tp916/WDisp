using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WDisp
{
    public partial class Form1 : Form
    {

        Graphics g = null;
        Pen myPen;
        static int centerX;
        static int centerY;

        public Form1()
        {
            InitializeComponent();
            myPen = new Pen(Color.DarkGreen,1);
            g = splitContainerMain.Panel2.CreateGraphics();
            /*
            panelGraph.MaximumSize = new Size(500, 500);
            panelGraph.Size = new Size(500, 500);
            panelGraph.Size.Width = 200;
            */
           // panelGraph.Size = new Size(Form1.Size.Width);

            centerX = splitContainerMain.Panel2.Width / 2;
            centerY = splitContainerMain.Panel2.Height / 2;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void testGraphics()
        {
            //g.DrawEllipse(myPen, 100, 100, 50, 50);
            int CenterX = splitContainerMain.Panel2.Width / 2;
            int CenterY = splitContainerMain.Panel2.Height / 2;
            g.DrawLine(myPen, CenterX, CenterY, 200, 200);
        }


        private void drawLineByAngle(int startX, int startY, int len, double angle, int startOfset)
        {
            double radian = (angle * Math.PI) / 180;
            float stopX = (float) (len * Math.Cos(radian));
            float stopY = (float) (len * Math.Sin(radian));

            startX = (int)(startOfset * Math.Cos(radian));
            startY = (int)(startOfset * Math.Sin(radian));

            startX += centerX;
            startY += centerY;
            stopX += centerX;
            stopY += centerY;
    
            g.DrawLine(myPen, startX, startY, stopX, stopY);
    
        }


        private void drawGrid(int numbOfLines, int numbOfLeds) 
        {
             
            double angle = 0;
            for (int i = 0; i < numbOfLines; i++)
            {
                drawLineByAngle(0, 0, centerY,angle, centerY/4);
                angle += ((double)360 / numbOfLines); 
            }
    
        }


         
        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            //testGraphics();
            /*
            g.Dispose();
            g = panelGraph.CreateGraphics();
            g.Clear(Color.White);

            centerX = panelGraph.Width / 2;
            centerY = panelGraph.Height / 2;
            drawGrid(100, 10);
            */
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2.Refresh();
           
        }

        private void splitContainerMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

            g.Dispose();
            g = splitContainerMain.Panel2.CreateGraphics();
            g.Clear(Color.White);

            centerX = splitContainerMain.Panel2.Width / 2;
            centerY = splitContainerMain.Panel2.Height / 2;
            drawGrid(100, 10);


        }
    }


   
}


