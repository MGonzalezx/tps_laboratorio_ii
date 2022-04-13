using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region Variables
        private double numero;
        #endregion

        #region Constructores
        public Operando(): this(0) 
        {
            
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        #region Propiedades
        private string Numero
        {
            set { numero = this.ValidarOperando(value); }
        }
        #endregion

        #region Métodos
        private double ValidarOperando(string strNumero)
        {
            double auxilar;

            if (!double.TryParse(strNumero, out auxilar))
            {
                auxilar = 0;
            }

            return auxilar;
        }

        private static bool EsBinario(string binario)
        {
            bool auxiliar = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if(!binario.Contains('1') || !binario.Contains('0') || binario.Length <3)
                {
                    auxiliar = false;
                    break;
                }
            }
            return auxiliar;
        }

        public  string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";
            int auxiliar= 0;
      
            if(EsBinario(binario))
            {
                auxiliar = Convert.ToInt32(binario, 2);
                retorno = Convert.ToString(Math.Abs(auxiliar));
            }

            return retorno;
        }

        public  string DecimalBinario(double numero)
        {
            string retorno;
            int auxiliar;
            string miString;
            auxiliar = Convert.ToInt32(Math.Abs(numero));
            miString = Convert.ToString(auxiliar, 2);
            retorno = DecimalBinario(miString);
            return retorno;
        }

        public  string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            double numeroAuxiliar;
            int enteroAuxiliar;
            if (double.TryParse(numero, out numeroAuxiliar))
            {
                if (!EsBinario(numero))
                {
                    enteroAuxiliar = Convert.ToInt32(Math.Abs(numeroAuxiliar));
                    retorno = Convert.ToString(enteroAuxiliar, 2);
                }
               
            }
            return retorno;
        }

        #endregion

        #region Operadores
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }

        }
        #endregion
    }
}
