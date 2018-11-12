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
    public struct def_led_line
    {
       public int LineNo;
       public int LedNo;

       /* public def_led_line()
        {
            LineNo = -1;
            LedNo = -1;
        }
        */
    };

    public partial class Form1 : Form
    {

        Graphics g = null;
        Pen myPen;
        static int centerX;
        static int centerY;
        static int ledWidth;
        static double gridAngle;
        static float gridOfsetR;
        static int gridStartingOfset;
        static int numbOfLeds;
        static int numbOfLines;
        LineModel lineModel;

        public Form1()
        {
            InitializeComponent();
            numbOfLeds = 32;
            numbOfLines = 100;
            myPen = new Pen(Color.DarkGreen,2);
            g = splitContainerMain.Panel2.CreateGraphics();
        

            centerX = splitContainerMain.Panel2.Width / 2;
            centerY = splitContainerMain.Panel2.Height / 2;

       
            lineModel = new LineModel(numbOfLines,numbOfLeds);
            
            DebugOut(lineModel.dispTable());

            lineModel.line[1].led[1] = 1;
            DebugOut("---\r\n");
            DebugOut(lineModel.dispTable());
        }


        private void DebugOut(string s)
        {
            TextBoxDebug.Text += s;
            TextBoxDebug.Text += "\r\n";
            TextBoxDebug.SelectionStart = TextBoxDebug.Text.Length;
            TextBoxDebug.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void testGraphics()
        {
            //g.DrawEllipse(myPen, 100, 100, 50, 50);
            //int CenterX = splitContainerMain.Panel2.Width / 2;
            //int CenterY = splitContainerMain.Panel2.Height / 2;

            drawCircle(0, 0, 100);
            //g.DrawLine(myPen, CenterX, CenterY, 200, 200);
            // g.FillPolygon()

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

        private void drawCircle(int centrXloc, int centrYloc, int R)
        {
            centrXloc += centerX;
            centrYloc += centerY;
            g.DrawEllipse(myPen, centrXloc - R , centrYloc - R , 2 * R, 2 * R);
            
        }

        private void drawArcByAngle(int centrXloc, int centrYloc, int R, float startAngle, float stopAngle)
        {
            float  angleStartRadian = (float) ((startAngle * Math.PI) / 180);
            float sweepAngle = ((float)((stopAngle * Math.PI) / 180)) - angleStartRadian;
            

            angleStartRadian = startAngle;

            sweepAngle = stopAngle - startAngle;


            centrXloc += centerX;
            centrYloc += centerY;
            g.DrawArc(myPen, centrXloc - R, centrYloc - R, 2 * R, 2 * R, angleStartRadian, sweepAngle);
            //g.DrawEllipse(myPen, centrXloc - R, centrYloc - R, 2 * R, 2 * R);
        }




        private void drawGrid(int numbOfLines, int numbOfLeds) 
        {
            int startingOfset =  centerY / 4;
            int lenght = centerY;


            gridStartingOfset = startingOfset;
            gridAngle = ((double)360 / numbOfLines);


            double angle = 0;
            for (int i = 0; i < numbOfLines; i++)
            {
                drawLineByAngle(0, 0, lenght,angle, startingOfset);
                angle += gridAngle; 
            }


            float R = startingOfset;
            //float offset = ((float)(lenght - startingOfset)) / (numbOfLeds);
            gridOfsetR = ((float)(lenght - startingOfset)) / (numbOfLeds);


            for (int i = 0; i < numbOfLeds + 1;i++)
            {
                // g.DrawEllipse(myPen, centerX, centerY, 100 + 10*i, 100 + 10 * i);
                drawCircle(0, 0,(int) R);
                R += gridOfsetR;
            }

            //myPen.Width = gridOfsetR;
            ledWidth = (int)gridOfsetR;
            /*
            ledWidth = (int)gridOfsetR;
            myPen.Width = gridOfsetR;
            myPen.Color = Color.Red;
            drawArcByAngle(0, 0, (int) (R - 1.5* gridOfsetR), 0, (float) 20);
            myPen.Width = 1;
            myPen.Color = Color.Green;
            */
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

       
            drawGrid(numbOfLines,numbOfLeds);
            
            //testGraphics();
        }

        private void colourLedPoint(int lineNumb, int ledNumb, Color pointColor)
        {
           double r = ledNumb * gridOfsetR;
           r += gridStartingOfset + gridOfsetR / 2;

           double angle = lineNumb * gridAngle;

            //----------------
           Color bufColor = myPen.Color;
           float bufWidth = myPen.Width;
            //wypelnienie obszaru
           myPen.Color = pointColor;
           myPen.Width = ledWidth;
           drawArcByAngle(0, 0, (int)r, (float)angle, (float)(angle + gridAngle));

           myPen.Color = bufColor;
           myPen.Width = bufWidth;
           
           //oswiezenie siatki
           drawLineByAngle(0, 0, centerY/*!!!*/, angle, gridStartingOfset);
           drawLineByAngle(0, 0, centerY/*!!!*/, angle + gridAngle, gridStartingOfset);
           r -= gridOfsetR / 2;
           drawCircle(0, 0, (int)r);
           drawCircle(0, 0, (int)(r + gridOfsetR));


        }
        //------------------------------------------------
        private  def_led_line getLedFromXY(int X, int Y)
        {
            def_led_line retVal;// = new def_led_line();

            retVal.LedNo = -1;
            retVal.LineNo = -1;

            int locX = (X - centerX) * (1);
            int locY = (Y - centerY) * (1);

            double r = Math.Sqrt(locX * locX + locY * locY) /*+  0.5 * ledWidth*/;
            if ((r < gridStartingOfset) || (r > (gridStartingOfset + (numbOfLeds * gridOfsetR))))
            { return retVal; }

            double angle = Math.Atan(((double)locY) / ((double)locX));

            angle = (180 * angle) / Math.PI;

            if ((locX < 0))
            { angle += 180; }

            if ((locX > 0) && (locY < 0))
            { angle += 360; }

            //------------------
            int ledNo = (int)((r - gridStartingOfset) / gridOfsetR);
            int lineNo = (int)(angle / gridAngle);
            DebugOut("ledNo =" + ledNo.ToString() + " lineNo = " + lineNo.ToString() + "\r\n");

            retVal.LedNo = ledNo;
            retVal.LineNo = lineNo;
                       
            return retVal; 

        }
        //-------------------------------------------------
        private void splitContainerMain_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            def_led_line LedCoord = getLedFromXY(e.X, e.Y);

           
            if ((LedCoord.LedNo != -1) && (LedCoord.LineNo != -1))
            {

                if (lineModel.getLed(LedCoord.LineNo, LedCoord.LedNo) == 0)
                {
                    lineModel.setLed(LedCoord.LineNo, LedCoord.LedNo, (int)1);
                    colourLedPoint(LedCoord.LineNo, LedCoord.LedNo, Color.Orange);
                }
                else
                {
                    lineModel.setLed(LedCoord.LineNo, LedCoord.LedNo, (int)0);
                    colourLedPoint(LedCoord.LineNo, LedCoord.LedNo, Color.White);
                }
            }
         

            DebugOut(lineModel.dispTable());             

        }

        private void splitContainerMain_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            int x,y;

            x = (e.X - centerX) * (1);
            y = (e.Y - centerY) * (1);


            labelDebug1.Text = x.ToString() + "," + y.ToString();
           
        }

        
    }
    
   // 2pi - 360 
    //rad - st

      //  st = 180rag/pi
   
}


