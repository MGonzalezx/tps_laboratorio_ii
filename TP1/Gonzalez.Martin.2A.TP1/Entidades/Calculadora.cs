using System;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorAuxiliar = Calculadora.ValidarOperador(operador);
            double retorno = 0;

            switch (operadorAuxiliar)
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;

            }
            return retorno;
        }

        private static char ValidarOperador(char operador)
        {
            if (Char.Equals(operador, '+') || Char.Equals(operador, '-') || Char.Equals(operador, '/') || Char.Equals(operador, '*'))
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
    }
}
