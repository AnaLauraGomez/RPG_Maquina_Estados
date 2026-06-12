//Maquina de estados finitas extendidas
 
using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();
    // Mapa de posibles NPCs por estado (por ahora contiene los NPCs existentes por región)
    static Dictionary<string, string[]> encounterNPCs = new Dictionary<string, string[]>
    {
        { "Q0", new[] { "Garen" } },
        { "Q1", new[] { "Darius" } },
        { "Q2", new[] { "Ashe" } },
        { "Q3", new[] { "Jayce" } },
        { "Q4", new[] { "Singed" } },
        { "Q5", new[] { "Karma" } },
        { "Q6", new[] { "Illaoi" } },
        { "Q7", new[] { "Thresh" } },
        { "Q8", new[] { "Azir" } },
        { "Q9", new[] { "Qiyana" } },
        { "Q10", new[] { "Leona" } },
        { "Q11", new[] { "Lulu" } }
    };

    enum EstadoPelea
    {
        IniciarTurno,
        ElegirAccion,
        ProcesarEsquiva,
        RecibirDañoNashor,
        ProcesarAtaque,
        VerificarMuerteJugador,
        VerificarMuerteNashor,
        ReiniciarBatalla,
        ReiniciarJuego,
        Victoria
    }
    static void Main()
    {
        Dictionary<string, int[]> personajes = new Dictionary<string, int[]>();

        // [vida, movimiento, ataque]
        personajes.Add("Guerrero", new int[] { 100, 5, 20 });
        personajes.Add("Mago", new int[] { 70, 8, 30 });
        personajes.Add("Arquero", new int[] { 80, 10, 15 });

        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║     BIENVENIDO A RUNETERRA         ║");
        Console.WriteLine("║   El destino de los campeones      ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("ESCOGE TU CAMPEÓN");
        Console.WriteLine("1 = Guerrero (Garen/Darius)");
        Console.WriteLine("2 = Mago (Ryze/Lux)");
        Console.WriteLine("3 = Arquero (Ashe/Ezreal)");

        int opcion = Convert.ToInt32(Console.ReadLine());

        string personaje = "";
        int energiaMaxima = 0;

        switch (opcion)
        {
            case 1:
                personaje = "Guerrero";
                energiaMaxima = 12;
                break;

            case 2:
                personaje = "Mago";
                energiaMaxima = 8;
                break;

            case 3:
                personaje = "Arquero";
                energiaMaxima = 10;
                break;

            default:
                personaje = "Guerrero";
                energiaMaxima = 12;
                break;
        }

        int energia = energiaMaxima; //energia consumible

        Console.WriteLine();
        Console.WriteLine("Elegiste: " + personaje);

        Console.WriteLine("Vida: " + personajes[personaje][0]);
        Console.WriteLine("Movimiento: " + personajes[personaje][1]);
        Console.WriteLine("Ataque: " + personajes[personaje][2]);
        Console.WriteLine($"Energía inicial: {energia}/{energiaMaxima}");

        Console.WriteLine("\nLa historia comienza...");
        Console.WriteLine("Eres un aventurero en busca de gloria en Runeterra.");
        Console.WriteLine("Las leyendas hablan de un artefacto ancestral capaz de");
        Console.WriteLine("otorgar poder inimaginable a quien lo encuentre.");
        Console.WriteLine("Tu viaje inicia en las majestuosas tierras de Demacia.\n");

        Console.WriteLine("Presiona cualquier tecla para comenzar tu aventura...");
        Console.ReadKey();
        Console.Clear();

        string estado = "Q0";
        bool jugar = true;
        string finalObtenido = "";
        bool skipNextLoop = false;

        Console.WriteLine();
        Console.WriteLine("Tu aventura comienza en las Tierras Altas de Demacia");

        while (jugar)
        {
            if (skipNextLoop)
            {
                // Saltar una iteración para evitar que se muestren inmediatamente los prompts de ubicación
                skipNextLoop = false;
                Console.Clear();
                continue;
            }
            int destino = 0;
            int movimiento = 0;

            Console.WriteLine();
            Console.WriteLine($"ENERGÍA ACTUAL: {energia}/{energiaMaxima}");

            //Verificar si el jugador tiene energía suficiente para continuar
            if (energia <= 0)
            {
                Console.WriteLine("\n💀 ¡Has muerto por agotamiento! 💀");
                Console.WriteLine("Tu cuerpo no pudo seguir en la aventura.");
                Console.WriteLine("=================================");
                Console.WriteLine("            GAME OVER");
                Console.WriteLine("      Te quedaste sin energía");
                Console.WriteLine("=================================");
                break;
            }

            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine($"UBICACIÓN ACTUAL: {ObtenerNombreRegion(estado)}");
            Console.WriteLine("=================================");

            switch (estado)
            {
                case "Q0":

                    Console.WriteLine("\nDemacia - La Ciudad del Acero Prístino");
                    Console.WriteLine("Las imponentes murallas blancas brillan bajo el sol.");
                    Console.WriteLine("Los ciudadanos te miran con esperanza mientras te preparas para partir.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Noxus (Tierras del Imperio)");
                        Console.WriteLine("2 = Freljord (Tierras Heladas del Norte)");
                        Console.WriteLine("3 = Bandle City (Reino de los Yordles)");
                        //Console.WriteLine("4 = La Guarida del Nashor (Probar batalla final)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Noxus (Tierras del Imperio)");
                        Console.WriteLine("2 = Freljord (Tierras Heladas del Norte)");
                        Console.WriteLine("3 = Bandle City (Reino de los Yordles)");
                        //Console.WriteLine("4 = La Guarida del Nashor (Probar batalla final)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q1":

                    Console.WriteLine("\nNoxus - El Imperio de la Fuerza");
                    Console.WriteLine("El suelo rojo sangre y la arquitectura imponente");
                    Console.WriteLine("te recuerdan que aquí solo los fuertes sobreviven.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Demacia (Regresar a casa)");
                        Console.WriteLine("2 = Piltover (Ciudad del Progreso)");
                        Console.WriteLine("3 = Shurima (El Imperio del Sol)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Demacia (Regresar a casa)");
                        Console.WriteLine("2 = Piltover (Ciudad del Progreso)");
                        Console.WriteLine("3 = Shurima (El Imperio del Sol)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q2":

                    Console.WriteLine("\nFreljord - Las Tierras del Invierno Eterno");
                    Console.WriteLine("El viento helado azota tu rostro mientras la nieve cruje bajo tus pies.");
                    Console.WriteLine("Las leyendas dicen que aquí descansan antiguos dioses.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Demacia (Regresar al sur)");
                        Console.WriteLine("2 = La Grieta del Invocador (Terreno sagrado)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Demacia (Regresar al sur)");
                        Console.WriteLine("2 = La Grieta del Invocador (Terreno sagrado)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q3":

                    Console.WriteLine("\nPiltover - La Ciudad del Progreso");
                    Console.WriteLine("Artefactos hextech brillan por doquier y máquinas voladoras");
                    Console.WriteLine("surcan los cielos. El progreso está en cada rincón.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Zaun (Las profundidades)");
                        Console.WriteLine("2 = Noxus (Regresar al imperio)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Zaun (Las profundidades)");
                        Console.WriteLine("2 = Noxus (Regresar al imperio)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q4":

                    Console.WriteLine("\nZaun - El Distrito Químico");
                    Console.WriteLine("Vapores tóxicos y luces de neón crean una atmósfera");
                    Console.WriteLine("opresiva. Los químicos y marginados gobiernan estas calles.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Piltover (Ascender nuevamente)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Piltover (Ascender nuevamente)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q5":

                    Console.WriteLine("\nJonia - La Tierra de la Magia Primigenia");
                    Console.WriteLine("Los bosques cantan con energía espiritual y las aguas");
                    Console.WriteLine("cristalinas reflejan un cielo pintado de paz.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Aguas Estancadas (Puerto principal)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Aguas Estancadas (Puerto principal)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q6":

                    Console.WriteLine("\nAguas Estancadas - El Puerto de Jonia");
                    Console.WriteLine("Barcos de todas las formas llegan y parten. Las tabernas");
                    Console.WriteLine("están llenas de marineros contando historias de monstruos marinos.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Jonia (Tierras interiores)");
                        Console.WriteLine("2 = Islas de la Sombra (Tierras malditas)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Jonia (Tierras interiores)");
                        Console.WriteLine("2 = Islas de la Sombra (Tierras malditas)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q7":

                    Console.WriteLine("\nIslas de la Sombra - El Reino de la Muerte");
                    Console.WriteLine("La niebla negra susurra nombres olvidados. Almas en pena");
                    Console.WriteLine("vagan sin descanso entre ruinas cubiertas de musgo.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Aguas Estancadas (Escapar de la maldición)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Aguas Estancadas (Escapar de la maldición)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q8":

                    Console.WriteLine("\nShurima - El Imperio del Sol Descendente");
                    Console.WriteLine("Imponentes pirámides se alzan en el horizonte. La arena");
                    Console.WriteLine("esconde secretos de una civilización olvidada.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Noxus (Regresar al imperio)");
                        Console.WriteLine("2 = Ixtal (Jungla elemental)");
                        Console.WriteLine("3 = Targon (Montaña celestial)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Noxus (Regresar al imperio)");
                        Console.WriteLine("2 = Ixtal (Jungla elemental)");
                        Console.WriteLine("3 = Targon (Montaña celestial)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q9":

                    Console.WriteLine("\nIxtal - La Jungla Elemental");
                    Console.WriteLine("La magia elemental fluye en cada planta y criatura.");
                    Console.WriteLine("Los habitantes dominan la tierra, el fuego, el agua y el aire.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Shurima (Regresar al desierto)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Shurima (Regresar al desierto)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q10":

                    Console.WriteLine("\nMonte Targon - El Techo del Mundo");
                    Console.WriteLine("La cima se pierde entre las nubes. Leyendas dicen que");
                    Console.WriteLine("quien alcanza la cumbre obtiene poder divino.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Shurima (Descender de la montaña)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Shurima (Descender de la montaña)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case "Q11":

                    Console.WriteLine("\nBandle City - El Reino Oculto de los Yordles");
                    Console.WriteLine("Todo es pequeño y colorido. Los portales mágicos brillan");
                    Console.WriteLine("por todas partes, conectando este reino con el mundo.");
                    if (MaybeEncounter(ref energia, energiaMaxima, estado))
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte después del encuentro?");
                        Console.WriteLine("1 = Demacia (Portal al reino humano)");
                        Console.WriteLine("2 = Jonia (Portal a las tierras espirituales)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                        Console.WriteLine("1 = Demacia (Portal al reino humano)");
                        Console.WriteLine("2 = Jonia (Portal a las tierras espirituales)");
                        destino = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
            }

            // Si la batalla final terminó el juego, evitar mostrar las opciones de viaje
            if (!jugar)
            {
                break;
            }

            Console.WriteLine("\n¿Cómo deseas viajar?");
            Console.WriteLine("1 = Caminando (Seguro pero lento)");
            Console.WriteLine("2 = Corriendo (Rápido pero arriesgado)");
            Console.WriteLine("3 = Saltando (Impredecible)");
            Console.WriteLine("4 = Quieto (Quedarte donde estás)");

            movimiento = Convert.ToInt32(Console.ReadLine());

            //Verificar si tiene energía suficiente para el movimiento elegido
            if (movimiento == 2 && energia < 3)
            {
                Console.Clear();
                Console.WriteLine("⚠️ ¡No tienes suficiente energía para correr! ⚠️");
                Console.WriteLine($"Tu energía actual es {energia}, necesitas al menos 3 para correr.");
                Console.WriteLine("Te ves obligado a caminar lentamente...");
                movimiento = 1; // Forzar a caminar
                Console.ReadKey();
            }
            else if (movimiento == 3 && energia < 4)
            {
                Console.Clear();
                Console.WriteLine("⚠️ ¡No tienes suficiente energía para saltar! ⚠️");
                Console.WriteLine($"Tu energía actual es {energia}, necesitas al menos 4 para saltar.");
                Console.WriteLine("Te ves obligado a caminar lentamente...");
                movimiento = 1;
                Console.ReadKey();
            }

            Console.Clear();

            bool transicionExitosa = true;

            switch (estado)
            {
                // DEMACIA
                case "Q0":
                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q1";
                            energia -= 1; // Caminar gasta 1 de energía

                            Console.WriteLine("Caminaste con cautela hacia las fronteras de Noxus.");
                            Console.WriteLine("Las tensiones políticas son evidentes, pero logras cruzar");
                            Console.WriteLine("sin ser detectado por los centinelas imperiales.");
                            Console.WriteLine($"-2 de energía (Energía restante: {energia})");
                        }
                        else
                        {
                            Console.WriteLine("Estás demasiado agotado y te desplomas... pero el mundo no termina.");
                            Console.WriteLine("Mientras tu conciencia flota, una luz ancestral te arrastra a otra cámara.");
                            estado = "Q13"; // Transportado a la Guarida del Nashor
                            Console.WriteLine("Al recobrar el sentido, te encuentras frente a la Guarida del Nashor.");
                        }
                    }
                    else if (destino == 1 && movimiento == 2)
                    {
                        if (energia >= 4)
                        {
                            estado = "Q13"; // Transportado a la Guarida del Nashor 
                            energia -= 4;
                            Console.WriteLine("Corriste sin precaución hacia Noxus.");
                            Console.WriteLine("Un extraño portal entre dimensiones se abre y te arrastra.");
                            Console.WriteLine("Al despertar, te encuentras frente a la Guarida del Nashor.");
                        }
                        else
                        {
                            Console.WriteLine("Intentaste correr pero te faltó energía. Tropiezas... algo te traga la oscuridad.");
                            estado = "Q13"; // Llevar al jugador a la batalla final
                            Console.WriteLine("Al abrir los ojos, una enorme sala te rodea: la Guarida del Nashor.");
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q2";
                            energia -= 2;
                            Console.WriteLine("Atravesaste el paso de montaña hacia Freljord.");
                            Console.WriteLine("El frío es intenso pero tu determinación te mantiene con vida.");
                            //Console.WriteLine("Las tribus nómadas te observan desde la distancia.");
                            Console.WriteLine($"-2 de energía (Energía restante: {energia})");
                        }
                        else
                        {
                            Console.WriteLine("El frío extremo acaba con tu poca energía restante.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 2)
                    {
                        estado = "Q13";
                        energia -= 3;
                        Console.WriteLine("Corriste desesperado por la nieve.");
                        Console.WriteLine("Una grieta de energía se abre bajo tus pies y una corriente te arrastra.");
                        Console.WriteLine("Al recuperar el aliento, estás frente a la Guarida del Nashor.");
                    }
                    else if (destino == 3 && movimiento == 1)
                    {
                        if (energia >= 1)
                        {
                            estado = "Q11";
                            energia -= 1;
                            Console.WriteLine("Un portal oculto en el bosque demaciano se abre ante ti.");
                            Console.WriteLine("Al cruzarlo, apareces en el mágico reino de Bandle City.");
                        }
                        else
                        {
                            Console.WriteLine("El portal requiere energía mágica que no tienes.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 3 && movimiento == 3)
                    {
                        estado = "Q5";
                        energia -= 2;
                        Console.WriteLine("Saltaste sobre un hongo brillante... ¡y un portal te transportó a Jonia!");
                        Console.WriteLine("Aterrizas suavemente en un campo de flores espirituales.");
                    }
                    else if (destino == 4 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q13"; // Entrar a la batalla final
                            energia -= 2;
                            Console.WriteLine("Caminas hacia una oscura entrada en las ruinas... La Guarida del Nashor te recibe.");
                            Console.WriteLine($"-2 de energía (Energía restante: {energia})");
                        }
                        else
                        {
                            Console.WriteLine("No tienes energía suficiente para llegar a la guarida.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 4)
                    {
                        // Descansar recupera energía
                        int recuperacion = random.Next(2, 5);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Decides quedarte en Demacia y meditar bajo el Árbol de los Invocadores.");
                        //Console.WriteLine("Ganas sabiduría y fuerzas. Decides continuar mañana.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía. Energía actual: {energia}/{energiaMaxima}");
                        // Permanece en Q0
                    }
                    else
                    {
                        Console.WriteLine("Tu viaje falla. Te pierdes en tierras desconocidas.");
                        Console.WriteLine("Después de días vagando, regresas a Demacia desorientado.");
                        energia -= 1;
                        // Permanece en Q0
                    }
                    break;

                // NOXUS
                case "Q1":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q0";
                            energia -= 2;
                            Console.WriteLine("Regresas a Demacia por el mismo camino.");
                            Console.WriteLine("Los guardias te reciben con alivio. Estás a salvo.");
                        }
                        else
                        {
                            Console.WriteLine("No logras llegar a Demacia, tu cuerpo no responde.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q3";
                            energia -= 2;
                            Console.WriteLine("Tomas el elevador hextech hacia Piltover.");
                            Console.WriteLine("La ciudad del progreso se extiende ante tus ojos.");
                        }
                        else
                        {
                            Console.WriteLine("El elevador falla por tu falta de energía.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 3 && movimiento == 1)
                    {
                        if (energia >= 3)
                        {
                            estado = "Q8";
                            energia -= 3;
                            Console.WriteLine("Cruzas el desierto durante días.");
                            Console.WriteLine("Finalmente, las pirámides de Shurima aparecen en el horizonte.");
                        }
                        else
                        {
                            Console.WriteLine("El desierto te consume vivo.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        estado = "Q13";
                        energia -= 3;
                        Console.WriteLine("Corriendo por los callejones de Noxus, una sombra te envuelve y un portal aparece.");
                        Console.WriteLine("Te arrastra a unas cámaras antiguas; al recobrar el aliento, estás frente a la Guarida del Nashor.");
                    }
                    else if (movimiento == 3)
                    {
                        Console.WriteLine("Saltas entre los tejados noxianos, llamando la atención.");
                        Console.WriteLine("Katarina te observa, impresionada por tu agilidad.");
                        Console.WriteLine("Te ofrece unirse a su gremio de asesinos.");
                        Console.WriteLine("\n✨ FINAL SECRETO: El Gremio de las Sombras ✨");
                        Console.WriteLine("Te conviertes en un maestro asesino al servicio de Noxus.");
                        jugar = false;
                        finalObtenido = "✨ FINAL SECRETO: El Gremio de las Sombras ✨";
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(2, 4);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te quedas en una taberna noxiana.");
                        Console.WriteLine("Escuchas historias de guerra y estrategia. Ganas experiencia.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía. Energía actual: {energia}/{energiaMaxima}");
                        // Permanece en Q1
                    }
                    else
                    {
                        Console.WriteLine("Te confundes con las rutas noxianas.");
                        Console.WriteLine("Terminas dando vueltas sin avanzar.");
                        energia -= 1;
                    }
                    break;

                // FRELJORD
                case "Q2":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q0";
                            energia -= 2;
                            Console.WriteLine("Regresas a Demacia por la ruta del sur.");
                            Console.WriteLine("El frío se disipa gradualmente.");
                        }
                        else
                        {
                            Console.WriteLine("El camino de regreso es demasiado largo para ti.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        Console.WriteLine("Llegas a la Grieta del Invocador.");
                        Console.WriteLine("Los campeones más poderosos de Runeterra se enfrentan aquí.");
                        Console.WriteLine("Te unes a una batalla épica y demuestras tu valía.");
                        Console.WriteLine("\n🏆 FINAL ÉPICO: Campeón de la Grieta 🏆");
                        Console.WriteLine("Tu nombre se escribe en la historia como un gran invocador.");
                        jugar = false;
                        finalObtenido = "🏆 FINAL ÉPICO: Campeón de la Grieta 🏆";
                    }
                    else if (movimiento == 2)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor 
                        energia -= 3;
                        Console.WriteLine("Corriendo por la tundra, una grieta espacial se abre bajo tus pies.");
                        Console.WriteLine("Eres succionado hacia unas antiguas cámaras... Has llegado a la Guarida del Nashor.");
                    }
                    else if (movimiento == 3)
                    {
                        Console.WriteLine("Saltas sobre un glaciar y descubres una entrada oculta.");
                        Console.WriteLine("Dentro encuentras el Templo de los Hielos Eternos.");
                        Console.WriteLine("Los guardianes te consideran digno del poder ancestral.");
                        Console.WriteLine("\n✨ FINAL SECRETO: Guardián de los Hielos Eternos ✨");
                        Console.WriteLine("Obtienes el poder de los antiguos dioses de Freljord.");
                        jugar = false;
                        finalObtenido = "✨ FINAL SECRETO: Guardián de los Hielos Eternos ✨";
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(3, 6);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Acampas en una cueva helada.");
                        Console.WriteLine("Una manada de lobos te protege del frío. Te sientes seguro.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía. Energía actual: {energia}/{energiaMaxima}");
                    }
                    else
                    {
                        Console.WriteLine("Una avalancha te sepulta momentáneamente.");
                        Console.WriteLine("Logras salir, pero retrocedes a Freljord.");
                        energia -= 2;
                    }
                    break;

                // PILTOVER
                case "Q3":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 1)
                        {
                            estado = "Q4";
                            energia -= 1;
                            Console.WriteLine("Bajas a las profundidades de Zaun.");
                            Console.WriteLine("El aire se vuelve pesado con químicos industriales.");
                        }
                        else
                        {
                            Console.WriteLine("Los gases de Zaun te asfixian.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q1";
                            energia -= 2;
                            Console.WriteLine("Tomas el camino terrestre hacia Noxus.");
                            Console.WriteLine("Cruzas puentes y valles hasta llegar al imperio.");
                        }
                        else
                        {
                            Console.WriteLine("El puente colapsa por tu falta de energía.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        // Evitar muertes y llevar a Nashor
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 3;
                        Console.WriteLine("Corriendo por los laboratorios, un experimento falla y abre un portal.");
                        Console.WriteLine("Eres arrastrado a través del vórtice hasta unas ruinas: la Guarida del Nashor.");
                    }
                    else if (movimiento == 3)
                    {
                        Console.WriteLine("Saltas entre plataformas elevadas y te encuentras con un taller secreto.");
                        Console.WriteLine("Heimerdinger, el sabio yordle, te ofrece ser su aprendiz.");
                        Console.WriteLine("\n✨ FINAL SECRETO: Genio Hextech ✨");
                        Console.WriteLine("Te conviertes en el inventor más brillante de Piltover.");
                        jugar = false;
                        finalObtenido = "✨ FINAL SECRETO: Genio Hextech ✨";
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(1, 3);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te sientas en la Fuente de la Ciencia.");
                        Console.WriteLine("Jayce te da una charla inspiradora sobre el progreso.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("Te pierdes en el laberinto urbano de Piltover.");
                        Console.WriteLine("Terminas en un callejón sin salida.");
                        energia -= 1;
                    }
                    break;

                // ZAUN
                case "Q4":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q3";
                            energia -= 2;
                            Console.WriteLine("Tomas el elevador hacia la superficie.");
                            Console.WriteLine("El aire limpio de Piltover te llena los pulmones.");
                        }
                        else
                        {
                            Console.WriteLine("El elevador se descompone y caes al vacío.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        estado = "Q13";
                        energia -= 2;
                        Console.WriteLine("Corriendo por las tuberías de Zaun, un flujo de energía te arrastra.");
                        Console.WriteLine("Cuando te recuperas, una sala colosal te rodea: la Guarida del Nashor.");
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 2;
                        Console.WriteLine("Saltas sobre un barranco y caes en una corriente que te arrastra hacia un portal.");
                        Console.WriteLine("Al salir del flujo, te encuentras ante la Guarida del Nashor.");
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(1, 3);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te refugias en una taberna de Zaun.");
                        Console.WriteLine("Warwick vigila la entrada. Estás a salvo por ahora.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("Los vapores tóxicos te desorientan.");
                        Console.WriteLine("Terminas en el mismo lugar.");
                        energia -= 1;
                    }
                    break;

                // JONIA
                case "Q5":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 1)
                        {
                            estado = "Q6";
                            energia -= 1;
                            Console.WriteLine("Caminas hacia la costa de Jonia.");
                            Console.WriteLine("El puerto de Aguas Estancadas aparece a lo lejos.");
                        }
                        else
                        {
                            Console.WriteLine("El viaje a la costa te agota por completo.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo por los bosques espirituales, te encuentras con Karma.");
                        Console.WriteLine("Reconoce tu pureza de corazón y te ofrece entrenamiento.");
                        Console.WriteLine("\n✨ FINAL SECRETO: Alma Iluminada ✨");
                        Console.WriteLine("Te conviertes en un líder espiritual de Jonia.");
                        jugar = false;
                        finalObtenido = "✨ FINAL SECRETO: Alma Iluminada ✨";
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 3;
                        Console.WriteLine("Saltas entre los árboles encantados y un portal ancestral se abre bajo ti.");
                        Console.WriteLine("Te arrastra y despiertas frente a la Guarida del Nashor.");
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(3, 7);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Meditas junto a un manantial sagrado.");
                        Console.WriteLine("Sientes paz interior. Tus heridas se curan.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía. Energía actual: {energia}/{energiaMaxima}");
                    }
                    else
                    {
                        Console.WriteLine("Te pierdes en el laberinto espiritual.");
                        Console.WriteLine("Una niebla mágica te regresa al punto inicial.");
                        energia -= 1;
                    }
                    break;

                // AGUAS ESTANCADAS
                case "Q6":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q5";
                            energia -= 2;
                            Console.WriteLine("Regresas al interior de Jonia.");
                            Console.WriteLine("La paz de los bosques te envuelve nuevamente.");
                        }
                        else
                        {
                            Console.WriteLine("No logras regresar a través de los bosques.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        if (energia >= 3)
                        {
                            estado = "Q7";
                            energia -= 3;
                            Console.WriteLine("Tomas un barco fantasma hacia las Islas de la Sombra.");
                            Console.WriteLine("La niebla negra te envuelve mientras te acercas.");
                        }
                        else
                        {
                            Console.WriteLine("El barco fantasma te recluta como marinero eterno.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo por el muelle, tropiezas con un barril.");
                        Console.WriteLine("Al caer al agua, nadas hacia la orilla sin problemas.");
                        energia -= 1;
                        // Permanece en Q6
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 2;
                        Console.WriteLine("Al zambullirte en las profundidades, eres succionado por una fuerza luminosa.");
                        Console.WriteLine("Emerges en unas cámaras antiguas: la Guarida del Nashor.");
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(2, 5);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Entras a una taberna y escuchas leyendas.");
                        Console.WriteLine("Aprendes sobre tesoros ocultos en las Islas de la Sombra.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("Las mareas te confunden.");
                        Console.WriteLine("Terminas en el mismo puerto.");
                        energia -= 1;
                    }
                    break;

                // ISLAS DE LA SOMBRA
                case "Q7":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 3)
                        {
                            estado = "Q6";
                            energia -= 3;
                            Console.WriteLine("Tomas un bote de regreso a Aguas Estancadas.");
                            Console.WriteLine("La niebla negra se disipa lentamente.");
                        }
                        else
                        {
                            Console.WriteLine("La niebla te consume antes de escapar.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo entre las tumbas, encuentras el alma de Kalista.");
                        Console.WriteLine("Te ofrece venganza contra quienes te traicionaron.");
                        Console.WriteLine("Aceptas y te conviertes en un espectro vengativo.");
                        Console.WriteLine("\n⚠️ FINAL MORALMENTE GRIS: El Espectro de la Venganza ⚠️");
                        Console.WriteLine("Obtienes poder eterno, pero pierdes tu humanidad.");
                        jugar = false;
                        finalObtenido = "⚠️ FINAL MORALMENTE GRIS: El Espectro de la Venganza ⚠️";
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 2;
                        Console.WriteLine("Al caer en la fosa, una luz devoradora te transporta lejos.");
                        Console.WriteLine("Al abrir los ojos, estás en la Guarida del Nashor.");
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(1, 3);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te quedas inmóvil, imitando a las estatuas.");
                        Console.WriteLine("Los fantasmas pasan de largo sin detectarte.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("La niebla negra te desorienta completamente.");
                        Console.WriteLine("Terminas en una tumba marcada con tu propio nombre.");
                        energia -= 2;
                    }
                    break;


                // SHURIMA
                case "Q8":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 3)
                        {
                            estado = "Q1";
                            energia -= 3;
                            Console.WriteLine("Cruzas las montañas hacia Noxus.");
                            Console.WriteLine("El imperio te recibe con desconfianza, pero logras pasar.");
                        }
                        else
                        {
                            Console.WriteLine("Las montañas son demasiado peligrosas para ti ahora.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q9";
                            energia -= 2;
                            Console.WriteLine("Adentras en la jungla elemental de Ixtal.");
                            Console.WriteLine("La flora brilla con magia primigenia.");
                        }
                        else
                        {
                            Console.WriteLine("La jungla te atrapa en sus raíces.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 3 && movimiento == 1)
                    {
                        if (energia >= 4)
                        {
                            estado = "Q10";
                            energia -= 4;
                            Console.WriteLine("Comienzas el ascenso al Monte Targon.");
                            Console.WriteLine("La montaña es desafiante, pero la cima te llama.");
                        }
                        else
                        {
                            Console.WriteLine("Caes por un risco durante el ascenso.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: Devorado por la arena 💀";
                        Console.WriteLine("Corriendo por el desierto, activas una trampa ancestral.");
                        Console.WriteLine("La arena te traga como si fueras una simple semilla.");
                    }
                    else if (movimiento == 3)
                    {
                        Console.WriteLine("Saltas sobre una pirámide y llegas a la cima.");
                        Console.WriteLine("Azir, el Emperador Ascendido, te nombra su heredero.");
                        Console.WriteLine("\n🏆 FINAL ÉPICO: Heredero de Shurima 🏆");
                        Console.WriteLine("Gobiernas el imperio del sol junto a los ascendientes.");
                        jugar = false;
                        finalObtenido = "🏆 FINAL ÉPICO: Heredero de Shurima 🏆";
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(2, 4);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te refugias bajo una pirámide del sol.");
                        Console.WriteLine("Los ancestros te protegen del calor abrasador.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("Una tormenta de arena te ciega.");
                        Console.WriteLine("Terminas en el mismo oasis donde empezaste.");
                        energia -= 1;
                    }
                    break;

                // IXTAL
                case "Q9":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 2)
                        {
                            estado = "Q8";
                            energia -= 2;
                            Console.WriteLine("Sales de la jungla y regresas al desierto.");
                            Console.WriteLine("Las arenas de Shurima te dan la bienvenida.");
                        }
                        else
                        {
                            Console.WriteLine("La jungla te reclama como parte de ella.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo entre los árboles elementales, Qiyana te reta a un duelo.");
                        Console.WriteLine("La derrotas con honor y ella te ofrece un lugar en la corte elemental.");
                        Console.WriteLine("\n🏆 FINAL ÉPICO: Señor de los Elementos 🏆");
                        Console.WriteLine("Dominas la magia de la tierra, fuego, agua y aire.");
                        jugar = false;
                        finalObtenido = "🏆 FINAL ÉPICO: Señor de los Elementos 🏆";
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 2;
                        Console.WriteLine("La planta te envuelve y, en vez de devorarte, te lanza a través de un portal.");
                        Console.WriteLine("Caes en la Guarida del Nashor.");
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(2, 5);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te sientas junto a un árbol elemental.");
                        Console.WriteLine("La energía vital te llena de poder temporal.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("Te enredas en las raíces mágicas.");
                        Console.WriteLine("Un druida te guía de regreso.");
                        energia -= 1;
                    }
                    break;

                // TARGON
                case "Q10":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 3)
                        {
                            estado = "Q8";
                            energia -= 3;
                            Console.WriteLine("Desciendes del Monte Targon con cuidado.");
                            Console.WriteLine("Las piernas te tiemblan, pero llegas a salvo a Shurima.");
                        }
                        else
                        {
                            Console.WriteLine("Durante el descenso, pierdes el equilibrio y caes.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo hacia la cima... Llegas a la Cumbre Celestial.");
                        Console.WriteLine("Los Aspectos te reciben y te otorgan poder divino.");
                        Console.WriteLine("\n🏆 FINAL ÉPICO: Ascendido Celestial 🏆");
                        Console.WriteLine("Te conviertes en un ser de luz, protector de Runeterra.");
                        jugar = false;
                        finalObtenido = "🏆 FINAL ÉPICO: Ascendido Celestial 🏆";
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q13"; // Transportado a la Guarida del Nashor
                        energia -= 2;
                        Console.WriteLine("Al saltar desde el risco, una corriente mágica te transporta a lo desconocido.");
                        Console.WriteLine("Despiertas en la Guarida del Nashor.");
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(2, 4);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Meditas en un risco sagrado.");
                        Console.WriteLine("Una visión del futuro te muestra tu destino.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía.");
                    }
                    else
                    {
                        Console.WriteLine("Un ventarrón casi te derriba.");
                        Console.WriteLine("Te aferras a la montaña y no avanzas.");
                        energia -= 1;
                    }
                    break;

                // BANDLE CITY
                case "Q11":

                    if (destino == 1 && movimiento == 1)
                    {
                        if (energia >= 1)
                        {
                            estado = "Q0";
                            energia -= 1;
                            Console.WriteLine("Tomas el portal hacia Demacia.");
                            Console.WriteLine("Apareces en el bosque donde empezó tu aventura.");
                        }
                        else
                        {
                            Console.WriteLine("El portal se cierra antes de que puedas cruzarlo.");
                            transicionExitosa = false;
                        }
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        if (energia >= 1)
                        {
                            estado = "Q5";
                            energia -= 1;
                            Console.WriteLine("El portal te lleva directamente a Jonia.");
                            Console.WriteLine("Tu entrada causa sorpresa entre los aldeanos.");
                        }
                        else
                        {
                            Console.WriteLine("La magia del portal te agota por completo.");
                            transicionExitosa = false;
                        }
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo entre portales, llegas al corazón de Bandle City.");
                        Console.WriteLine("Lulu, la maga yordle, te ofrece convertirte en su aprendiz.");
                        Console.WriteLine("\n✨ FINAL SECRETO: Aprendiz de Yordle ✨");
                        Console.WriteLine("Aprendes la magia más pura y alegre de Runeterra.");
                        jugar = false;
                        finalObtenido = "✨ FINAL SECRETO: Aprendiz de Yordle ✨";
                    }
                    else if (movimiento == 3)
                    {
                        Console.WriteLine("Saltas dentro de un hongo gigante.");
                        Console.WriteLine("Te transporta a un mundo de fantasía donde los sueños se hacen realidad.");
                        Console.WriteLine("\n✨ FINAL SECRETO: Soñador Eterno ✨");
                        Console.WriteLine("Vives feliz para siempre en un mundo de ensueño.");
                        jugar = false;
                        finalObtenido = "✨ FINAL SECRETO: Soñador Eterno ✨";
                    }
                    else if (movimiento == 4)
                    {
                        int recuperacion = random.Next(3, 7);
                        energia = Math.Min(energia + recuperacion, energiaMaxima);
                        Console.WriteLine("Te quedas en la plaza principal.");
                        Console.WriteLine("Los yordles te ofrecen té y pastelillos.");
                        Console.WriteLine($"Recuperas {recuperacion} de energía. Energía actual: {energia}/{energiaMaxima}");
                    }
                    else
                    {
                        Console.WriteLine("Un portal te lleva a un lugar aleatorio.");
                        Console.WriteLine("Terminas en Bandle City nuevamente.");
                        energia -= 1;
                    }
                    break;
                // BATALLA FINAL: La Guarida del Nashor
                case "Q13":
                    Console.WriteLine("\n═══════════════════════════════════════════");
                    Console.WriteLine("\nHas entrado a la Guarida del Nashor. Una presencia colosal te observa...");
                    Console.WriteLine("\n═══════════════════════════════════════════");

                    RunFinalBattle(ref energia, energiaMaxima, ref estado, ref jugar, ref finalObtenido, ref skipNextLoop);

                    if (jugar)
                    {
                        skipNextLoop = true;
                        Console.Clear();
                        continue; // REINICIA EL WHILE(JUGAR) INMEDIATAMENTE, saltándose los Game Over de abajo y el menú de viaje
                    }

                    if (skipNextLoop)
                    {
                        if (!jugar)
                        {
                            Console.Clear();
                            Console.WriteLine("\n═══════════════════════════════════════════");
                            Console.WriteLine(finalObtenido);
                            Console.WriteLine("═══════════════════════════════════════════");
                            Console.WriteLine("\nGracias por jugar esta aventura en Runeterra.");
                            Console.WriteLine("Presiona cualquier tecla para salir...");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        skipNextLoop = false;
                        Console.Clear();
                        continue;
                    }
                    break;
            }

                    // Verificar si el jugador murió por falta de energía
                    if (!transicionExitosa || energia <= 0)
            {
                Console.WriteLine("\n═══════════════════════════════════════════");
                Console.WriteLine("            💀 GAME OVER 💀");
                Console.WriteLine("      Has muerto en tu aventura");
                Console.WriteLine($"      Energía restante: {energia}");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("\nPresiona cualquier tecla para salir...");
                Console.ReadKey();
                jugar = false;
                break;
            }


            if (!jugar)
            {
                Console.WriteLine("\n═══════════════════════════════════════════");
                Console.WriteLine(finalObtenido);
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("\nGracias por jugar esta aventura en Runeterra.");
                Console.WriteLine("Presiona cualquier tecla para salir...");
                Console.ReadKey();
                break;
            }

            
            if (estado == "Q12")
            {
                Console.WriteLine("\n═══════════════════════════════════════════");
                Console.WriteLine("            💀 GAME OVER 💀");
                if (!string.IsNullOrEmpty(finalObtenido))
                {
                    Console.WriteLine(finalObtenido);
                }
                else
                {
                    Console.WriteLine("      Has caído en el Vacío eterno");
                    Console.WriteLine("      Tu alma se disuelve en la nada");
                }
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("\nTu aventura ha terminado.");
                Console.WriteLine("Presiona cualquier tecla para salir...");
                Console.ReadKey();
                jugar = false;
            }
        }
    }

    // Función para manejar NPCs interactivos
    static bool NPCInteractivo(ref int energia, int energiaMaxima, string npcNombre)
    {
        Console.WriteLine($"\n⚠️ ¡UN NPC SE ACERCA! ⚠️");
        Console.WriteLine($"¡Es {npcNombre}! ¿Cómo quieres interactuar?");

        // Diferentes interacciones según el NPC
        switch (npcNombre)
        {
            case "Garen":
                Console.WriteLine("Garen: '¡Por Demacia! ¿Eres amigo o enemigo?'");
                Console.WriteLine("1 = Pelear contra Garen");
                Console.WriteLine("2 = Escapar rápidamente");
                Console.WriteLine("3 = Ofrecerle ayuda (puede recuperar energía)");
                break;

            case "Darius":
                Console.WriteLine("Darius: 'Noxus te observa. ¿Tienes el valor de enfrentarme?'");
                Console.WriteLine("1 = Pelear contra Darius");
                Console.WriteLine("2 = Escapar sigilosamente");
                Console.WriteLine("3 = Impresionarlo con tu fuerza (requiere energía)");
                break;

            case "Ashe":
                Console.WriteLine("Ashe: 'Bienvenido a Freljord. ¿Buscas alianza o conflicto?'");
                Console.WriteLine("1 = Pelear contra Ashe");
                Console.WriteLine("2 = Escapar entre la nieve");
                Console.WriteLine("3 = Aceptar su hospitalidad (recuperas energía)");
                break;

            case "Jayce":
                Console.WriteLine("Jayce: '¡Interesante! ¿Quieres probar mi nuevo invento?'");
                Console.WriteLine("1 = Pelear contra Jayce");
                Console.WriteLine("2 = Escapar por los tejados");
                Console.WriteLine("3 = Probar su invento (peligroso pero gratificante)");
                break;

            case "Singed":
                Console.WriteLine("Singed: '¿Quieres probar mi nueva poción?' *risa malvada*");
                Console.WriteLine("1 = Pelear contra Singed");
                Console.WriteLine("2 = Escapar antes de que te envenene");
                Console.WriteLine("3 = Tomar la poción (efecto aleatorio)");
                break;

            case "Karma":
                Console.WriteLine("Karma: 'Paz y equilibrio. ¿Necesitas sanación?'");
                Console.WriteLine("1 = Pelear contra Karma");
                Console.WriteLine("2 = Escapar de su templo");
                Console.WriteLine("3 = Recibir su bendición (recuperas mucha energía)");
                break;

            case "Illaoi":
                Console.WriteLine("Illaoi: '¡El movimiento es vida! ¿Aceptas el desafío?'");
                Console.WriteLine("1 = Pelear contra Illaoi");
                Console.WriteLine("2 = Escapar al barco");
                Console.WriteLine("3 = Aceptar su prueba de fe (recuperas energía si pasas)");
                break;

            case "Thresh":
                Console.WriteLine("Thresh: 'Tu alma se ve... deliciosa' *ríe siniestramente*");
                Console.WriteLine("1 = Pelear contra Thresh");
                Console.WriteLine("2 = Escapar desesperadamente");
                Console.WriteLine("3 = Negociar con él (peligroso)");
                break;

            case "Azir":
                Console.WriteLine("Azir: '¿Eres digno de pisar Shurima?'");
                Console.WriteLine("1 = Pelear contra Azir");
                Console.WriteLine("2 = Escapar al desierto");
                Console.WriteLine("3 = Demostrar tu respeto (recuperas energía)");
                break;

            case "Qiyana":
                Console.WriteLine("Qiyana: '¿Crees que puedes igualar mi poder elemental?'");
                Console.WriteLine("1 = Pelear contra Qiyana");
                Console.WriteLine("2 = Escapar a la jungla");
                Console.WriteLine("3 = Aprender de ella (gastas energía pero ganas experiencia)");
                break;

            case "Leona":
                Console.WriteLine("Leona: 'La luz te protege, viajero. ¿Necesitas ayuda?'");
                Console.WriteLine("1 = Pelear contra Leona");
                Console.WriteLine("2 = Escapar al amanecer");
                Console.WriteLine("3 = Recibir su protección (recuperas energía)");
                break;

            case "Lulu":
                Console.WriteLine("Lulu: '¡Hora de purificar! ¿Quieres ver magia?'");
                Console.WriteLine("1 = Pelear contra Lulu");
                Console.WriteLine("2 = Escapar por un portal");
                Console.WriteLine("3 = Aceptar su magia (efecto aleatorio)");
                break;

            default:
                Console.WriteLine("1 = Pelear");
                Console.WriteLine("2 = Escapar");
                Console.WriteLine("3 = Negociar");
                break;
        }

        Console.Write("\nTu elección: ");
        int interaccion = Convert.ToInt32(Console.ReadLine());

        // Sistema de pelea con números aleatorios
        int dado = random.Next(1, 11); // Número entre 1 y 10

        switch (interaccion)
        {
            case 1: // Pelear
                Console.WriteLine($"\n¡Decides pelear contra {npcNombre}!");
                Console.WriteLine($"Tiras un dado... ¡SACASTE {dado}!");

                if (dado <= 5)
                {
                    int perdida = 6;
                    energia -= perdida;
                    Console.WriteLine($"Fallas en tu ataque y recibes daño grave. Pierdes {perdida} de energía.");
                    Console.WriteLine($"Energía actual: {energia}");
                }
                else
                {
                    int perdida = 3;
                    energia -= perdida;
                    Console.WriteLine($"Logras defenderte bien. Pierdes solo {perdida} de energía.");
                    Console.WriteLine($"Energía actual: {energia}");
                }

                if (energia <= 0)
                {
                    Console.WriteLine($"\n{npcNombre} te ha derrotado. Caes sin fuerzas...");
                    return true;
                }
                break;

            case 2: // Escapar
                Console.WriteLine($"\nIntentas escapar de {npcNombre}...");
                int costoEscapar = random.Next(2, 5);
                energia -= costoEscapar;
                Console.WriteLine($"Logras huir, pero pierdes {costoEscapar} de energía en el intento.");
                Console.WriteLine($"Energía actual: {energia}");

                if (energia <= 0)
                {
                    Console.WriteLine($"\nEl esfuerzo de escapar fue demasiado. Colapsas...");
                    return true;
                }
                break;

            case 3: // Opción especial 
                Console.WriteLine($"\nTomas una decisión diplomática con {npcNombre}...");
                dado = random.Next(1, 11);
                Console.WriteLine($"Tiras un dado para ver el resultado... ¡SACASTE {dado}!");

                if (dado >= 7)
                {
                    int ganancia = random.Next(3, 7);
                    energia = Math.Min(energia + ganancia, energiaMaxima);
                    Console.WriteLine($"¡Interacción exitosa! {npcNombre} te ayuda. Recuperas {ganancia} de energía.");
                    Console.WriteLine($"Energía actual: {energia}/{energiaMaxima}");
                }
                else if (dado >= 4)
                {
                    Console.WriteLine($"La interacción es neutral. No ganas ni pierdes energía.");
                }
                else
                {
                    int perdida = random.Next(2, 5);
                    energia -= perdida;
                    Console.WriteLine($"La interacción sale mal. Pierdes {perdida} de energía.");
                    Console.WriteLine($"Energía actual: {energia}");
                }

                if (energia <= 0)
                {
                    Console.WriteLine($"\nLa interacción con {npcNombre} te dejó sin energía. 💀");
                    return true;
                }
                break;

            default:
                Console.WriteLine("Acción no válida. Pierdes energía por indecisión.");
                energia -= 2;
                break;
        }

        return energia > 0;
    }

    // Decide aleatoriamente si ocurre un encuentro en la región actual y con qué NPC
    static bool MaybeEncounter(ref int energia, int energiaMaxima, string estado)
    {
        int prob = random.Next(1, 11); // 1-10
        // Menos de 6 -> no hay encuentro (1-5), 6-10 -> encuentro
        if (prob <= 5)
        {
            Console.WriteLine($"\nNo encuentras a nadie en esta zona. (Tirada: {prob})");
            return false; // No hubo encuentro
        }

        // Hay encuentro: seleccionar un NPC aleatorio del diccionario para este estado
        string npc = "Enemigo Desconocido";
        if (encounterNPCs.ContainsKey(estado))
        {
            var list = encounterNPCs[estado];
            if (list.Length > 0)
            {
                npc = list[random.Next(list.Length)];
            }
        }

        Console.WriteLine($"\n¡Encuentro aleatorio! (Tirada: {prob}) Te topas con {npc}.");
        // Llamar a la rutina existente de interacción
        return NPCInteractivo(ref energia, energiaMaxima, npc);
    }

    // Máquina de estados para la batalla final contra Baron Nashor
    static void RunFinalBattle(ref int energia, int energiaMaxima, ref string estado, ref bool jugar, ref string finalObtenido, ref bool skipNextLoop)
    {
        // Usamos variables locales aisladas para la batalla
        int playerLife = energia;
        int nashorLife = 12;

        string[] ataques = new[] { "tunel magico", "rayos de vacio", "pared", "grito" };
        EstadoPelea estadoPelea = EstadoPelea.IniciarTurno;

        Console.WriteLine("\n═══════════════════════════════════════════");
        Console.WriteLine(" Has entrado en la cámara colosal del Baron Nashor.");
        Console.WriteLine(" Su aliento retumba como un trueno; las paredes palpitan con energía ancestral.");
        Console.WriteLine(" Aquí se decide el destino de tu aventura. Observa las mecánicas: ");
        Console.WriteLine(" - Algunos ataques del Nashor son " + "\"vulnerables\" " + "y permiten contraataques más potentes.");
        Console.WriteLine(" - Si eliges esquivar, tienes una probabilidad de evitar todo el daño.");
        Console.WriteLine(" - Atacar en el momento oportuno (cuando el Nashor use ataques vulnerables) inflige gran daño.");
        Console.WriteLine("═══════════════════════════════════════════\n");

        int accion = 1;
        bool esquivaExitosa = false;
        string ataque = "";

        void PrintStatus()
        {
            int maxP = energiaMaxima;
            int maxN = 12;
            int displayPlayerLife = Math.Max(0, playerLife);
            int displayNashorLife = Math.Max(0, nashorLife);
            int pBar = Math.Max(0, Math.Min(10, (int)Math.Round(displayPlayerLife / (double)maxP * 10)));
            int nBar = Math.Max(0, Math.Min(10, (int)Math.Round(displayNashorLife / (double)maxN * 10)));

            Console.Write("Jugador: [");
            Console.Write(new string('#', pBar));
            Console.Write(new string('-', 10 - pBar));
            Console.Write($"] {displayPlayerLife}/{maxP}\n");

            Console.Write("Nashor : [");
            Console.Write(new string('#', nBar));
            Console.Write(new string('-', 10 - nBar));
            Console.Write($"] {displayNashorLife}/{maxN}\n");
        }

        Console.WriteLine("Comienza la batalla final contra Baron Nashor!");

        // El bucle se ejecutará de forma infinita controlada internamente por los estados
        while (jugar)
        {
            switch (estadoPelea)
            {
                case EstadoPelea.IniciarTurno:
                    Console.WriteLine();
                    PrintStatus();
                    ataque = ataques[random.Next(ataques.Length)];
                    Console.WriteLine($"\n>> Baron Nashor prepara: {ataque.ToUpper()} <<");

                    if (ataque == "grito" || ataque == "tunel magico")
                    {
                        Console.WriteLine("El cuerpo del Nashor queda por un instante expuesto: este ataque es vulnerable.");
                    }
                    else
                    {
                        Console.WriteLine("Este ataque es poderoso pero no deja expuesto al Nashor.");
                    }
                    estadoPelea = EstadoPelea.ElegirAccion;
                    break;

                case EstadoPelea.ElegirAccion:
                    Console.WriteLine("\n¿Qué haces? 1 = Atacar | 2 = Esquivar");
                    if (!int.TryParse(Console.ReadLine(), out accion)) accion = 1;

                    if (accion == 2)
                        estadoPelea = EstadoPelea.ProcesarEsquiva;
                    else
                        estadoPelea = EstadoPelea.RecibirDañoNashor;
                    break;

                case EstadoPelea.ProcesarEsquiva:
                    esquivaExitosa = (random.Next(2) == 0);

                    if (esquivaExitosa)
                    {
                        Console.WriteLine("Has realizado una esquiva perfecta: el ataque no te alcanza.");
                        estadoPelea = EstadoPelea.ProcesarAtaque;
                    }
                    else
                    {
                        Console.WriteLine("Fallaste la esquiva. El Nashor impacta con fuerza y recibes 2 de daño.");
                        playerLife -= 2;
                        estadoPelea = EstadoPelea.VerificarMuerteJugador;
                    }
                    break;

                case EstadoPelea.RecibirDañoNashor:
                    Console.WriteLine("Mientras atacas, el Nashor te golpea de regreso. Recibes 2 de daño.");
                    playerLife -= 2;
                    estadoPelea = EstadoPelea.VerificarMuerteJugador;
                    break;

                case EstadoPelea.VerificarMuerteJugador:
                    if (playerLife <= 0)
                    {
                        Console.WriteLine("\nHas caído en la batalla.");
                        Console.WriteLine("1 = Reiniciar batalla | 2 = Salir del juego");

                        int choice;
                        if (!int.TryParse(Console.ReadLine(), out choice)) choice = 1;

                        if (choice == 1)
                        {
                            estadoPelea = EstadoPelea.ReiniciarBatalla;
                        }
                        else
                        {
                            energia = 0;
                            jugar = false;
                            return;
                        }
                    }
                    else
                    {
                        estadoPelea = EstadoPelea.ProcesarAtaque;
                    }
                    break;

                case EstadoPelea.ProcesarAtaque:
                    bool ataqueEficaz = (ataque == "grito" || ataque == "tunel magico");

                    if (ataqueEficaz && accion == 1) // Solo da el golpe crítico de 4 si atacaste voluntariamente en vulnerabilidad
                    {
                        nashorLife -= 4;
                        Console.WriteLine("¡Contraataque perfecto! Infliges -4 de vida al Nashor debido a su vulnerabilidad.");
                    }
                    else
                    {
                        nashorLife -= 1;
                        Console.WriteLine("Tu ataque apenas alcanza al Nashor. Infliges 1 de daño.");
                    }

                    estadoPelea = EstadoPelea.VerificarMuerteNashor;
                    break;

                case EstadoPelea.VerificarMuerteNashor:
                    if (nashorLife <= 0)
                    {
                        Console.WriteLine("\n¡Has derrotado a Baron Nashor!");
                        finalObtenido = "🏆 FINAL ÉPICO: Vencedor del Nashor 🏆";
                        jugar = false;
                        energia = Math.Max(0, playerLife); // Sincronizamos la energía solo al ganar
                        skipNextLoop = true;
                        return; // Rompe y sale al Main a mostrar los créditos de victoria
                    }

                    // Si nadie ha muerto, el turno termina limpiamente y vuelve a iniciar sin tocar variables globales
                    estadoPelea = EstadoPelea.IniciarTurno;
                    break;

                case EstadoPelea.ReiniciarBatalla:
                    playerLife = energiaMaxima;
                    nashorLife = 12;
                    Console.WriteLine("Reiniciando batalla...");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    Console.Clear();
                    estadoPelea = EstadoPelea.IniciarTurno;
                    break;
            }
        }
    }

    static string ObtenerNombreRegion(string estado)
    {
        Dictionary<string, string> regiones = new Dictionary<string, string>
        {
            {"Q0", "Demacia"},
            {"Q1", "Noxus"},
            {"Q2", "Freljord"},
            {"Q3", "Piltover"},
            {"Q4", "Zaun"},
            {"Q5", "Jonia"},
            {"Q6", "Aguas Estancadas"},
            {"Q7", "Islas de la Sombra"},
            {"Q8", "Shurima"},
            {"Q9", "Ixtal"},
            {"Q10", "Monte Targon"},
            {"Q11", "Bandle City"},
            {"Q13", "La Guarida del Nashor"},
            {"Q12", "El Vacío"}
        };

        return regiones.ContainsKey(estado) ? regiones[estado] : "❓ Tierra Desconocida";
    }
}