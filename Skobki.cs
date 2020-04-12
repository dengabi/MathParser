using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    class Skobki : ParseBase // класс-наследник, выполняющий вычисление выражения в скобках
    {
        int begin; int end;
        public override string Expression { get ; set; }
        public override string Result { get ; set ; }
        public Skobki(string _expression, int _begin, int _end)
        {
            begin = _begin; end = _end;
            Expression = _expression;
            ExpressionСalculations();
        }

        public override void ExpressionСalculations()
        {
            string b = "";
            string temp = "";
            b = Expression.Substring(begin, end - begin + 1);
            Exp ex = new Exp(b + "!");
            temp = ex.Result;
            if (temp == "100000000000000")
                Result = temp;
            else
            {
                b = "(" + b + ")";
                Result = Expression.Replace(b, temp);                
            }
        }
    }
}
