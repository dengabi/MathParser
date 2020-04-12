using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    class ParsingExpression: ParseBase // главный класс-наследник, выполняющий подготовку к вычислению выражения
    {
        
        public override string Expression { get ; set ; }
        public override string Result { get ; set ; }

        public ParsingExpression(string expression)
        {
            Expression = expression;            
            ExpressionСalculations();
        }
          
        public override void ExpressionСalculations()
        {
            Expression +=  "!";
            int begin = 0; int end = 0;             

            for (int i = 0; i < Expression.Length; i++)
            {
                switch (Expression[i])
                {
                    case '(':
                        begin = i + 1;
                        break;
                    case ')':
                        {
                            end = i - 1;
                            Skobki sk = new Skobki(Expression, begin, end);
                            Expression = sk.Result;                            
                            i = -1;
                        }
                        break;
                    case '!':
                        Exp ex = new Exp(Expression);
                        Result = ex.Result;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
