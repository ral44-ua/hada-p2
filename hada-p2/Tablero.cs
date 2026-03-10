using System;
using System.Collections.Generic;

namespace Hada
{
    public class Tablero
    {
        
        private int _tamTablero;
        public int TamTablero
        {
            get { return _tamTablero; }
            set
            {
                if (value < 4) _tamTablero = 4;
                else if (value > 9) _tamTablero = 9;
                else _tamTablero = value;
            }
        }

        private List<Coordenada> coordenadasDisparadas;
        private List<Coordenada> coordenadasTocadas;
        private List<Barco> barcos;
        private List<Barco> barcosEliminados;
        private Dictionary<Coordenada, string> casillasTablero;

        public event EventHandler<EventArgs> eventoFinPartida;

        // Constructor
        public Tablero(int tamTablero, List<Barco> barcos)
        {
            this.TamTablero = tamTablero;
            this.barcos = barcos;

            this.coordenadasDisparadas = new List<Coordenada>();
            this.coordenadasTocadas = new List<Coordenada>();
            this.barcosEliminados = new List<Barco>();
            this.casillasTablero = new Dictionary<Coordenada, string>();

            foreach (var b in barcos)
            {
                b.eventoTocado += cuandoEventoTocado;
                b.eventoHundido += cuandoEventoHundido;
            }

            inicializaCasillasTablero();
        }

        // metodos privados

        private void inicializaCasillasTablero()
        {
            //Doble for recorremos todo el tablero
            for (int f = 0; f < TamTablero; f++)
            {
                for (int c = 0; c < TamTablero; c++)
                {
                    //Representa la casilla
                    Coordenada coord = new Coordenada(f, c);
                    bool ocupada = false;
                    //Busca si hay un barco en esa casilla y si lo hay hace el break
                    foreach (var b in barcos)
                    {
                        if (b.CoordenadasBarco.ContainsKey(coord))
                        {
                            casillasTablero[coord] = b.Nombre; //Guardamos el nombre del barco
                            ocupada = true;
                            break;
                        }
                    }

                    //Si no hay barco, es AGUA
                    if (!ocupada)
                    {
                        casillasTablero[coord] = "AGUA";
                    }
                }
            }
        }

        public void Disparar(Coordenada c)
        {
            // Esta en los limites?
            if (c.Fila < 0 || c.Fila >= TamTablero || c.Columna < 0 || c.Columna >= TamTablero)
            {
                Console.WriteLine($"La coordenada {c} está fuera de las dimensiones del tablero.");
                return;
            }

            // Se registra
            coordenadasDisparadas.Add(c);

            //Ha sido tocado?
            foreach (var b in barcos)
            {
                b.Disparo(c);
            }
        }

        private void cuandoEventoTocado(object sender, TocadoArgs e)
        {
            // Estado casilla
            casillasTablero[e.coordenadalmpacto] = e.nombre + "_T";

            // Guardar coordenada
            if (!coordenadasTocadas.Contains(e.coordenadalmpacto))
            {
                coordenadasTocadas.Add(e.coordenadalmpacto);
            }

            Console.WriteLine($"TABLERO: Barco {e.nombre} tocado en Coordenada: [{e.coordenadalmpacto}]");
        }

        private void cuandoEventoHundido(object sender, HundidoArgs e)
        {
            Console.WriteLine($"TABLERO: Barco {e.nombre} hundido!!");

            //buscar el barco hundido
            Barco b = (Barco)sender;
            if (!barcosEliminados.Contains(b))
            {
                barcosEliminados.Add(b);
            }

            //Estan todos hundidos?
            if (barcosEliminados.Count == barcos.Count)
            {
                //fin de partida
                if (eventoFinPartida != null)
                {
                    eventoFinPartida(this, EventArgs.Empty);
                }
            }
        }

 

        public string DibujarTablero()
        {
            string tabla = "";
            for (int f = 0; f < TamTablero; f++)
            {
                for (int c = 0; c < TamTablero; c++)
                {
                    Coordenada coord = new Coordenada(f, c);
                    // Escribit casilla
                    tabla += "[" + casillasTablero[coord] + "]";
                }
                tabla += "\n";
            }
            return tabla;
        }

        
        public override string ToString()
        {
            string resultado = "";

            //Info del barco
            foreach (var b in barcos)
            {
                resultado += b.ToString() + "\n";
            }

            //Disparos
            resultado += "\nCoordenadas disparadas: ";
            foreach (var c in coordenadasDisparadas)
            {
                resultado += c.ToString() + " ";
            }

            // Aciertos
            resultado += "\nCoordenadas tocadas: ";
            foreach (var c in coordenadasTocadas)
            {
                resultado += c.ToString() + " ";
            }

            resultado += "\n\nCASILLAS TABLERO\n--------\n";
            resultado += DibujarTablero();

            return resultado;
        }
    }
}