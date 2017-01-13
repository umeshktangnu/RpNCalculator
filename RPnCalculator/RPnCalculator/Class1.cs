using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPnCalculator
{
   
    interface IOperator
    {

        decimal operate(Stack<decimal> oprands);

    }

    class Binary : IOperator 
    {




        public virtual decimal operate(Stack<decimal> oprands)
        {
            throw new NotImplementedException();
        }

       
    }
    class Addition:Binary
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            return oprands.Pop() + oprands.Pop();
        }
    }
    class Div:Binary
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            decimal operand2 = oprands.Pop();
            decimal operand1 = oprands.Pop();
            return operand1 / operand2; 
        }
    }
    class Subs : Binary
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            decimal operand2 = oprands.Pop();
            decimal operand1 = oprands.Pop();
            return operand1 - operand2; 
        }
    }
    class Multi : Binary
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            return oprands.Pop() * oprands.Pop();
        }
    }
    class Power : Binary
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            decimal operand2 = oprands.Pop();
            decimal operand1 = oprands.Pop();

            return (decimal)Math.Pow((double)operand1, (double)operand2);
        }
    }
    class Unry  : IOperator
    {



        public virtual decimal operate(Stack<decimal> oprands)
        {
            throw new NotImplementedException();
        }
    }
    class Factorial:Unry
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            return factorial_Recursion(oprands.Pop());
        }
        public decimal  factorial_Recursion(decimal number)
        {
            if (number == 1)
                return 1;
            else
                return number * factorial_Recursion(number - 1);
        }
    }

    class Percent:Unry
    {
        public override decimal operate(Stack<decimal> oprands)
        {
            return oprands.Pop()/100;
        }
    }
    class OperatorFactory
    {



        internal static IOperator GetOperator(string opr)
        {
            switch (opr)
            {
                case "/":
                    return new Div();
                    

                case "+":
                    return new Addition();
                    
                case "-":
                    return new Subs();
                    
                case "*":
                    return new Multi();
                    
                case "^":
                    return new Power();
                    
                case "!":
                    return new Factorial();
                    
                case "%":
                    return new Percent();
                    

                default:
                    throw new ArgumentException("Operator not supported");

                    ;
            }
        }
    }
    
    
    public enum InputType
    {
        /// <summary>
        /// 
        /// </summary>
        InputTypeOperator,
        InputTypeOperand
    }
    public class Calculator
    {

        public bool validate(string expr1)
        {
            if (string.IsNullOrEmpty(expr1) || string.IsNullOrWhiteSpace(expr1))
            {
                return false;
            }
            List<string> tokenized = new List<string>(expr1.Split(' '));
            if (tokenized[0] == expr1)
            {
                return false;
            }
            foreach (var item in tokenized)
            {
                if (!getType(item))
                {
                    return false;
                } 
            }
            return true;
        }
        public bool getType(string input)
        {
            if (Regex.IsMatch(input, @"(^\d+$)|(^\d+[.]\d+$)") || Regex.IsMatch(input, @"[0-9()+\-*/.]"))
            {
                return true;
            }
            return false;
        }

        public string Evaluate(string expr1)
        {
            Stack<decimal> m_operands;
           
            m_operands = new Stack<decimal>();
            
            List<string> tokenized = new List<string>(expr1.Split(' '));
            decimal result = 0;
            foreach (var item in tokenized)
            {
                switch (getInputType(item))
                {
                    case InputType.InputTypeOperator:
                        {
                            try
                            {
                                IOperator oprtr = OperatorFactory.GetOperator(item);
                                m_operands.Push(oprtr.operate(m_operands));
                            }
                            catch (Exception)
                            {
                                
                                throw;
                            }
                            
                        }
                        break;
                    case InputType.InputTypeOperand:
                        m_operands.Push(Decimal.Parse(item));
                        break;
                    default:
                        break;
                }
            }
             
            if (m_operands.Count > 1)
            {
                throw new InvalidExpressionException();
            }
            result = m_operands.Pop();
            if (result % 1 == 0)
            {
                return result.ToString("N0").Replace(",", "");
            }
            return result.ToString("N2").Replace(",", "");
        }
        
        public static InputType getInputType(string input)
        {
            return !Regex.IsMatch(input, @"(^\d+$)|(^\d+[.]\d+$)") ? InputType.InputTypeOperator : InputType.InputTypeOperand;
        }
    }
}
