using System;

namespace Hada
{
    public class TocadoArgs : EventArgs
    {
        public string nombre;
        public Coordenada coordenadaImpacto;

        public TocadoArgs(string nombre, Coordenada coordenadaImpacto)
        {
            this.nombre = nombre;
            this.coordenadaImpacto = coordenadaImpacto;
        }
    }

    public class HundidoArgs : EventArgs
    {
        public string nombre;

        public HundidoArgs(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
