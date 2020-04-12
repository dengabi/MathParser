using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    abstract class ParseBase // базовый класс для определения свойст и методов наследников, а так же имеющий общие для всех классов методы 
    {
       
        public abstract string Expression {get; set;}
        public abstract string Result { get; set; }
        public abstract void ExpressionСalculations();

        public int Num(string a, int i)//функция увеличения счётчика
        {
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] == 0x221A)
                    return i = i - 1;
                else if (Char.IsDigit(a[j]) || a[j] == ',')
                    i = i + 1;
                else return i = i - 1;
            }
            return i = i - 1;
        }

        public string Chisla(string a)//функция разбора числа
        {
            string str = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0x221A)
                    return str;
                else if (Char.IsDigit(a[i]) || a[i] == ',')
                    str = str + a[i];
                else return str;
            }
            return str;
        }

        public double Number(string a)//функция конвентирования числа
        {
            string str = "";
            double res = 0;
            int i1 = 0;
            if (a[0] == '-')
            {
                str = str + "-";
                i1++;
            }
            for (int i = i1; i < a.Length; i++)
            {
                if (a[i] == 0x221A)
                {
                    res = Convert.ToDouble(str);
                    res = Math.Round(res, 7);
                    return res;
                }
                else if (Char.IsDigit(a[i]) || a[i] == ',')
                    str = str + a[i];
                else
                {
                    res = Convert.ToDouble(str);
                    res = Math.Round(res, 5);
                    return res;
                }
            }
            return res;
        }
       

    }
}
