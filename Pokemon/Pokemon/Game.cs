using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Game // Desarrollo del juego
    {
        int enemy;
        int figther;
        Trainer trainer;
        IndividualPokemon[] initPokemons; // Se llama al Array de los pokemons
        IndividualPokemon[] enemyPokemons;
        IndividualPokemon[] myPokemons;
        IndividualPokemon[][] boxes;
        Moves[] moves;
        public Game() // Se inicializan
        {            
            trainer = new Trainer();
            initPokemons = InitPokemons(); 
            enemyPokemons = EnemyPokemons();
            myPokemons = trainer.MyPokemons();
            boxes = trainer.Boxes();
            moves = movements();
        }        
        public void startGame() // Opción de juego rápido o lento
        {
            Console.WriteLine("¿Como quieres iniciar el juego? \n 1) Modo jugador \n 2) Modo desarrollador ");
            int startgame = int.Parse(Console.ReadLine());
            if (startgame == 1)
            {
                slowRun();
            }
            else if (startgame == 2)
            {
                fastRun();
            }
        }
        public void slowRun() // Bienvenida lenta
        {
            string Welcome = "¡Hola a todos! ¡Bienvenidos al mundo de POKÉMON! ¡Me llamo OAK! ¡Este mundo está habitado por unas criaturas llamadas POKÉMON! " +
            "Para algunos, los POKÉMON son mascotas. Pero otros los usan para pelear. En cuanto a mí... Estudio a los POKÉMON como profesión. Pero primero dime como te llamas.\t";
            IO.SlowWrite(Welcome, 25);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string namePlayer = IO.readLine();
            trainer.SetName(namePlayer);
            trainer.SetPokedolar(1000);
            trainer.SetCreateDate(DateTime.Now);
            trainer.SetId(trainer.GenerateMyID());
            Console.ForegroundColor = ConsoleColor.Gray;
            askgender();
            Console.ForegroundColor = ConsoleColor.Gray;
            string welcome1 = ("Genial " + namePlayer + ", encantado de darte la bienvenida a este nuevo mundo. Lo primero que haré será regalarte uno de estos tres Pokemons,las opciones son: \n");
            IO.SlowWrite(welcome1, 25);
            for (int arinit = 0; arinit < initPokemons.Length; ++arinit) // Array para mostrar los datos de mis Pokémon
            {
                if (initPokemons[arinit] != null)
                {
                    string Welcome2 = ((arinit + 1) + ") " + initPokemons[arinit].GetName() + " (" + initPokemons[arinit].getType() + ") " + " \n");
                    IO.SlowWrite(Welcome2, 25);
                }
            }
            ChoosePokemon();
            MainMenu();
        }
        public void fastRun() // Bienvenida rápida
        {
            string Welcome = "¡Hola a todos! ¡Bienvenidos al mundo de POKÉMON! ¡Me llamo OAK! ¡Este mundo está habitado por unas criaturas llamadas POKÉMON! " +
            "Para algunos, los POKÉMON son mascotas. Pero otros los usan para pelear. En cuanto a mí... Estudio a los POKÉMON como profesión. Hola Alberto, tu Pokemon asignado es Charmander. \n";
            IO.SlowWrite(Welcome, 0);
            trainer.SetName("Alberto");
            trainer.SetGender("♂");
            trainer.SetPokedolar(1000);
            trainer.SetCreateDate(DateTime.Now);
            trainer.SetId(trainer.GenerateMyID());
            myPokemons[0] = initPokemons[2];
            myPokemons[0].SetEO(trainer.GetId());
            MainMenu();
        }
        public void ChoosePokemon() // Elección de Pokemon
        {
            bool exit = false;
            while (exit == false)
            {
                string choose = "¿Cual será tu elección?\t";
                IO.SlowWrite(choose, 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int startPokemon = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;
                switch (startPokemon)
                {
                    case 1: //Bulbasaur
                        Console.ForegroundColor = ConsoleColor.Green;
                        string bulbasaur = "Perfecto, una magnifica elección, cuida mucho de él, será un fiel compañero y un gran Pokémon. \n";
                        IO.SlowWrite(bulbasaur, 25);
                        myPokemons[0] = initPokemons[0];
                        myPokemons[0].SetEO(trainer.GetId());
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 2: //Squirtle
                        Console.ForegroundColor = ConsoleColor.Blue;
                        string squirtle = "Perfecto, una magnifica elección, cuida mucho de él, le encanta nadar, es muy versatil y un poderoso Pokémon. \n";
                        IO.SlowWrite(squirtle, 25);
                        myPokemons[0] = initPokemons[1];
                        myPokemons[0].SetEO(trainer.GetId());
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 3: //Charmander
                        Console.ForegroundColor = ConsoleColor.Red;
                        string charmander = "Perfecto, una magnifica elección, cuida mucho de él, es un poco rebelde y cuesta que haga caso, pero en la mano adecuada será muy poderoso. \n";
                        IO.SlowWrite(charmander, 25);
                        myPokemons[0] = initPokemons[2];
                        myPokemons[0].SetEO(trainer.GetId());
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    default:
                        if (exit == false) // Vuelve a preguntar por si se pone un número que no esta en las opciones
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("No has introducido un Pokémon válido");
                        }
                        break;
                }
            }
        }
        public void MainMenu() // Creación del menú principal
        {
            int option;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Selecciona una opción:");
                Console.WriteLine("1) Mi Jugador");
                Console.WriteLine("2) Mis Pokémon");
                Console.WriteLine("3) Cajas Pokémon");
                Console.WriteLine("4) Combatir");
                Console.WriteLine("5) Centro Pokémon");
                Console.WriteLine("6) Salir");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        myPlayer();
                        break;
                    case 2:
                        myPokemon();
                        break;
                    case 3:
                        myBoxes();
                        break;
                    case 4:
                        menuFigth();
                        break;
                    case 5:
                        pokemonCenter();
                        break;
                    case 6:
                        exit();
                        break;
                    default:
                        Console.WriteLine("Esa opción no es válida!");
                        break;
                }
            } while (option != 6);
        }

        public void pokemonCenter() // Cura a nuestros Pokémons
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string welcomeCenter = ("-- Bienvenido al centro Pokémon -- \n-- Aqui nos encargamos de curar a tus Pokémons. --\n");
            IO.SlowWrite(welcomeCenter, 25);
            for (int armyp = 0; armyp < myPokemons.Length; ++armyp) // Array para mostrar los datos de mis Pokémon
            {
                if (myPokemons[armyp] != null)
                {
                    string myPokemonCenter = ("Tu Pokémon " + myPokemons[armyp].GetName() + " tiene una vida actual de " + myPokemons[armyp].GetHp() + " y su vida máxima sería de " + myPokemons[armyp].GetMaxHP() + "\n");
                    IO.SlowWrite(myPokemonCenter, 25);
                }
            }
            bool exit2 = false;
            while (exit2 == false)
            {
                string askHeal = ("¿deseas curar a tus Pokémons?: \n 1) Si \n 2) No ");
                IO.SlowWrite(askHeal, 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int healOrNot = IO.intToString();
                Console.ForegroundColor = ConsoleColor.Magenta;
                switch (healOrNot)
                {
                    case 1:
                        string posheal = ("Genial, estamos deseando curar a tus Pokémons, esto tardará unos instantes.");
                        IO.SlowWrite(posheal, 25);
                        string waitingHeal = ("\n║▌█║│█║▌│█│║▌║░░░░░░░░░░C░u░r░a░n░d░o░ ░a░ ░t░u░s░ ░P░o░k░é░m░o░n░░░░░░░░░░║▌█║│█║▌│█│║▌║ \nHurra! Tus Pokémons ya estan curados, gracias por traerlos al centro Pokémon. \n");
                        IO.SlowWrite(waitingHeal, 80);
                        for (int armypheal = 0; armypheal < myPokemons.Length; ++armypheal)
                        {
                            if (myPokemons[armypheal] != null)
                            {
                                myPokemons[armypheal].SetHp(myPokemons[armypheal].GetMaxHP());
                                string workingHeal = ("La vida actual de tu " + myPokemons[armypheal].GetName() + " es " + myPokemons[armypheal].GetHp() + "\n");
                                IO.SlowWrite(workingHeal, 25);
                            }
                        }
                        Console.WriteLine("Hasta la próxima \n");
                        exit2 = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 2:
                        string negheal = ("De acuerdo, estaremos encantados de curar a tus Pokémons la próxima ocasión, adios\n");
                        IO.SlowWrite(negheal, 25);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        MainMenu();
                        break;
                    default:
                        if (exit2 == false) // Vuelve a preguntar por si se pone un número que no esta en las opciones
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("No has introducido una opción válida\n");
                        }
                        break;
                }
            }
        }
        public void myPokemon() // Info de los Pokémons del jugador 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string mypokwel = ("Estos son tus Pokemon " + trainer.GetName() + ": \n");
            IO.SlowWrite(mypokwel, 25);
            for (int myp = 0; myp < myPokemons.Length; ++myp) // Array para mostrar los datos de mis Pokémon
            {
                if (myPokemons[myp] != null)
                {
                    string mypokstats = ("Nombre: " + myPokemons[myp].GetName() + " Tipo: " + myPokemons[myp].getType() + " Vida actual: " + myPokemons[myp].GetHp() + " Vida máxima: " + myPokemons[myp].GetMaxHP() + "\n");
                    IO.SlowWrite(mypokstats, 25);
                }                
            }
            string fulledition = ("¿Quieres toda la info de tus Pokémons?\n1) Si\n2) No\n");
            IO.SlowWrite(fulledition, 25);
            int option = IO.intToString();
            switch (option)
            {
                case 1:
                    for (int myp = 0; myp < myPokemons.Length; ++myp)
                    {
                        if (myPokemons[myp] != null)
                        {
                            string fulleditionpok = ("Nombre: " + myPokemons[myp].GetName() + " ID: " + myPokemons[myp].GetId() + " Género: " + myPokemons[myp].GetGender() + " Tipo: " + myPokemons[myp].getType() + " Nivel: "+ myPokemons[myp].GetLevel() + " Vida actual: " + myPokemons[myp].GetHp() + " Vida máxima: " + myPokemons[myp].GetMaxHP() + " EO: " + myPokemons[myp].GetEO() + " " + myPokemons[myp].GetDate() + "\n");
                            IO.SlowWrite(fulleditionpok, 25);
                        }
                    }
                    break;
                case 2:
                    string negfulledition = ("De acuerdo, te devolvemos al menú principal\n");
                    IO.SlowWrite(negfulledition, 25);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    MainMenu();
                    break;
                default: // Vuelve a preguntar por si se pone un número que no esta en las opciones
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No has introducido el número válido \n");
                    break;
            }
            int backOrNot = 0;
            do
            {
                string backmenu = ("\nIntroduce 1 cuando quieras volver al menú principal \n");
                IO.SlowWrite(backmenu, 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                backOrNot = IO.intToString();
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (backOrNot)
                {
                    case 1:
                        MainMenu();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    default: // Vuelve a preguntar por si se pone un número que no esta en las opciones
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No has introducido el número válido \n");
                        break;
                }
            } while (backOrNot != 1);

        }
        public void menuFigth() // Menú y desarrollo del combate
        {
            Random enemyRandom = new Random();
            enemy = enemyRandom.Next(0, 6);
            Console.WriteLine("Tus Pokémon para luchar son:");
            int counter = 0;
            for (int mypf = 0; mypf < myPokemons.Length; ++mypf) // Array para mostrar los datos de mis Pokémon
            {
                if (myPokemons[mypf] != null && myPokemons[mypf].GetHp() > 0)
                {
                    string choosefigth = ((mypf + 1) + ") " + myPokemons[mypf].GetName() + " (" + myPokemons[mypf].getType() + ") Nivel: " + myPokemons[mypf].GetLevel() + " Vida: " + myPokemons[mypf].GetHp() + "\n");
                    IO.SlowWrite(choosefigth, 25);
                    ++counter;
                }
            }           
            if (counter > 0)
            {
                do
                {
                    string choosefpok = ("¿Con que Pokémon quieres luchar? \n");
                    IO.SlowWrite(choosefpok, 25);
                    figther = int.Parse(Console.ReadLine()) - 1;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Un Pokemon salvaje aparecio");
                    string mypokstatsF = ("Tu Pokémon: " + myPokemons[figther].GetName() + " Nivel: " + myPokemons[figther].GetLevel() + " Vida: " + myPokemons[figther].GetHp() + "\n");
                    IO.SlowWrite(mypokstatsF, 25);
                    string enemyStats = ("Pokémon salvaje: " + enemyPokemons[enemy].GetName() + " Nivel: " + enemyPokemons[enemy].GetLevel() + " Vida: " + enemyPokemons[enemy].GetHp() + "\n");
                    IO.SlowWrite(enemyStats, 25);
                    menuInTheFigth();
                } while (myPokemons[figther].GetHp() < 0);
            }
            else
            {
                Console.WriteLine("Todos tus Pokémons estan debilitados, te mandamos al centro Pokémon mas cercano");
                pokemonCenter();
            }
        }
        public void menuInTheFigth()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int mfigth;
            do
            {
                string menuFig = ("Tus opciones son: \n 1) Atacar \n 2) Cambiar Pokémon \n 3) Capturar \n 4) Escapar \n");
                IO.SlowWrite(menuFig, 25);
                mfigth = int.Parse(Console.ReadLine());
                switch (mfigth)
                {
                    case 1:
                        attack(enemy, figther);    // Opción de atacar                    
                        break;
                    case 2:
                        changePokemon();      // Opción para cambiar de Pokémon
                        break;
                    case 3:
                        capture();                // Opción para capturar al Pokémon
                        break;
                    case 4:
                        escape();                // Opción para huir del combate
                        break;
                    default:
                        Console.WriteLine("Esa opción no es válida!");
                        break;
                }
            } while (mfigth != 4);
        }


        public void attack(int enemy, int figther) // Se ejecuta mi ataque y el del enemigo
        {
            if ((myPokemons[figther].GetSpeed() >= enemyPokemons[enemy].GetSpeed())) // Ataco primero si mi Pokémon es mas rápido
            {
                enemyPokemons[enemy].SetHp(enemyPokemons[enemy].GetHp() - damage());
                myPokemons[figther].SetHp(myPokemons[figther].GetHp() - enemyDamage());
                if (enemyPokemons[enemy].GetHp() < 0 || myPokemons[figther].GetHp() < 0)
                {
                    if(enemyPokemons[enemy].GetHp() < 0)
                    {
                        enemyPokemons[enemy].SetHp(0);
                    }
                    else
                    {
                        myPokemons[figther].SetHp(0);
                    }
                }
                Console.WriteLine("La vida de " + myPokemons[figther].GetName() + " es " + myPokemons[figther].GetHp());                
                Console.WriteLine("La vida de " + enemyPokemons[enemy].GetName() + " es " + enemyPokemons[enemy].GetHp());
            }
            else // Ataco segundo si el Pokémon enemigo es mas rápido
            {
                myPokemons[figther].SetHp(myPokemons[figther].GetHp() - enemyDamage());
                enemyPokemons[enemy].SetHp(enemyPokemons[enemy].GetHp() - damage());
                if (enemyPokemons[enemy].GetHp() < 0 || myPokemons[figther].GetHp() < 0)
                {
                    if (enemyPokemons[enemy].GetHp() < 0)
                    {
                        enemyPokemons[enemy].SetHp(0);
                    }
                    else
                    {
                        myPokemons[figther].SetHp(0);
                    }
                }
                Console.WriteLine("La vida de " + myPokemons[figther].GetName() + " es " + myPokemons[figther].GetHp());                
                Console.WriteLine("La vida de " + enemyPokemons[enemy].GetName() + " es " + enemyPokemons[enemy].GetHp());
            }
            if (myPokemons[figther].GetHp() <= 0 || enemyPokemons[enemy].GetHp() <= 0)
            {
                if (myPokemons[figther].GetHp() <= 0)
                {                    
                    Console.WriteLine("El Pokémon " + myPokemons[figther].GetName() + " se ha debilitado");
                    Console.WriteLine("Has perdido el combate");                    
                    changePokemon();
                }
                else
                {
                    Console.WriteLine("El Pokémon " + enemyPokemons[enemy].GetName() + " se ha debilitado");
                    Console.WriteLine("Has ganado el combate");                    
                }
                MainMenu();
            }
        }
        public int damage() //Función para mi ataque
        {
            Random random = new Random();
            double rand = random.Next(85, 101);
            double damage = (((2 * myPokemons[figther].GetMoves()[0].GetPower() * (myPokemons[figther].GetAtk() / enemyPokemons[enemy].GetDef()) / 50) + 2) * (rand / 100) * critical()); // Formula para atacar
            return (int)damage;
        }
        public int enemyDamage() // Función para el ataque del enemigo
        {
            Random random = new Random();
            double rand = random.Next(85, 101);
            double damage = (((2 * enemyPokemons[enemy].GetMoves()[0].GetPower() * (enemyPokemons[enemy].GetAtk() / myPokemons[figther].GetDef()) / 50) + 2) * (rand / 100) * critical());
            return (int)damage;
        }
        public double critical() // Función de golpe crítico
        {
            Random random = new Random();
            double crit = random.Next(1, 25);
            if (crit == 1)
            {
                return 1.5;
            }
            else
            {
                return 1;
            }
        }
        public void escape() // Función para escapar del combate
        {
            int counterEscape = 0;
            if ((myPokemons[figther].GetSpeed() >= enemyPokemons[enemy].GetSpeed()))
            {
                Console.WriteLine("Has conseguido escapar de " + enemyPokemons[enemy].GetName());
                MainMenu();
            }
            else
            {
                int escapeOp;
                Random escapeOption = new Random();
                escapeOp = escapeOption.Next(0, 255);
                ++counterEscape;
                int oddsEscape = (((myPokemons[figther].GetSpeed() * 128) / enemyPokemons[enemy].GetSpeed()) + 30 * counterEscape) % 256; // Formula para escapar del combate
                if (escapeOp < oddsEscape)
                {
                    Console.WriteLine("Has conseguido escapar de " + enemyPokemons[enemy].GetName());
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("No has conseguido huir");
                    Console.WriteLine(enemyPokemons[enemy].GetName() + " te ha atacado");
                    myPokemons[figther].SetHp(myPokemons[figther].GetHp() - enemyDamage());
                    Console.WriteLine("La vida de " + myPokemons[figther].GetName() + " es " + myPokemons[figther].GetHp());
                    menuInTheFigth();
                }
            }
        }
        public void changePokemon() // Función para cambiar el Pokémon en el combate
        {
            Console.ForegroundColor = ConsoleColor.Gray;            
            int counter = 0;
            for (int cpoke = 0; cpoke < myPokemons.Length; ++cpoke)
            {
                if (myPokemons[cpoke] != null && myPokemons[cpoke].GetHp() > 0)
                {
                    Console.WriteLine("Tus Pokémon para luchar son:");
                    string choosefigth2 = ((cpoke + 1) + ") " + myPokemons[cpoke].GetName() + " (" + myPokemons[cpoke].getType() + ") Nivel: " + myPokemons[cpoke].GetLevel() + " Vida: " + myPokemons[cpoke].GetHp() + "\n");
                    IO.SlowWrite(choosefigth2, 25);
                    ++counter;
                }
            }            
            if (counter > 0)
            { 
                do
                {
                    do
                    {
                        string choosefpok = ("¿Con cual Pokémon continuas el combate? \n");
                        IO.SlowWrite(choosefpok, 25);
                        figther = IO.intToString() - 1;
                    } while (myPokemons[figther] == null);
                } while (myPokemons[figther].GetHp() <= 0);
                menuInTheFigth();
            }
            else
            {
                Console.WriteLine("Todos tus Pokémons estan debilitados, te mandamos al centro Pokémon mas cercano"); // Opción para mandar al Centro Pokémon cuando tus Pokémons estan debilitados y no tienes nadie para elegir
                pokemonCenter();
            }
        }
        public void capture() // Función para capturar los Pokémons enemigos
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            int captureAg;
            Random captureRandom = new Random();
            captureAg = captureRandom.Next(0, 65536);
            int rcm = (((3 * enemyPokemons[enemy].GetMaxHP() - (2 * enemyPokemons[enemy].GetHp()) * 4096 * enemyPokemons[enemy].GenerateCatchRate())) / (3 * enemyPokemons[enemy].GetMaxHP()));
            double ag = (65536 / (Math.Pow((255 / rcm), 0.1875)));
            for (int index = 0; index < 4; ++index)
            {
                if (captureAg >= ag)
                {
                    Console.WriteLine("El Pokémon se ha escapado de tu Pokeball");
                    Console.WriteLine(enemyPokemons[enemy].GetName() + " te ha atacado");
                    myPokemons[figther].SetHp(myPokemons[figther].GetHp() - enemyDamage());
                    Console.WriteLine("La vida de " + myPokemons[figther].GetName() + " es " + myPokemons[figther].GetHp());
                    menuInTheFigth();
                }
            }
            Console.WriteLine("El Pokémon ha sido capturado");            
            AddToMyPokemons();
        }
        public void AddToMyPokemons() // Función para añadir el Pokémon a tu equipo o la caja
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int add = 0; add < myPokemons.Length; ++add)
            {
                if (myPokemons[add] == null) // Añade el Pokémon al hueco vacio
                {
                    enemyPokemons[enemy].SetDate(DateTime.Now);
                    myPokemons[add] = enemyPokemons[enemy];
                    myPokemons[add].SetEO(trainer.GetId());
                    Console.WriteLine("Hemos añadido el Pokémon a tu equipo");
                    MainMenu();
                }
            }
            for (int add = 0; add < myPokemons.Length; ++add)
            {
                if (myPokemons[myPokemons.Length - 1] != null) // Mi equipo esta lleno, lo añade a la caja
                {
                    Console.WriteLine(trainer.GetName() + " tu equipo esta lleno, ¿deseas cambiar alguno de tus Pokémons por " + enemyPokemons[enemy].GetName() + "?");
                    Console.WriteLine("\t 1) Si \n \t 2) No");
                    int addoption = int.Parse(Console.ReadLine());
                    if (addoption == 1)
                    {
                        for (int i = 0; i < myPokemons.Length; ++i)
                        {
                            if (myPokemons[i] != null)
                            {
                                string mypokestats = ((i + 1) + ") Nombre: " + myPokemons[i].GetName() + " Tipo: " + myPokemons[i].getType() + " Género: " + myPokemons[i].GetGender() + " Nivel: " + myPokemons[i].GetLevel() + " Vida: " + myPokemons[i].GetHp() + "\n");
                                IO.SlowWrite(mypokestats, 25);
                            }
                        }
                        Console.WriteLine("¿Por cual Pokémon lo quieres sustituir?");
                        int changeadd = int.Parse(Console.ReadLine());
                        switch (changeadd) // Distintas opciones para sustituir en nuestro equipo
                        {
                            case 1:
                                myPokemons[0] = enemyPokemons[enemy];
                                myPokemons[0].SetEO(trainer.GetId());
                                Console.WriteLine("El Pokémon se ha añadido correctamente a la equipo");
                                MainMenu();
                                break;
                            case 2:
                                myPokemons[1] = enemyPokemons[enemy];
                                myPokemons[1].SetEO(trainer.GetId());
                                Console.WriteLine("El Pokémon se ha añadido correctamente a la equipo");
                                MainMenu();
                                break;
                            case 3:
                                myPokemons[2] = enemyPokemons[enemy];
                                myPokemons[2].SetEO(trainer.GetId());
                                Console.WriteLine("El Pokémon se ha añadido correctamente a la equipo");
                                MainMenu();
                                break;
                            case 4:
                                myPokemons[3] = enemyPokemons[enemy];
                                myPokemons[3].SetEO(trainer.GetId());
                                Console.WriteLine("El Pokémon se ha añadido correctamente a la equipo");
                                MainMenu();
                                break;
                            case 5:
                                myPokemons[4] = enemyPokemons[enemy];
                                myPokemons[4].SetEO(trainer.GetId());
                                Console.WriteLine("El Pokémon se ha añadido correctamente a la equipo");
                                MainMenu();
                                break;
                            case 6:
                                myPokemons[5] = enemyPokemons[enemy];
                                myPokemons[5].SetEO(trainer.GetId());
                                Console.WriteLine("El Pokémon se ha añadido correctamente a la equipo");
                                MainMenu();
                                break;
                            default:
                                Console.WriteLine("No has introducido el número válido \n");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Como el equipo esta lleno, lo mandaremos a tu caja");
                        for (int i = 0; i < boxes.Length; i += 1)
                        {
                            for (int j = 0; j < boxes[i].Length; j += 1)
                            {
                                if (boxes[i][j] == null)
                                {
                                    enemyPokemons[enemy].SetDate(DateTime.Now);
                                    boxes[i][j] = enemyPokemons[enemy];
                                    boxes[i][j].SetEO(trainer.GetId());
                                    Console.WriteLine("Se ha añadido correctamente");
                                    MainMenu();
                                }
                            }
                        }
                    }
                }
            }
        }
        public void myPlayer() // Función datos de mi jugador
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string infoplayer = ("Nombre: " + trainer.GetName() + "\nGénero: " + trainer.GetGender() + "\nPokedolar: " + trainer.GetPokedolar() + " $ \nPuntos de batalla: " + trainer.GetBattlepoint() + " © \nPokemillas: " + trainer.GetPokemilles() + " ¥ \nID: " + trainer.GetId() + " \nHora de creación: " + trainer.GetCreateDate());
            IO.SlowWrite(infoplayer, 25);
            int backOrNot = 0;
            do
            {
                string backmenu = ("\nIntroduce 1 cuando quieras volver al menú principal \n");
                IO.SlowWrite(backmenu, 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                backOrNot = IO.intToString();
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (backOrNot)
                {
                    case 1:
                        MainMenu();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    default: // Vuelve a preguntar por si se pone un número que no esta en las opciones
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No has introducido el número válido \n");
                        break;
                }
            } while (backOrNot != 1);
        }
        public string askgender() // Función para el género
        {
            int genderplayer = 0;
            do
            {
                string Gender = "¿Como te identificas? \n 1) Hombre \n 2) Mujer \n 3) Chique \n";
                IO.SlowWrite(Gender, 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                genderplayer = IO.intToString();
                trainer.SetGender(trainer.GenerateGender(genderplayer));
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (genderplayer)
                {
                    case 1:
                        return "♂";
                    case 2:
                        return "♀";
                    case 3:
                        return "♂♀";
                    default: // Vuelve a preguntar por si se pone un número que no esta en las opciones
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No has introducido el número válido \n");
                        break;
                }
            } while (genderplayer != 3);
            return askgender();
        }
        public void myBoxes() // Función para ver mis cajas
        {           
            Console.ForegroundColor = ConsoleColor.Yellow;
            int counter = 0;
            for (int i = 0; i < boxes.Length; i += 1)
            {
                for (int j = 0; j < boxes[i].Length; j += 1)                    
                {
                    if (boxes[i][j] != null)
                    {
                        if(j == 0) { Console.WriteLine("Caja " + (i + 1)); }
                        Console.Write("Posición " + (j + 1) + ": ");
                        string boxdata = ("Nombre: " + boxes[i][j].GetName() + " Tipo: " + boxes[i][j].getType() + " Vida actual: " + boxes[i][j].GetHp() + " Vida máxima: " + boxes[i][j].GetMaxHP() + "\n");
                        IO.SlowWrite(boxdata, 25);
                    }
                    else if (boxes[i][j] == null)
                    {                        
                        ++counter;
                    }
                }
            }

            if(counter == 960)
            {
                Console.WriteLine("Tus cajas estan vacias, no hay nada para ver, te devolvemos al menú principal");
                MainMenu();
            }
            string fulledition = ("¿Quieres toda la info de tus Pokémons?\n1) Si\n2) No\n");
            IO.SlowWrite(fulledition, 25);
            int option = IO.intToString();
            switch (option)
            {
                case 1:
                    for (int i = 0; i < boxes.Length; i += 1)
                    {
                        for (int j = 0; j < boxes[i].Length; j += 1)
                        {
                            if (boxes[i][j] != null)
                            {
                                if (j == 0) { Console.WriteLine("Caja " + (i + 1)); }
                                Console.Write("Posición " + (j + 1) + ": ");
                                string fulleditionpok = ("Nombre: " + boxes[i][j].GetName() + " ID: " + boxes[i][j].GetId() + " Género: " + boxes[i][j].GetGender() + " Tipo: " + boxes[i][j].getType() + " Nivel: " + boxes[i][j].GetLevel() + " Vida actual: " + boxes[i][j].GetHp() + " Vida máxima: " + boxes[i][j].GetMaxHP() + " EO: " + boxes[i][j].GetEO() + " " + boxes[i][j].GetDate() + "\n");
                                IO.SlowWrite(fulleditionpok, 25);
                            }                                
                        }
                    }
                    break;
                case 2:
                    string negfulledition = ("De acuerdo, te devolvemos al menú principal\n");
                    IO.SlowWrite(negfulledition, 25);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    MainMenu();
                    break;
                default: // Vuelve a preguntar por si se pone un número que no esta en las opciones
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No has introducido el número válido \n");
                    break;
            }
        }
        public IndividualPokemon[] InitPokemons() // Pokemons iniciales
        {
            IndividualPokemon[] initPokemons = new IndividualPokemon[3];
            initPokemons[0] = new IndividualPokemon(new SpeciesPokemon("Bulbasaur", "Planta", 001, 5, 45, 49, 49, 65, 65, 45, 45));
            initPokemons[1] = new IndividualPokemon(new SpeciesPokemon("Squirtle", "Agua", 007, 5, 44, 48, 65, 50, 64, 43, 44));
            initPokemons[2] = new IndividualPokemon(new SpeciesPokemon("Charmander", "Fuego", 004, 5, 39, 52, 43, 60, 50, 65, 39));
            return initPokemons;
        }
        public IndividualPokemon[] EnemyPokemons() // Pokemons enemigos 
        {
            IndividualPokemon[] enemyPokemons = new IndividualPokemon[151];
            enemyPokemons[0] = new IndividualPokemon(new SpeciesPokemon("Pidgey", "Volador", 016, 5, 40, 45, 40, 35, 35, 56, 40));
            enemyPokemons[1] = new IndividualPokemon(new SpeciesPokemon("Caterpie", "Bicho", 010, 5, 45, 30, 35, 20, 20, 45, 45));
            enemyPokemons[2] = new IndividualPokemon(new SpeciesPokemon("Rattata", "Normal", 019, 5, 30, 56, 35, 25, 35, 72, 30));
            enemyPokemons[3] = new IndividualPokemon(new SpeciesPokemon("Bulbasaur", "Planta", 001, 5, 45, 49, 49, 65, 65, 45, 45));
            enemyPokemons[4] = new IndividualPokemon(new SpeciesPokemon("Squirtle", "Agua", 007, 5, 44, 48, 65, 50, 64, 43, 44));
            enemyPokemons[5] = new IndividualPokemon(new SpeciesPokemon("Charmander", "Fuego", 004, 5, 39, 52, 43, 60, 50, 65, 39));
            return enemyPokemons;
        }
        public Moves[] movements() // Lista de nuestros movimientos
        {
            Moves[] moves = new Moves[30];
            moves[0] = new Moves("Especial", "Burbuja", 40, 30, 100, 0);
            moves[1] = new Moves("Especial", "Pistola Agua", 40, 25, 100, 0);
            moves[2] = new Moves("Especial", "Rayo Burbuja", 65, 20, 100, 0);
            moves[3] = new Moves("Especial", "Surf", 90, 15, 100, 0);
            moves[4] = new Moves("Físico", "Doble Ataque", 25, 20, 100, 0);
            moves[5] = new Moves("Especial", "Impactrueno", 40, 30, 100, 0);
            moves[6] = new Moves("Especial", "Rayo", 90, 15, 100, 0);
            moves[7] = new Moves("Especial", "Trueno", 110, 10, 70, 0);
            moves[8] = new Moves("Especial", "Ascuas", 40, 25, 100, 0);
            moves[9] = new Moves("Especial", "Lanzallamas", 90, 15, 100, 0);
            moves[10] = new Moves("Especial", "Llamarada", 110, 5, 85, 0);
            moves[11] = new Moves("Físico", "Puño Fuego", 75, 15, 100, 0);
            moves[12] = new Moves("Físico", "Puño Hielo", 75, 15, 100, 0);
            moves[13] = new Moves("Físico", "Doble Patada", 30, 30, 100, 0);
            moves[14] = new Moves("Físico", "Arañazo", 40, 35, 100, 0);
            moves[15] = new Moves("Físico", "Ataque Rápido", 40, 30, 100, 0);
            moves[16] = new Moves("Físico", "Corte", 50, 30, 95, 0);
            moves[17] = new Moves("Especial", "Hiper Rayo", 150, 5, 90, 0);
            moves[18] = new Moves("Físico", "Mordisco", 60, 25, 100, 0);
            moves[19] = new Moves("Físico", "Placaje", 40, 35, 100, 0);
            moves[20] = new Moves("Físico", "Hoja Afiliada", 55, 25, 95, 0);
            moves[21] = new Moves("Físico", "Látigo Cepa", 45, 25, 100, 0);
            moves[22] = new Moves("Especial", "Rayo Solar", 120, 10, 100, 0);
            moves[23] = new Moves("Físico", "Ataque Ala", 60, 35, 100, 0);
            moves[24] = new Moves("Físico", "Picotazo", 35, 35, 100, 0);
            moves[25] = new Moves("Físico", "Vuelo", 90, 15, 95, 0);
            moves[26] = new Moves("Especial", "Polución", 30, 20, 70, 0);
            moves[27] = new Moves("Especial", "Ácido", 40, 30, 100, 0);
            moves[28] = new Moves("Físico", "Lanzarrocas", 50, 15, 90, 0);
            moves[29] = new Moves("Físico", "Excavar", 80, 10, 100, 0);
            return moves;
        }
        public void exit() // Función salida del juego
        {
            Environment.Exit(0);
        }
    }
}
