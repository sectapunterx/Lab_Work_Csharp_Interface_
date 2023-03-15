using System;

namespace LABA3
{
    public class MyCalc1
    {
        private int _a = 0;
        private double _b;
        private double _result;

        public int A
        {
            set { _a = value; }
        }
        
        public double B
        {
            get { return _b; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Значение b не может быть равно нулю");
                }
                _b = value;
            }
        }
        

        public double Result
        {
            get { return _result; }
        }

        public double Calculate()
        {
            _result = (_a - _b) / (_a - 2);
            return _result;
        }
    }
}