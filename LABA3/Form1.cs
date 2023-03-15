using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LABA3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private int _a;
        private double _b;
        private double _result;

        private int _a1;
        private double _b1;
        private double _d;
        
        private readonly MyCalc1 _myClass = new MyCalc1();
        private readonly MyCalc2 _myCalc2 = new MyCalc2();
        
        private const int HistorySize = 10;
        private double[,] _history = new double[HistorySize, 3];
        private int _historyIndex = 0;
        private int _historyCount = 0;
        private const int K = 10;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int result))
            {
                //MessageBox.Show("Введите целочисленное значение в поле A!");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(textBox1.Text, out int a))
                {
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("Ошибка ввода параметра A!");
                    textBox1.Focus();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out double result))
            {
                //MessageBox.Show("Введите числовое значение в поле B!");
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    if (int.TryParse(textBox2.Text, out int b))
                    {
                        button1_Click(sender, e);
                        textBox3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода параметра B!");
                        textBox2.Focus();
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            if (!int.TryParse(t, out _a))
            {
                MessageBox.Show("Ошибка ввода параметра A!");
                textBox1.Focus();
            }
            else
            {
                _myClass.A = _a;
            }

            t = textBox2.Text;
            if (!double.TryParse(t, out _b))
            {
                MessageBox.Show("Ошибка ввода параметра B!");
                textBox2.Focus();
            }
            else
            {
                _myClass.B = _b;
                //MessageBox.Show("Параметр b считан и не равен 0.");
            }

            _result = _myClass.Calculate();
            _history[_historyIndex, 0] = _a;
            _history[_historyIndex, 1] = _b;
            _history[_historyIndex, 2] = _result;

            // Обновляем текстовые поля с результатами и историей вычислений
            UpdateHistory(_result, _a, _b);

            // Увеличиваем индекс текущей записи в истории
            _historyIndex = (_historyIndex + 1) % HistorySize;
            textBox3.Text = _myClass.Result.ToString("0.000");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _myClass.B = 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Внимание! " + exception.Message);
            }
        }
        
        private void UpdateHistory(double result, int a, double b)
        {
            // Очищаем поле с историей
            richTextBox2.Clear();

            // Выводим заголовок истории
            richTextBox2.AppendText("Номер\tA\tB\tРезультат\n");

            // Выводим записи из истории
            for (int i = 0; i < HistorySize; i++)
            {
                int index = i % HistorySize;

                if (_history[index, 2] != 0)
                {
                    string line = $"{i + 1}\t{_history[index, 0]}\t{_history[index, 1]}\t{_history[index, 2]:0.000}";
                    if (_history[index, 2] == result && _history[index, 0] == a && _history[index, 1] == b)
                    {
                        line += " (текущий результат)";
                    }
                    richTextBox2.AppendText(line + "\n");
                }
            }
        }
        
        private void richTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Получаем номер строки, на которую кликнули два раза
            int lineIndex = richTextBox2.GetLineFromCharIndex(richTextBox2.SelectionStart);

            // Проверяем, что строка с таким номером существует
            if (lineIndex >= 0 && lineIndex < richTextBox2.Lines.Length)
            {
                // Получаем пользовательский атрибут строки, который содержит индекс записи в массиве _history
                int historyIndex;
                if (int.TryParse(richTextBox2.Lines[lineIndex].Split('\t')[0], out historyIndex))
                {
                    // Получаем данные из массива _history по индексу записи
                    double a = _history[historyIndex - 1, 0];
                    double b = _history[historyIndex - 1, 1];
                    double result = _history[historyIndex - 1, 2];

                    // Выводим данные в поля ввода и вывода
                    textBox9.Text = a.ToString();
                    textBox10.Text = b.ToString();
                    textBox11.Text = result.ToString("0.000");
                }
            }
        }



        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        /*private double GetPreviousResult(int index)
        {
            if (_currentHistoryIndex < index)
            {
                throw new IndexOutOfRangeException("История результатов не содержит достаточного количества элементов.");
            }

            return _resultsHistory[_currentHistoryIndex - index];
        }*/
        
        
        
        //--------------------------------------------TASK 3------------------------------------------------------------------

        
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    button3_Click(sender, e);
                    textBox7.Focus();
                }
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            string t = textBox4.Text;
            if (!int.TryParse(t, out _a1))
            {
                MessageBox.Show("Ошибка ввода параметра A! (Task 2)");
                textBox4.Focus();
            }
            else
            {
                _myCalc2.A = _a1;
            }
            t = textBox5.Text;
            if (!double.TryParse(t, out _b1))
            {
                MessageBox.Show("Ошибка ввода параметра B! (Task 2)");
                textBox5.Focus();
            }
            else
            {
                _myCalc2.B = _b1;
                //MessageBox.Show("Параметр b считан и равен "  + _b1 +  ". (Task 2)");
            }
            t = textBox6.Text;
            if (!double.TryParse(t, out _d))
            {
                MessageBox.Show("Ошибка ввода параметра D! (Task 2)");
                textBox6.Focus();
            }
            else
            {
                _myCalc2.D = _d;
            }

            for (double i = 1; i <= _myCalc2.B; i++)
            {
                _myCalc2.Calculate();
                richTextBox1.Text += i + ". "+ _myCalc2.Res.ToString("0.000") + "\n";
                textBox7.Text = _myCalc2.Res.ToString("0.000");
            }
            
            
        }
    }
}