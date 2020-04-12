using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    class Stepen: ParseBase // класс-наследник, выполняющий вычисление степени
    {
        public override string Expression { get ; set ; }
        public override string Result { get; set ; }
        public Stepen(string _expression)
        {
            Expression = _expression;
            ExpressionСalculations();
        }

        public override void ExpressionСalculations()
        {
            string b = ""; int i1 = 0; int v = 0; double res = 0;
            string temp = ""; string bir = "";
            string str = "";

            v = Expression.Length;
            for (int i = i1; i < v; i++)
            {
                switch (Expression[i])
                {
                    case '^':
                        {
                            bir = Chisla(Expression.Substring(i + 1));
                            temp = str + "^" + bir;
                            res = Math.Pow(Number(str + "!"), Number(bir + "!"));
                            res = Math.Round(res, 2);
                            str = Convert.ToString(res);
                            Expression = Expression.Replace(temp, str);
                            v = Expression.Length;
                            i = -1;
                        }
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        {
                            b = Expression.Substring(i);
                            i = Num(b, i);
                            str = Chisla(b);
                        }
                        break;
                    case '+':
                    case '-':
                    case (char)0x221A:
                    case 's':
                    case 'i':
                    case 'n':
                    case 'c':
                    case 'o':
                        break;
                    default:
                        i = v - 1;
                        break;
                }
            }
            Koren kor = new Koren(Expression);
            Result = kor.Result;
        }
       
    }
}
