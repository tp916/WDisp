using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WDisp
{
    class Line
    {
        public int[] led;
        public Line(int numbOfLeds)
        {
            led = new int[numbOfLeds];
        }
        
    }

    class LineModel
    {

        public Line[] line;

        public LineModel(int numbOfLines, int numbOfLeds)
        {

            line = new Line[numbOfLines];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = new Line(numbOfLeds);
            }
        }

        public string dispTable()
        {
            string sOut = "";

            for (int i = 0; i < line.Length; i++)
            {
                sOut += i.ToString("##") + ". ";
                for (int j = 0; j < line[i].led.Length; j++)
                {
                    sOut += line[i].led[j].ToString() + " ";
                }
                sOut += "\r\n";
            }
            sOut += "-----------\r\n";
            return sOut;
        }

        public void setLed(int lineNo, int ledNo, int state)
        {
            line[lineNo].led[ledNo] = state;
        }
        public int getLed(int lineNo, int ledNo)
        {
            return line[lineNo].led[ledNo];
        }


    }
}
