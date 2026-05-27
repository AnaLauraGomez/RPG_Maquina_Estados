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

        Console.WriteLine();
        Console.WriteLine("Tu aventura comienza en las Tierras Altas de Demacia");

        while (jugar)
        {
            int destino = 0;
            int movimiento = 0;

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
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Noxus (Tierras del Imperio)");
                    Console.WriteLine("2 = Freljord (Tierras Heladas del Norte)");
                    Console.WriteLine("3 = Bandle City (Reino de los Yordles)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q1":

                    Console.WriteLine("\nNoxus - El Imperio de la Fuerza");
                    Console.WriteLine("El suelo rojo sangre y la arquitectura imponente");
                    Console.WriteLine("te recuerdan que aquí solo los fuertes sobreviven.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Demacia (Regresar a casa)");
                    Console.WriteLine("2 = Piltover (Ciudad del Progreso)");
                    Console.WriteLine("3 = Shurima (El Imperio del Sol)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q2":

                    Console.WriteLine("\nFreljord - Las Tierras del Invierno Eterno");
                    Console.WriteLine("El viento helado azota tu rostro mientras la nieve cruje bajo tus pies.");
                    Console.WriteLine("Las leyendas dicen que aquí descansan antiguos dioses.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Demacia (Regresar al sur)");
                    Console.WriteLine("2 = La Grieta del Invocador (Terreno sagrado)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q3":

                    Console.WriteLine("\nPiltover - La Ciudad del Progreso");
                    Console.WriteLine("Artefactos hextech brillan por doquier y máquinas voladoras");
                    Console.WriteLine("surcan los cielos. El progreso está en cada rincón.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Zaun (Las profundidades)");
                    Console.WriteLine("2 = Noxus (Regresar al imperio)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q4":

                    Console.WriteLine("\nZaun - El Distrito Químico");
                    Console.WriteLine("Vapores tóxicos y luces de neón crean una atmósfera");
                    Console.WriteLine("opresiva. Los químicos y marginados gobiernan estas calles.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Piltover (Ascender nuevamente)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q5":

                    Console.WriteLine("\nJonia - La Tierra de la Magia Primigenia");
                    Console.WriteLine("Los bosques cantan con energía espiritual y las aguas");
                    Console.WriteLine("cristalinas reflejan un cielo pintado de paz.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Aguas Estancadas (Puerto principal)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q6":

                    Console.WriteLine("\nAguas Estancadas - El Puerto de Jonia");
                    Console.WriteLine("Barcos de todas las formas llegan y parten. Las tabernas");
                    Console.WriteLine("están llenas de marineros contando historias de monstruos marinos.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Jonia (Tierras interiores)");
                    Console.WriteLine("2 = Islas de la Sombra (Tierras malditas)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q7":

                    Console.WriteLine("\nIslas de la Sombra - El Reino de la Muerte");
                    Console.WriteLine("La niebla negra susurra nombres olvidados. Almas en pena");
                    Console.WriteLine("vagan sin descanso entre ruinas cubiertas de musgo.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Aguas Estancadas (Escapar de la maldición)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q8":

                    Console.WriteLine("\nShurima - El Imperio del Sol Descendente");
                    Console.WriteLine("Imponentes pirámides se alzan en el horizonte. La arena");
                    Console.WriteLine("esconde secretos de una civilización olvidada.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Noxus (Regresar al imperio)");
                    Console.WriteLine("2 = Ixtal (Jungla elemental)");
                    Console.WriteLine("3 = Targon (Montaña celestial)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q9":

                    Console.WriteLine("\nIxtal - La Jungla Elemental");
                    Console.WriteLine("La magia elemental fluye en cada planta y criatura.");
                    Console.WriteLine("Los habitantes dominan la tierra, el fuego, el agua y el aire.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Shurima (Regresar al desierto)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q10":

                    Console.WriteLine("\nMonte Targon - El Techo del Mundo");
                    Console.WriteLine("La cima se pierde entre las nubes. Leyendas dicen que");
                    Console.WriteLine("quien alcanza la cumbre obtiene poder divino.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Shurima (Descender de la montaña)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;

                case "Q11":

                    Console.WriteLine("\nBandle City - El Reino Oculto de los Yordles");
                    Console.WriteLine("Todo es pequeño y colorido. Los portales mágicos brillan");
                    Console.WriteLine("por todas partes, conectando este reino con el mundo.");
                    Console.WriteLine("\n¿Hacia dónde deseas dirigirte?");
                    Console.WriteLine("1 = Demacia (Portal al reino humano)");
                    Console.WriteLine("2 = Jonia (Portal a las tierras espirituales)");
                    destino = Convert.ToInt32(Console.ReadLine());
                    break;
            }

            Console.WriteLine("\n¿Cómo deseas viajar?");
            Console.WriteLine("1 = Caminando (Seguro pero lento)");
            Console.WriteLine("2 = Corriendo (Rápido pero arriesgado)");
            Console.WriteLine("3 = Saltando (Impredecible)");
            Console.WriteLine("4 = Quieto (Quedarte donde estás)");

            movimiento = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (estado)
            {
                // DEMACIA
                case "Q0":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q1";
                        Console.WriteLine("Caminaste con cautela hacia las fronteras de Noxus.");
                        Console.WriteLine("Las tensiones políticas son evidentes, pero logras cruzar");
                        Console.WriteLine("sin ser detectado por los centinelas imperiales.");
                    }
                    else if (destino == 1 && movimiento == 2)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: El Vacío te consume 💀";
                        Console.WriteLine("Corriste sin precaución hacia Noxus.");
                        Console.WriteLine("Sin darte cuenta, cruzaste una grieta dimensional y");
                        Console.WriteLine("caíste directamente en el Vacío. Criaturas de pesadilla");
                        Console.WriteLine("te desgarran la mente mientras tu cuerpo se disuelve.");
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q2";
                        Console.WriteLine("Atravesaste el paso de montaña hacia Freljord.");
                        Console.WriteLine("El frío es intenso pero tu determinación te mantiene con vida.");
                        Console.WriteLine("Las tribus nómadas te observan desde la distancia.");
                    }
                    else if (destino == 2 && movimiento == 2)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: Congelado en el tiempo 💀";
                        Console.WriteLine("Corriste desesperado por la nieve.");
                        Console.WriteLine("Una tormenta ancestral te atrapó. Lissandra, la bruja de hielo,");
                        Console.WriteLine("te convirtió en estatua de hielo por toda la eternidad.");
                    }
                    else if (destino == 3 && movimiento == 1)
                    {
                        estado = "Q11";
                        Console.WriteLine("Un portal oculto en el bosque demaciano se abre ante ti.");
                        Console.WriteLine("Al cruzarlo, apareces en el mágico reino de Bandle City.");
                    }
                    else if (destino == 3 && movimiento == 3)
                    {
                        estado = "Q5";
                        Console.WriteLine("Saltaste sobre un hongo brillante... ¡y un portal te transportó a Jonia!");
                        Console.WriteLine("Aterrizas suavemente en un campo de flores espirituales.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Decides quedarte en Demacia y meditar bajo el Árbol de los Invocadores.");
                        Console.WriteLine("Ganas sabiduría y fuerzas. Decides continuar mañana.");
                        // Permanece en Q0
                    }
                    else
                    {
                        Console.WriteLine("Tu viaje falla. Te pierdes en tierras desconocidas.");
                        Console.WriteLine("Después de días vagando, regresas a Demacia desorientado.");
                        // Permanece en Q0
                    }
                    break;

                // NOXUS
                case "Q1":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q0";
                        Console.WriteLine("Regresas a Demacia por el mismo camino.");
                        Console.WriteLine("Los guardias te reciben con alivio. Estás a salvo.");
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q3";
                        Console.WriteLine("Tomas el elevador hextech hacia Piltover.");
                        Console.WriteLine("La ciudad del progreso se extiende ante tus ojos.");
                    }
                    else if (destino == 3 && movimiento == 1)
                    {
                        estado = "Q8";
                        Console.WriteLine("Cruzas el desierto durante días.");
                        Console.WriteLine("Finalmente, las pirámides de Shurima aparecen en el horizonte.");
                    }
                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: La traición noxiana 💀";
                        Console.WriteLine("Corriendo por los callejones de Noxus, caes en una emboscada.");
                        Console.WriteLine("Darius, el Mano de Noxus, te considera un espía y ejecuta sentencia.");
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
                        Console.WriteLine("Te quedas en una taberna noxiana.");
                        Console.WriteLine("Escuchas historias de guerra y estrategia. Ganas experiencia.");
                        // Permanece en Q1
                    }
                    else
                    {
                        Console.WriteLine("Te confundes con las rutas noxianas.");
                        Console.WriteLine("Terminas dando vueltas sin avanzar.");
                    }
                    break;

                // FRELJORD
                case "Q2":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q0";
                        Console.WriteLine("Regresas a Demacia por la ruta del sur.");
                        Console.WriteLine("El frío se disipa gradualmente.");
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
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: El Yeti ancestral 💀";
                        Console.WriteLine("Corriendo por la tundra, despiertas a un Yeti legendario.");
                        Console.WriteLine("Willump y Nunu intentan ayudarte, pero la bestia es imparable.");
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
                        Console.WriteLine("Acampas en una cueva helada.");
                        Console.WriteLine("Una manada de lobos te protege del frío. Te sientes seguro.");
                    }
                    else
                    {
                        Console.WriteLine("Una avalancha te sepulta momentáneamente.");
                        Console.WriteLine("Logras salir, pero retrocedes a Freljord.");
                    }
                    break;

                // PILTOVER
                case "Q3":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q4";
                        Console.WriteLine("Bajas a las profundidades de Zaun.");
                        Console.WriteLine("El aire se vuelve pesado con químicos industriales.");
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q1";
                        Console.WriteLine("Tomas el camino terrestre hacia Noxus.");
                        Console.WriteLine("Cruzas puentes y valles hasta llegar al imperio.");
                    }
                    else if (movimiento == 2)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: Explosión hextech 💀";
                        Console.WriteLine("Corriendo por los laboratorios, chocas con un prototipo inestable.");
                        Console.WriteLine("La explosión hextech te desintegra por completo.");
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
                        Console.WriteLine("Te sientas en la Fuente de la Ciencia.");
                        Console.WriteLine("Jayce te da una charla inspiradora sobre el progreso.");
                    }
                    else
                    {
                        Console.WriteLine("Te pierdes en el laberinto urbano de Piltover.");
                        Console.WriteLine("Terminas en un callejón sin salida.");
                    }
                    break;

                // ZAUN
                case "Q4":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q3";
                        Console.WriteLine("Tomas el elevador hacia la superficie.");
                        Console.WriteLine("El aire limpio de Piltover te llena los pulmones.");
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo por las tuberías de Zaun, descubres un laboratorio secreto.");
                        Console.WriteLine("Singed, el químico loco, te ofrece una poción de inmortalidad.");
                        Console.WriteLine("La aceptas y te conviertes en un ser inmortal pero atormentado.");
                        Console.WriteLine("\n⚠️ FINAL MORALMENTE GRIS: La Inmortalidad Química ⚠️");
                        Console.WriteLine("Vives para siempre, pero tu cordura se desvanece lentamente.");
                        jugar = false;
                        finalObtenido = "⚠️ FINAL MORALMENTE GRIS: La Inmortalidad Química ⚠️";
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: El Río Químico 💀";
                        Console.WriteLine("Saltas sobre un barranco, pero caes al Río Químico.");
                        Console.WriteLine("Las toxinas te consumen en segundos.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Te refugias en una taberna de Zaun.");
                        Console.WriteLine("Warwick vigila la entrada. Estás a salvo por ahora.");
                    }
                    else
                    {
                        Console.WriteLine("Los vapores tóxicos te desorientan.");
                        Console.WriteLine("Terminas en el mismo lugar.");
                    }
                    break;

                // JONIA
                case "Q5":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q6";
                        Console.WriteLine("Caminas hacia la costa de Jonia.");
                        Console.WriteLine("El puerto de Aguas Estancadas aparece a lo lejos.");
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
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: El Bosque de las Almas 💀";
                        Console.WriteLine("Saltas entre los árboles encantados...");
                        Console.WriteLine("Caes en un círculo de espíritus vengativos que te atrapan por siempre.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Meditas junto a un manantial sagrado.");
                        Console.WriteLine("Sientes paz interior. Tus heridas se curan.");
                    }
                    else
                    {
                        Console.WriteLine("Te pierdes en el laberinto espiritual.");
                        Console.WriteLine("Una niebla mágica te regresa al punto inicial.");
                    }
                    break;

                // AGUAS ESTANCADAS
                case "Q6":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q5";
                        Console.WriteLine("Regresas al interior de Jonia.");
                        Console.WriteLine("La paz de los bosques te envuelve nuevamente.");
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q7";
                        Console.WriteLine("Tomas un barco fantasma hacia las Islas de la Sombra.");
                        Console.WriteLine("La niebla negra te envuelve mientras te acercas.");
                    }
                    else if (movimiento == 2)
                    {
                        Console.WriteLine("Corriendo por el muelle, tropiezas con un barril.");
                        Console.WriteLine("Al caer al agua, nadas hacia la orilla sin problemas.");
                        // Permanece en Q6
                    }
                    else if (movimiento == 3)
                    {
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: El Monstruo Marino 💀";
                        Console.WriteLine("Saltas al agua para nadar rápido...");
                        Console.WriteLine("Un monstruo marino te devora antes de que puedas reaccionar.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Entras a una taberna y escuchas leyendas.");
                        Console.WriteLine("Aprendes sobre tesoros ocultos en las Islas de la Sombra.");
                    }
                    else
                    {
                        Console.WriteLine("Las mareas te confunden.");
                        Console.WriteLine("Terminas en el mismo puerto.");
                    }
                    break;

                // ISLAS DE LA SOMBRA
                case "Q7":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q6";
                        Console.WriteLine("Tomas un bote de regreso a Aguas Estancadas.");
                        Console.WriteLine("La niebla negra se disipa lentamente.");
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
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: Maldición Eterna 💀";
                        Console.WriteLine("Saltas sobre una fosa común...");
                        Console.WriteLine("Thresh te atrapa con su linterna y tu alma queda prisionera por siempre.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Te quedas inmóvil, imitando a las estatuas.");
                        Console.WriteLine("Los fantasmas pasan de largo sin detectarte.");
                    }
                    else
                    {
                        Console.WriteLine("La niebla negra te desorienta completamente.");
                        Console.WriteLine("Terminas en una tumba marcada con tu propio nombre.");
                    }
                    break;


                // SHURIMA
                case "Q8":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q1";
                        Console.WriteLine("Cruzas las montañas hacia Noxus.");
                        Console.WriteLine("El imperio te recibe con desconfianza, pero logras pasar.");
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q9";
                        Console.WriteLine("Adentras en la jungla elemental de Ixtal.");
                        Console.WriteLine("La flora brilla con magia primigenia.");
                    }
                    else if (destino == 3 && movimiento == 1)
                    {
                        estado = "Q10";
                        Console.WriteLine("Comienzas el ascenso al Monte Targon.");
                        Console.WriteLine("La montaña es desafiante, pero la cima te llama.");
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
                        Console.WriteLine("Te refugias bajo una pirámide del sol.");
                        Console.WriteLine("Los ancestros te protegen del calor abrasador.");
                    }
                    else
                    {
                        Console.WriteLine("Una tormenta de arena te ciega.");
                        Console.WriteLine("Terminas en el mismo oasis donde empezaste.");
                    }
                    break;

                // IXTAL
                case "Q9":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q8";
                        Console.WriteLine("Sales de la jungla y regresas al desierto.");
                        Console.WriteLine("Las arenas de Shurima te dan la bienvenida.");
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
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: La Flor Devoradora 💀";
                        Console.WriteLine("Saltas hacia un claro colorido...");
                        Console.WriteLine("Una planta carnívora gigante te atrapa.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Te sientas junto a un árbol elemental.");
                        Console.WriteLine("La energía vital te llena de poder temporal.");
                    }
                    else
                    {
                        Console.WriteLine("Te enredas en las raíces mágicas.");
                        Console.WriteLine("Un druida te guía de regreso.");
                    }
                    break;

                // TARGON
                case "Q10":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q8";
                        Console.WriteLine("Desciendes del Monte Targon con cuidado.");
                        Console.WriteLine("Las piernas te tiemblan, pero llegas a salvo a Shurima.");
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
                        estado = "Q12";
                        finalObtenido = "💀 FINAL TRÁGICO: Caída al Vacío 💀";
                        Console.WriteLine("Saltas desde un risco hacia las nubes...");
                        Console.WriteLine("Pero caes al abismo que conecta con el Vacío.");
                    }
                    else if (movimiento == 4)
                    {
                        Console.WriteLine("Meditas en un risco sagrado.");
                        Console.WriteLine("Una visión del futuro te muestra tu destino.");
                    }
                    else
                    {
                        Console.WriteLine("Un ventarrón casi te derriba.");
                        Console.WriteLine("Te aferras a la montaña y no avanzas.");
                    }
                    break;

                // BANDLE CITY
                case "Q11":

                    if (destino == 1 && movimiento == 1)
                    {
                        estado = "Q0";
                        Console.WriteLine("Tomas el portal hacia Demacia.");
                        Console.WriteLine("Apareces en el bosque donde empezó tu aventura.");
                    }
                    else if (destino == 2 && movimiento == 1)
                    {
                        estado = "Q5";
                        Console.WriteLine("El portal te lleva directamente a Jonia.");
                        Console.WriteLine("Tu entrada causa sorpresa entre los aldeanos.");
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
                        Console.WriteLine("Te quedas en la plaza principal.");
                        Console.WriteLine("Los yordles te ofrecen té y pastelillos.");
                    }
                    else
                    {
                        Console.WriteLine("Un portal te lleva a un lugar aleatorio.");
                        Console.WriteLine("Terminas en Bandle City nuevamente.");
                    }
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
            {"Q12", "El Vacío"}
        };

        return regiones.ContainsKey(estado) ? regiones[estado] : "❓ Tierra Desconocida";
    }
}