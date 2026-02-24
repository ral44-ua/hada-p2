using Hada;
using System;

namespace Hada
{
    // Argumentos del evento que se lanzará cuando se 'toque' uno de los barcos
    public class TocadoArgs : EventArgs
    {
        public string nombre;
        public Coordenada coordenadaImpacto;

        // Constructor
        public TocadoArgs(string nombre, Coordenada coordenadaImpacto)
        {
            this.nombre = nombre;
            this.coordenadaImpacto = coordenadaImpacto;
        }
    }

    // Argumentos del evento que se lanzará cuando se hunda uno de los barcos
    public class HundidoArgs : EventArgs
    {
        public string nombre { get; private set; }

        // Constructor
        public HundidoArgs(string nombre)
        {
            this.nombre = nombre;
        }
    }
}