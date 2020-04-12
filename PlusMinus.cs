using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    class PlusMinus: ParseBase // класс-наследник, выполняющий вычисление плюса и минуса
    {
        public override string Expression { get ; set ; }
        public override string Result { get ; set ; }
        public PlusMinus(string _expression)
        {
            Expression = _expression;
            ExpressionСalculations();
        }

        public override void ExpressionСalculations()
        {
            string b = "";
            int i = 0;
            double res = 0;
            int v =Expression.Length;
            for (i = 0; i < v; i++)
            {
                switch (Expression[i])
                {
                    case '+':
                        {
                            if (Expression[i + 1] == '-')
                            {
                                Expression = Expression.Replace("+-", "-");
                                v =Expression.Length;
                                b =Expression.Substring(i + 1);
                                res = res - Number(b);
                            }
                            else
                            {
                                b =Expression.Substring(i + 1);
                                res = res + Number(b);
                            }
                            i = Num(b, i);
                            i++;
                        }
                        break;
                    case '-':
                        {
                            if (Expression[i + 1] == '-')
                            {
                                Expression = Expression.Replace("--", "+");
                                v =Expression.Length;
                                b =Expression.Substring(i + 1);
                                res = res + Number(b);

                            }
                            else
                            {
                                b =Expression.Substring(i + 1);
                                res = res - Number(b);
                            }
                            i = Num(b, i);
                            i++;
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
                            b =Expression.Substring(i);
                            i = Num(b, i);
                            res = Number(b);
                        }
                        break;
                    default:
                        i = v - 1;
                        break;
                }
            }

            Result = res.ToString();
        
    }

    }
}
