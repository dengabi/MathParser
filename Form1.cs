using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserMath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += String.Format("{0}", Convert.ToChar(0x221A));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sin";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text += "cos";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^";
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            SearchError er = new SearchError(textBox1.Text); //запускаем проверку выражения на наличие ошибок
            if (String.Equals(er.Result, "Без ошибок!")) //проверяем выражение на наличие ошибок
            {
                ParsingExpression pars = new ParsingExpression(textBox1.Text); //выполняем разбор математического выражения               
                if (pars.Result == "100000000000000") //проверка есть ли деление на ноль
                {
                    textBox2.Text = "Невозможно делить на ноль!"; // если деление на ноль было, выводим подсказку
                }
                else textBox2.Text = pars.Result; // если всё выполнилось успешно показываем результат в окне
            }
            else textBox2.Text = er.Result; // если были ошибки в строке выражения выводим подсказку какая именно ошибка

            

        }

    }
}
