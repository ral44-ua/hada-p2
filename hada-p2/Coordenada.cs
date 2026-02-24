using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hada_p2
{
    internal class Coordenada
    {
        int Fila = 0;
        int Columna = 0;
        public Coordenada()
        {
            Fila = 0;
            Columna = 0;
        }
        public Coordenada(int Fila , int Columna)
        {
            this.Fila = Fila;
            this.Columna = Columna;
        }
        public Coordenada (string fila , string columna)
        {
            this.Fila=int.Parse(fila);
            this.Columna=int.Parse(columna); ;

        }
        public Coordenada(Coordenada other)
        {
            this.Fila = other.Fila;
            this.Columna = other.Columna;
        }
        public string ToString()
        {
            return $"({Fila},{Columna})";
        }
        public int GetHasCode()
        {
            return this.Fila.GetHashCode() ^ this.Columna.GetHashCode(); ;
        }
        public override bool Equals(object obj)
        {
            
            if (obj is Coordenada)
            {
                return this.Equals((Coordenada)obj);
            }

            return false;
        }

       
        public bool Equals(Coordenada coordenada)
        {
            if (coordenada == null)
            {
                return false;
            }
            return (this.Fila == coordenada.Fila) && (this.Columna == coordenada.Columna);
        }
    }
}
