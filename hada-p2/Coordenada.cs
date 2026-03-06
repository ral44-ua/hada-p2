using System;

namespace Hada
{
    public class Coordenada
    {
        private int fila = 0;
        private int columna = 0;

        public int Fila
        {
            get { return fila; }
            private set
            {
                if (value < 0 || value > 9) throw new ArgumentOutOfRangeException("Fila debe estar entre 0 y 9");
                fila = value;
            }
        }

        public int Columna
        {
            get { return columna; }
            private set
            {
                if (value < 0 || value > 9) throw new ArgumentOutOfRangeException("Columna debe estar entre 0 y 9");
                columna = value;
            }
        }

        public Coordenada() { }

        public Coordenada(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }

        public Coordenada(string fila, string columna)
        {
            Fila = int.Parse(fila);
            Columna = int.Parse(columna);
        }

        public Coordenada(Coordenada other)
        {
            Fila = other.Fila;
            Columna = other.Columna;
        }

        public override string ToString()
        {
            return $"{Fila},{Columna}";
        }

        public override int GetHashCode()
        {
            return this.Fila.GetHashCode() ^ this.Columna.GetHashCode();
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
            if (coordenada == null) return false;
            return (this.Fila == coordenada.Fila) && (this.Columna == coordenada.Columna);
        }
    }
}
