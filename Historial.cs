using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historial
{
    internal class Historiales
    {
        public double Numero1;
        public double Numero2;
        public string Operando;
        public double Resultado;
        public string Operacion;

        public Historiales(double numero1, double numero2, string operando,string operacion,double resultado) { 
            this.Numero1 = numero1;
            this.Numero2 = numero2;
            this.Operando = operando;
            this.Operacion = operacion;
            this.Resultado = resultado;
        }
    }
}
