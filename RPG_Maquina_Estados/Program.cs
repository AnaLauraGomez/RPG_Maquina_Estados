//Maquina de estados finitas extendidas
 
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int[]> personajes = new Dictionary<string, int[]>();

        // [vida, movimiento, ataque]

        personajes.Add("Guerrero", new int[] { 100, 5, 20 });
        personajes.Add("Mago", new int[] { 70, 8, 30 });
        personajes.Add("Arquero", new int[] { 80, 10, 15 });

        Console.WriteLine("ESCOGE UN PERSONAJE");
        Console.WriteLine("1 = Guerrero");
        Console.WriteLine("2 = Mago");
        Console.WriteLine("3 = Arquero");

        int opcion = Convert.ToInt32(Console.ReadLine());

        string personaje = "";

        switch (opcion)
        {
            case 1:
                personaje = "Guerrero";
                break;

            case 2:
                personaje = "Mago";
                break;

            case 3:
                personaje = "Arquero";
                break;

            default:
                personaje = "Guerrero";
                break;
        }

        Console.WriteLine();
        Console.WriteLine("Elegiste: " + personaje);

        Console.WriteLine("Vida: " + personajes[personaje][0]);
        Console.WriteLine("Movimiento: " + personajes[personaje][1]);
        Console.WriteLine("Ataque: " + personajes[personaje][2]);

        Console.WriteLine("\nHola invocador juguemos LOL\n") ;

        string estado = "Q0";
        bool jugar = true;

        Console.WriteLine();
        Console.WriteLine("Tu aventura comienza en Demacia");

        while (jugar)
        {
            int destino = 0;
            int movimiento = 0;

            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("ESTADO ACTUAL: " + estado);
            Console.WriteLine("=================================");

            switch (estado)
            {
                case "Q0":

                    Console.WriteLine("Te encuentras en Demacia");
                    Console.WriteLine("1 = Noxus");
                    Console.WriteLine("2 = Freljord");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q1":

                    Console.WriteLine("Te encuentras en Noxus");
                    Console.WriteLine("1 = Demacia");
                    Console.WriteLine("2 = Piltover");
                    Console.WriteLine("3 = Shurima");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q2":

                    Console.WriteLine("Te encuentras en Freljord");
                    Console.WriteLine("1 = Demacia");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q3":

                    Console.WriteLine("Te encuentras en Piltover");
                    Console.WriteLine("1 = Zaun");
                    Console.WriteLine("2 = Noxus");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q4":

                    Console.WriteLine("Te encuentras en Zaun");
                    Console.WriteLine("1 = Piltover");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q5":

                    Console.WriteLine("Te encuentras en Jonia");
                    Console.WriteLine("1 = Aguas Estancadas");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q6":

                    Console.WriteLine("Te encuentras en Aguas Estancadas");
                    Console.WriteLine("1 = Jonia");
                    Console.WriteLine("2 = Islas de la Sombra");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q7":

                    Console.WriteLine("Te encuentras en las Islas de la Sombra");
                    Console.WriteLine("1 = Aguas Estancadas");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q8":

                    Console.WriteLine("Te encuentras en Shurima");
                    Console.WriteLine("1 = Noxus");
                    Console.WriteLine("2 = Ixtal");
                    Console.WriteLine("3 = Targon");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q9":

                    Console.WriteLine("Te encuentras en Ixtal");
                    Console.WriteLine("1 = Shurima");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q10":

                    Console.WriteLine("Te encuentras en Targon");
                    Console.WriteLine("1 = Shurima");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;

                case "Q11":

                    Console.WriteLine("Te encuentras en Bandle City");
                    Console.WriteLine("1 = Demacia");
                    Console.WriteLine("2 = Jonia");

                    destino = Convert.ToInt32(Console.ReadLine());

                    break;
            }

            Console.WriteLine();
            Console.WriteLine("¿Como deseas viajar?");
            Console.WriteLine("1 = Caminando");
            Console.WriteLine("2 = Corriendo");
            Console.WriteLine("3 = Saltando");
            Console.WriteLine("4 = Quieto");

            movimiento = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            switch (estado)
            {
                // DEMACIA
                case "Q0":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q1";
                        Console.WriteLine("Caminaste cuidadosamente hacia Noxus");
                    }

                    else if (destino == 1 && movimiento == 2)
                    {
                        estado = "Q12";
                        Console.WriteLine("Corriste demasiado rapido y caíste al Vacío");
                    }

                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q2";
                        Console.WriteLine("Llegaste a las tierras heladas de Freljord");
                    }

                    else if (destino == 2 && movimiento == 3)
                    {
                        estado = "Q11";
                        Console.WriteLine("Saltaste accidentalmente hacia Bandle City");
                    }

                    else
                    {
                        Console.WriteLine("No lograste avanzar");
                    }

                    break;

                // NOXUS
                case "Q1":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q0";
                        Console.WriteLine("Regresaste a Demacia");
                    }

                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q3";
                        Console.WriteLine("Llegaste a Piltover");
                    }

                    else if (destino == 3 && movimiento == 1)
                    {
                        estado = "Q8";
                        Console.WriteLine("Llegaste al desierto de Shurima");
                    }

                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        Console.WriteLine("Corriste demasiado y terminaste en el Vacío");
                    }

                    else
                    {
                        Console.WriteLine("Tu viaje falló");
                    }

                    break;

                // FRELJORD
                case "Q2":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q0";
                        Console.WriteLine("Volviste a Demacia");
                    }

                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        Console.WriteLine("Una tormenta helada te llevó al Vacío");
                    }

                    else
                    {
                        Console.WriteLine("Te perdiste en la nieve");
                    }

                    break;

                // PILTOVER
                case "Q3":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q4";
                        Console.WriteLine("Bajaste hacia Zaun");
                    }

                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q1";
                        Console.WriteLine("Regresaste a Noxus");
                    }

                    else if (movimiento == 3)
                    {
                        estado = "Q12";
                        Console.WriteLine("Saltaste desde una plataforma y caíste al Vacío");
                    }

                    else
                    {
                        Console.WriteLine("No encontraste camino");
                    }

                    break;

                // ZAUN
                case "Q4":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q3";
                        Console.WriteLine("Subiste nuevamente a Piltover");
                    }

                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        Console.WriteLine("Los químicos de Zaun te enviaron al Vacío");
                    }

                    else
                    {
                        Console.WriteLine("Te intoxicaste en Zaun");
                    }

                    break;

                // JONIA
                case "Q5":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q6";
                        Console.WriteLine("Navegaste hacia Aguas Estancadas");
                    }

                    else
                    {
                        estado = "Q12";
                        Console.WriteLine("Las corrientes espirituales te arrastraron al Vacío");
                    }

                    break;

                // AGUAS ESTANCADAS
                case "Q6":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q5";
                        Console.WriteLine("Regresaste a Jonia");
                    }

                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q7";
                        Console.WriteLine("Llegaste a las Islas de la Sombra");
                    }

                    else
                    {
                        estado = "Q12";
                        Console.WriteLine("Un monstruo marino te arrastró al Vacío");
                    }

                    break;

                // ISLAS DE LA SOMBRA
                case "Q7":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q6";
                        Console.WriteLine("Escapaste de las Islas de la Sombra");
                    }

                    else
                    {
                        estado = "Q12";
                        Console.WriteLine("La niebla negra consumió tu alma");
                    }

                    break;

                // SHURIMA
                case "Q8":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q1";
                        Console.WriteLine("Volviste a Noxus");
                    }

                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q9";
                        Console.WriteLine("Entraste a la jungla de Ixtal");
                    }

                    else if (destino == 3 && movimiento == 1)
                    {
                        estado = "Q10";
                        Console.WriteLine("Subiste al Monte Targon");
                    }

                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        Console.WriteLine("Te perdiste en el desierto y caíste al Vacío");
                    }

                    else
                    {
                        Console.WriteLine("No lograste avanzar");
                    }

                    break;

                // IXTAL
                case "Q9":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q8";
                        Console.WriteLine("Regresaste a Shurima");
                    }

                    else
                    {
                        estado = "Q12";
                        Console.WriteLine("La selva te atrapó para siempre");
                    }

                    break;

                // TARGON
                case "Q10":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q8";
                        Console.WriteLine("Descendiste nuevamente a Shurima");
                    }

                    else
                    {
                        estado = "Q12";
                        Console.WriteLine("Caíste desde el Monte Targon al Vacío");
                    }

                    break;

                // BANDLE CITY
                case "Q11":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q0";
                        Console.WriteLine("Un portal te llevó a Demacia");
                    }

                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q5";
                        Console.WriteLine("Un portal mágico te llevó a Jonia");
                    }

                    else
                    {
                        estado = "Q12";
                        Console.WriteLine("Un portal falló y terminaste en el Vacío");
                    }

                    break;
            }

            // ESTADO FINAL (El vacio)
            if (estado == "Q12")
            {
                Console.WriteLine();
                Console.WriteLine("=================================");
                Console.WriteLine("            GAME OVER");
                Console.WriteLine("      Has llegado al Vacío");
                Console.WriteLine("=================================");

                jugar = false;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Fin del juego");

        Console.ReadKey();
    }
}