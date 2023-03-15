using System;
using System.Windows.Forms;

namespace LABA3
{
    public class MyCalc2 : MyCalc1
    {
        private double _a, _b, _d;
        private double _c2 = 0;

        public new int A
        {
            set { _a = value; }
        }
        public new double B
        {
            set { _b = value; }
            get { return _b; }
        }
        public double D
        {
            set { _d = value; }
        }
        
        public double getB
        {
            get { return _b; }
        }

        public double Res
        {
            get { return _c2; }
        }
        public new void Calculate()
        {
            _c2 += (_a - _d) / (_a + _d);
        }
        
        public void CalculateAndLogResult(MyCalc2 myCalc, TextBox resultTextBox, RichTextBox logRichTextBox)
        {
            myCalc.Calculate();
            double result = Math.Round(myCalc.Result, 2);
            resultTextBox.Text = result.ToString();
            logRichTextBox.AppendText(result.ToString() + "\n");
        }
        
    }
}