using System;

namespace BibliotecaNum
{
    public class Numero
    {
        private double numero;
        public Numero()
        {
            SetNumero = "0";
        }
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        private string SetNumero
        {
            set
            {
                this.numero = Numero.ValidarNumero(value);
            }
        }
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario) && binario != "Valor inválido")
            {
                double resultado = 0, contador = 0;

                for (int i = binario.Length -1; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        char aux = binario[i];
                        resultado += (Math.Pow(2, contador));
                    }
                    contador++;
                }
                return Convert.ToString(resultado);
            }
            else
                return "Valor inválido";
        }
        public string DecimalBinario(double numero)
        {
            string resto = " ";
            if (double.TryParse(Convert.ToString(numero), out double num))
            {
                while (num > 0)
                {
                    if (num % 2 == 0)
                        resto = "0" + resto;
                    else
                        resto = "1" + resto;
                    num = num / 2;
                }
                return resto;
            }
            else
                return "Valor inválido";
        }
        public string DecimalBinario(string numero)
        {
            string resto = " ";
            if (int.TryParse(numero, out int num))
            {
                while (num > 0)
                {
                    if (num % 2 == 0)
                        resto = "0" + resto;
                    else
                        resto = "1" + resto;
                    num = (int)num / 2;
                }
                return resto;
            }
            else
                return "Valor inválido";
        }
        private static bool EsBinario(string binario)
        {

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] != '1')
                    return true;
            }
            return false;
        }
        private static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
                return numero;
            else
                return 0;
        }
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.numero == 0)
                return double.MinValue;
            else
                return num1.numero / num2.numero;
        }
    }
}
