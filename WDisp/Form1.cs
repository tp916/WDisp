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
        Boolean bMouseDown;
        private def_led_line lastLedCoordinante;
        private int activColor;

        public Form1()
        {
            InitializeComponent();
            numbOfLeds = 32;
            numbOfLines = 100;
            myPen = new Pen(Color.DarkGreen,1);
            g = splitContainerMain.Panel2.CreateGraphics();
        

            centerX = splitContainerMain.Panel2.Width / 2;
            centerY = splitContainerMain.Panel2.Height / 2;
            activColor = 1;
            buttonColor1.FlatAppearance.BorderSize = 3;
            buttonColor2.FlatAppearance.BorderSize = 1;
            buttonColor3.FlatAppearance.BorderSize = 1;

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
            int startingOfset = 10;// centerY / 4;
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
            ledWidth = (int)gridOfsetR;  //???????????????????????????????????
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

       
           
            
            drawGrid(numbOfLines, numbOfLeds);
            drawPolarPicture();
            //testGraphics();
        }

        private void drawPolarPicture()
        {
            for (int i = 0; i < numbOfLines; i++)
            {
                for (int j = 0; j < numbOfLeds; j++)
                {
                    int ledState = lineModel.getLed(i, j);
                    if (ledState != 0)
                    {
                        colourLedPoint(i, j, getColorFromState(ledState), false);
                    }
                }
            }
        }

        private void colourLedPoint(int lineNumb, int ledNumb, Color pointColor, Boolean refreshGrid)
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
            if (refreshGrid == true)
            {
                drawLineByAngle(0, 0, centerY/*!!!*/, angle, gridStartingOfset);
                drawLineByAngle(0, 0, centerY/*!!!*/, angle + gridAngle, gridStartingOfset);
                r -= gridOfsetR / 2;
                drawCircle(0, 0, (int)r);
                drawCircle(0, 0, (int)(r + gridOfsetR));
            }


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

            if ((locX <= 0))  ///>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> zweryfikowac
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
        }

        private Color getColorFromState(int ledState)
        {
            switch (ledState)
            {
                case 0:
                default:
                    {
                        return Color.White;
                    }
                    break;
                case 1:
                    {
                        return Color.Yellow;
                    }
                    break;
                case 2:
                    {
                        return Color.Green;
                    }
                    break;
            }
        }

        private Color getActivColor()
        {
            return getColorFromState(activColor);         
        }

        private void splitContainerMain_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            int x,y;
            def_led_line LedCoord = new def_led_line();

            x = (e.X - centerX) * (1);
            y = (e.Y - centerY) * (1);


            labelDebug1.Text = x.ToString() + "," + y.ToString();

            //---------------------

            if(bMouseDown == true)
            {
                LedCoord = getLedFromXY(e.X, e.Y);

                if ( (LedCoord.LedNo != -1) || (LedCoord.LineNo != -1))
                {
                    if( (lastLedCoordinante.LedNo != LedCoord.LedNo) || (lastLedCoordinante.LineNo != LedCoord.LineNo) )
                    {
                        lineModel.setLed(LedCoord.LineNo, LedCoord.LedNo, activColor);
                        colourLedPoint(LedCoord.LineNo, LedCoord.LedNo, getActivColor(),true);
                    }

                }

                lastLedCoordinante = LedCoord; 
            }

        }

        private void splitContainerMain_Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDown = true;

            def_led_line LedCoord = getLedFromXY(e.X, e.Y);
                                 
            if ((LedCoord.LedNo != -1) && (LedCoord.LineNo != -1))
            {
                lineModel.setLed(LedCoord.LineNo, LedCoord.LedNo, activColor);
                colourLedPoint(LedCoord.LineNo, LedCoord.LedNo, getActivColor(),true);
            }
            lastLedCoordinante = LedCoord;
            //DebugOut(lineModel.dispTable());

        }

        private void splitContainerMain_Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDown = false;
        }

        private void buttonColor1_Click(object sender, EventArgs e)
        {
            activColor = 0;

            buttonColor1.FlatAppearance.BorderSize = 3;
            buttonColor2.FlatAppearance.BorderSize = 1;
            buttonColor3.FlatAppearance.BorderSize = 1;
        }

        private void buttonColor2_Click(object sender, EventArgs e)
        {
            activColor = 1;

            buttonColor1.FlatAppearance.BorderSize = 1;
            buttonColor2.FlatAppearance.BorderSize = 3;
            buttonColor3.FlatAppearance.BorderSize = 1;
        }

        private void buttonColor3_Click(object sender, EventArgs e)
        {
            activColor = 2;

            buttonColor1.FlatAppearance.BorderSize = 1;
            buttonColor2.FlatAppearance.BorderSize = 1;
            buttonColor3.FlatAppearance.BorderSize = 3;
            
        }

        private void buttonBmp_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;


            if(openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            { return; }

            bmp = new Bitmap(openFileDialog1.FileName);

            //kontrola wielkosci


            //----------------------

            
            for (int i = 0; i < numbOfLines; i++)
            {
               
                
            }

           
            for (int lineNo = 0; lineNo < numbOfLines; lineNo++)
            {
                for(int ledNo = 0; ledNo < numbOfLeds; ledNo++)
                {
                    int r = ledNo + 1;
                    double angle = (gridAngle * lineNo * Math.PI) / 180;

                    int x = 32 + (int)(Math.Round(r * Math.Cos(angle)));
                    int y = 32 - (int)(Math.Round(r * Math.Sin(angle)));

                    if(x > 63)
                    { x = 63; }

                    if (y > 63)
                    { y = 63; }

                    
                    if (bmp.GetPixel(x, y) == Color.FromArgb(0, 0, 0))
                    {
                        lineModel.setLed(lineNo, ledNo, activColor);
                    }
                    
                }
                //angle += gridAngle;
            }
                           

             
            

            if(bmp != null)
            { bmp.Dispose(); }



        }
    }
    
  
   
}


