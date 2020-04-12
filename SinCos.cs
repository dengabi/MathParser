using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    class SinCos: ParseBase // класс-наследник, выполняющий вычисление синуса и косинуса
    {
        public override string Expression { get ; set; }
        public override string Result { get ; set ; }
        public SinCos(string _expression)
        {
            Expression = _expression;
            ExpressionСalculations();
        }

        public override void ExpressionСalculations()
        {
            string b = ""; int i1 = 0; int v = 0; double res = 0;
            string temp = ""; string bir = "";
            string str = ""; string minus = "-";

            v = Expression.Length;
            for (int i = i1; i < v; i++)
            {
                switch (Expression[i])
                {
                    case 's':
                        {
                            if (Expression[i + 3] == '-')
                            {
                                bir = Chisla(Expression.Substring(i + 4));
                                temp = "sin" + minus + bir;
                                bir = minus + bir;

                            }
                            else
                            {
                                bir = Chisla(Expression.Substring(i + 3));
                                temp = "sin" + bir;
                            }
                            res = Math.Sin(Number(bir + "!"));
                            res = Math.Round(res, 4);
                            str = Convert.ToString(res);
                            Expression = Expression.Replace(temp, str);
                            v = Expression.Length;
                            i = -1;
                        }
                        break;
                    case 'c':
                        {
                            if (Expression[i + 1] == 'o')
                            {
                                if (Expression[i + 3] == '-')
                                {
                                    bir = Chisla(Expression.Substring(i + 4));
                                    temp = "cos" + minus + bir;
                                    bir = minus + bir;

                                }
                                else
                                {
                                    bir = Chisla(Expression.Substring(i + 3));
                                    temp = "cos" + bir;
                                }
                                res = Math.Cos(Number(bir + "!"));
                                res = Math.Round(res, 4);
                                str = Convert.ToString(res);
                                Expression = Expression.Replace(temp, str);
                                v = Expression.Length;
                                i = -1;
                            }
                            else
                            {
                                if (Expression[i + 3] == '-')
                                {
                                    bir = Chisla(Expression.Substring(i + 5));
                                    temp = "ctan" + minus + bir;
                                    bir = minus + bir;

                                }
                                else
                                {
                                    bir = Chisla(Expression.Substring(i + 4));
                                    temp = "ctan" + bir;
                                }
                                res = Math.Cos(Number(bir + "!")) / Math.Sin(Number(bir + "!"));
                                res = Math.Round(res, 4);
                                str = Convert.ToString(res);
                                Expression = Expression.Replace(temp, str);
                                v = Expression.Length;
                                i = -1;
                            }
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
                        break;
                    default:
                        i = v - 1;
                        break;
                }
            }
            PlusMinus plus = new PlusMinus(Expression);
            Result = plus.Result;
        }        
    }
}
