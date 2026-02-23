using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hada_p2
{
    internal class Coordenada
    {
        int fila = 0;
        int columna = 0;
        public Coordenada()
        {
            fila = 0;
            columna = 0;
        }
        public Coordenada(int fila , int columnsa)
        {
            this.fila = fila;
            this.columna = columnsa;
        }
        public Coordenada (string fila , string columna)
        {
            this.fila=int.Parse(fila);
            this.columna=int.Parse(columna); ;

        }
        public Coordenada(Coordenada other)
        {
            this.fila = other.fila;
            this.columna = other.columna;
        }
        public string ToString()
        {
            return $"({fila},{columna})";
        }
    }
}
