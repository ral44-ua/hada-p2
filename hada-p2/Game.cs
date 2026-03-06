using System;
using System.Collections.Generic;

namespace Hada
{
    public class Game
    {
        private bool finPartida;

        public Game()
        {
            this.finPartida = false;
            gameLoop();
        }

        private void gameLoop()
        {
            
            List<Barco> barcos = new List<Barco>();
            // Ejemplo de barcos que no se solapan:
            barcos.Add(new Barco("THOR", 1, 'h', new Coordenada(0, 0)));
            barcos.Add(new Barco("LOKI", 2, 'v', new Coordenada(1, 2))); 
            barcos.Add(new Barco("MAYA", 3, 'h', new Coordenada(3, 1)));

    // Tamaño mi del tablero 4
            Tablero tablero = new Tablero(4, barcos);
    
    //fin de partida
            tablero.eventoFinPartida += cuandoEventoFinPartida;



            while (!finPartida)
    {
                Console.WriteLine(tablero.ToString());

                Console.Write("Introduce la coordenada a la que disparar FILA,COLUMNA ('S' para Salir): ");
        string entrada = Console.ReadLine();

                //pulsa la S
                if (entrada.ToUpper() == "S")
                {
                    finPartida = true;
                    break;
                }

                string[] partes = entrada.Split(',');
                if (partes.Length == 2 && int.TryParse(partes[0], out int f) && int.TryParse(partes[1], out int c))
                {
                    //disparo
                    tablero.Disparar(new Coordenada(f, c));
                }
                else
                {
                    Console.WriteLine("Formato incorrecto.");
                }
            }
        }

        private void cuandoEventoFinPartida(object sender, EventArgs e)
{
         Console.WriteLine("PARTIDA FINALIZADA!!");
         this.finPartida = true;
}
    }
}