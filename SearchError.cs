using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserMath
{
    class SearchError: ParseBase // класс-наследник, выполняющий проверку на наличие ошибок в строке выражения
    {        
        public override string Expression
        {
            get; set;
        }
        public override string Result
        {
            get;  set;
        }
        private int errorall = 0, error = 0, error1 = 0, error2 = 0, error3 = 0, error4 = 0, error5 = 0;
        public SearchError(string _Expression)
        {
            Expression = _Expression;
            ExpressionСalculations();
        }
        public override void ExpressionСalculations()
        {
            try
                {
                for (int i = 0; i < Expression.Length; i++)
                {
                    if (Expression[i] == '1' || Expression[i] == '2' || Expression[i] == '3' || Expression[i] == '4' || Expression[i] == '5' || Expression[i] == '6' || Expression[i] == '7' || Expression[i] == '8' || Expression[i] == '9' || Expression[i] == '0'
                    || Expression[i] == '+' || Expression[i] == '-' || Expression[i] == '*' || Expression[i] == '/' || Expression[i] == ',' || Expression[i] == '(' || Expression[i] == ')' || Expression[i] == '^'
                    || Expression[i] == 0x221A || Expression[i] == 's' || Expression[i] == 'i' || Expression[i] == 'n' || Expression[i] == 'c' || Expression[i] == 'o')
                    {
                        if (Expression[i] == ',')
                        {
                            if (i != (Expression.Length) - 1)
                            {
                                if (!(Char.IsDigit(Expression[i + 1])) || !(Char.IsDigit(Expression[i - 1])))
                                    error1 = i + 1;
                            }
                            else error = i + 1;
                        }
                        else if (Expression[i] == '(' || Expression[i] == ')')
                            error2++;
                        else if (Expression[i] == 0x221A)
                        {
                            if (i != 0)
                            {
                                if (!(Char.IsDigit(Expression[i - 1])) && Expression[i - 1] != ')')
                                    error3 = i + 1;
                            }
                            else if (i == 0)
                                error3 = i + 1;
                            if (!(Char.IsDigit(Expression[i + 1])) && Expression[i + 1] != '-' && Expression[i + 1] != '(')
                                error4 = i + 2;
                        }
                        else if (Expression[i] == 's' && Expression[i + 1] == 'i')
                        {
                            if (i != 0)
                            {
                                if (Expression[i - 1] != '+' && Expression[i - 1] != '-' && Expression[i - 1] != '(')
                                    error5 = i;
                            }
                            if (!(Char.IsDigit(Expression[i + 3])) && Expression[i + 3] != '-' && Expression[i + 3] != '(')
                                error5 = i + 4;
                        }
                        else if (Expression[i] == 'c' && Expression[i + 1] == 'o')
                        {
                            if (i != 0)
                            {
                                if (Expression[i - 1] != '+' && Expression[i - 1] != '-' && Expression[i - 1] != '(')
                                    error5 = i;
                            }
                            if (!(Char.IsDigit(Expression[i + 3])) && Expression[i + 3] != '-' && Expression[i + 3] != '(')
                                error5 = i + 4;
                        }
                        else if (Expression[i] == 't' && Expression[i + 1] == 'a')
                        {
                            if (i != 0)
                            {
                                if (Expression[i - 1] != '+' && Expression[i - 1] != '-' && Expression[i - 1] != '(' && Expression[i - 1] != 'c')
                                    error5 = i;
                            }
                            if (i == 0)
                            {
                                if (!(Char.IsDigit(Expression[i + 3])) && Expression[i + 3] != '-' && Expression[i + 3] != '(')
                                    error5 = i + 4;
                            }
                            if (i != 0)
                            {
                                if (Expression[i - 1] != 'c')
                                {
                                    if (!(Char.IsDigit(Expression[i + 3])) && Expression[i + 3] != '-' && Expression[i + 3] != '(')
                                        error5 = i + 4;
                                }
                            }
                        }
                        else if (Expression[i] == 'c' && Expression[i + 1] == 't')
                        {
                            if (i != 0)
                            {
                                if (Expression[i - 1] != '+' && Expression[i - 1] != '-' && Expression[i - 1] != '(')
                                    error5 = i;
                            }
                            if (!(Char.IsDigit(Expression[i + 4])) && Expression[i + 4] != '-' && Expression[i + 4] != '(')
                                error5 = i + 5;
                        }
                        else if (Expression[i] == 'l' && Expression[i + 1] == 'n')
                        {
                            if (i != 0)
                            {
                                if (Expression[i - 1] != '+' && Expression[i - 1] != '-' && Expression[i - 1] != '(')
                                    error5 = i;
                            }
                            if (!(Char.IsDigit(Expression[i + 2])) && Expression[i + 2] != '-' && Expression[i + 2] != '(')
                                error5 = i + 3;
                        }
                    }
                    else error = i + 1;
                }
                errorall = error + error1 + error3 + error4 + error5;
                if (errorall != 0)
                {
                    if (error != 0)
                    {
                        Result += "Неверный символ(" + Convert.ToString(error) + " поз.)! ";
                    }
                    if (error1 != 0)
                    {
                        Result += "Неверное вещественное(" + Convert.ToString(error1) + " поз.)! ";
                    }
                    if (error3 != 0)
                    {
                        Result += "Не задана степень корня(" + Convert.ToString(error3) + " поз.)! ";
                    }
                    if (error4 != 0)
                    {
                        Result += "Не задано подкоренное выражение(" + Convert.ToString(error4) + " поз.)! ";
                    }
                    if (error5 != 0)
                    {
                        Result += "Неправильное выражение(" + Convert.ToString(error5) + " поз.)! ";
                    }
                }
                else if (error2 % 2 != 0)
                {
                    Result = "Неверное кол. скобок! ";
                }
                else Result = "Без ошибок!";
                
            }
            catch (Exception e) { Result = e.Message; }
        }
    }
}
