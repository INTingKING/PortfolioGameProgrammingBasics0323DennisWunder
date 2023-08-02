using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    internal class Game
    {


        public static void Main(string[] args)
        {
            bool gameLoop = true;
            //make a try parse funktion for user entry


            int MAP_WIDTH = 0;
            int MAP_HEIGHT = 0;//magic number to start a loop

            Console.WriteLine("use key arrows to control ur charakter which is a circle :)\nYour mission is to collect the key K and escape the room through the door D\npress a key to enter the game");
            Console.ReadKey(true);


            MAP_HEIGHT = InputParseInt(MAP_HEIGHT, "height");

            MAP_WIDTH = InputParseInt(MAP_WIDTH, "width");



            Random random = new Random();

            List<int> emptyMapSave = new List<int>();
            List<int> wallMapSave = new List<int>();


            int[] map = new int[MAP_WIDTH * MAP_HEIGHT];
            for (int y = 0; y < MAP_HEIGHT; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    //makes the walls (1)
                    if (y == 1 || x == 1 || x == (MAP_WIDTH - 2) || y == (MAP_HEIGHT - 2))
                    {
                        map[(y * MAP_WIDTH) + x] = 1;
                    }
                    //makes the exit field (5)
                    if (y == 0 || x == 0 || x == (MAP_WIDTH - 1) || y == (MAP_HEIGHT - 1))
                    {
                        map[(y * MAP_WIDTH) + x] = 5;
                    }
                    //lists the position of the empty spaces
                    if (map[(y * MAP_WIDTH) + x] == 0)
                    {
                        emptyMapSave.Add((y * MAP_WIDTH) + x);
                    }
                }
            }

            //spawns the player at a random position
            int playerEmptyMapSaveValue = random.Next(emptyMapSave.Count);
            int playerPos = emptyMapSave[playerEmptyMapSaveValue];
            map[playerPos] = 2;

            //spawns the key at a random position
            int keyPos = random.Next(emptyMapSave.Count);
            while (true)
            {
                if (keyPos != playerEmptyMapSaveValue)
                {
                    break;
                }
                keyPos = random.Next(emptyMapSave.Count);
            }

            map[emptyMapSave[keyPos]] = 3;








            //spawns the door on a random outer wall
            for (int y = 0; y < MAP_HEIGHT; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    if (map[(y * MAP_WIDTH) + x] == 1)
                    {
                        // does not include the square wall corners
                        if ((y * MAP_WIDTH) + x != MAP_WIDTH + 1 && (y * MAP_WIDTH) + x != ((MAP_WIDTH * 2) - 2) && (y * MAP_WIDTH) + x != MAP_WIDTH * (MAP_HEIGHT - 1) - 2 && (y * MAP_WIDTH) + x != MAP_WIDTH * (MAP_HEIGHT - 2) + 1)
                        {
                            //wall list that includes all outer walls except corners
                            wallMapSave.Add((y * MAP_WIDTH) + x);
                        }

                    }

                }
            }

            int doorPos = random.Next(wallMapSave.Count);
            map[wallMapSave[doorPos]] = 4;


            int counter = 0;
            for (int i = 0; i < playerPos / MAP_WIDTH; i++)
            {
                counter++;
            }
            int playerPosX = (playerPos % MAP_WIDTH) + counter;
            int playerPosY = (playerPos / MAP_WIDTH);


            //places maze walls
            List<int> mazeSpaceList = new List<int>();
            bool checker = false;
            bool checkered = false;

            for (int y = 0; y < MAP_HEIGHT; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    if (map[(y * MAP_WIDTH) + x] == 0)
                    {
                        mazeSpaceList.Add((y * MAP_WIDTH) + x);
                    }
                }
            }

            while (checkered == false)
            {
                checker = false;
                
                for (int i = 0; i < mazeSpaceList.Count; i++)
                {
                    int r = random.Next(0, 5);
                    if (r == 0 || r == 1 )
                    {
                        map[mazeSpaceList[i]] = 1;
                    }
                }
                Console.Clear();
                //Render(map, MAP_HEIGHT, MAP_WIDTH);


                MapChecker mapChecker = new MapChecker();
                checkered = mapChecker.MapCheck(MAP_HEIGHT, MAP_WIDTH, map, checker);
                if (checkered == true)
                {

                    break;
                }
                if (checkered == false)
                {
                    for (int y = 0; y < MAP_HEIGHT; y++)
                    {
                        for (int x = 0; x < MAP_WIDTH; x++)
                        {
                            if (map[y * MAP_WIDTH + x] == 1)
                            {
                                map[y * MAP_WIDTH + x] = 0;
                            }
                        }

                    }
                    Console.Clear();
                    //Render(map,MAP_HEIGHT, MAP_WIDTH);
                    for (int y = 0; y < MAP_HEIGHT; y++)
                    {
                        for (int x = 0; x < MAP_WIDTH; x++)
                        {
                            //makes the walls (1)
                            if (y == 1 || x == 1 || x == (MAP_WIDTH - 2) || y == (MAP_HEIGHT - 2))
                            {
                                map[(y * MAP_WIDTH) + x] = 1;
                            }
                            //makes the exit field (5)
                            if (y == 0 || x == 0 || x == (MAP_WIDTH - 1) || y == (MAP_HEIGHT - 1))
                            {
                                map[(y * MAP_WIDTH) + x] = 5;
                            }
                        }
                    }
                    Console.Clear();
                    //Render(map, MAP_HEIGHT, MAP_WIDTH);
                    map[wallMapSave[doorPos]] = 4;

                }
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    for (int x = 0; x < MAP_WIDTH; x++)
                    {
                        if (map[y * MAP_WIDTH + x] == 2)
                        {
                            map[y * MAP_WIDTH + x] = 0;
                        }
                    }
                }
                map[playerPos] = 2;
                Console.Clear();
                //Render(map, MAP_HEIGHT, MAP_WIDTH);
            }

            if (checkered == true)
            {
                for(int y = 0;y < MAP_HEIGHT; y++)
                {
                    for (int x = 0; x < MAP_WIDTH; x++)
                    {
                        if (map[y * MAP_WIDTH + x] == 2)
                        {
                            map[y * MAP_WIDTH + x] = 0;
                        }
                    }
                }
                
                map[playerPos] = 2;
            }
            Console.Clear();

            Render(map, MAP_HEIGHT, MAP_WIDTH);

            Movement(gameLoop, ref playerPosX, ref playerPosY, map, MAP_HEIGHT, MAP_WIDTH);

        }

        private static int InputParseInt(int parsedNumber, string transformDirection)
        {
            if (transformDirection == "height")
            {
                while (30 == parsedNumber || 30 < parsedNumber || parsedNumber < 10)
                {
                    
                        Console.Clear();
                        Console.WriteLine($"Please enter a value for {transformDirection}: \n(10-29)");
                        int.TryParse(Console.ReadLine(), out parsedNumber);
                    
                }
                Console.Clear();
                return parsedNumber;
            }
            else if (transformDirection == "width")
            {
                while (60 == parsedNumber || 60 < parsedNumber || parsedNumber < 10)
                {

                    Console.Clear();
                    Console.WriteLine($"Please enter a value for {transformDirection}: \n(10-59)");
                    int.TryParse(Console.ReadLine(), out parsedNumber);

                }
                Console.Clear();
                return parsedNumber;
            }
            return 0;
        }

        //Movement and movement checks(looking if movements are possible)
        private static void Movement(bool gameLoop, ref int playerPosX, ref int playerPosY, int[] map, int _mapHeight, int _mapWidth)
        {

            bool boolKey = false;
            bool closeProgram = false;
            while (gameLoop == true)
            {

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        int leftCheck = (playerPosY * (_mapWidth - 1)) + (playerPosX - 1);
                        if (map[leftCheck] != 1 && map[leftCheck] != 4)
                        {
                            if (map[leftCheck] == 3)
                            {
                                boolKey = true;
                            }


                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 0;
                            playerPosX -= 1;
                            if (map[(playerPosY * (_mapWidth - 1)) + playerPosX] == 5)
                            {

                                gameLoop = false;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        else if (map[leftCheck] == 4 && boolKey == true)
                        {
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 0;
                            playerPosX -= 1;
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        int rightCheck = (playerPosY * (_mapWidth - 1)) + (playerPosX + 1);
                        if (map[rightCheck] != 1 && map[rightCheck] != 4)
                        {
                            if (map[rightCheck] == 3)
                            {
                                boolKey = true;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + (playerPosX)] = 0;
                            playerPosX += 1;
                            if (map[(playerPosY * (_mapWidth - 1)) + playerPosX] == 5)
                            {
                                gameLoop = false;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        else if (map[rightCheck] == 4 && boolKey == true)
                        {
                            map[(playerPosY * (_mapWidth - 1)) + (playerPosX)] = 0;
                            playerPosX += 1;
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        int upCheck = ((playerPosY - 1) * (_mapWidth - 1)) + (playerPosX - 1);
                        if (map[upCheck] != 1 && map[upCheck] != 4)
                        {
                            if (map[upCheck] == 3)
                            {
                                boolKey = true;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + (playerPosX)] = 0;
                            playerPosY -= 1;
                            playerPosX -= 1;
                            if (map[(playerPosY * (_mapWidth - 1)) + playerPosX] == 5)
                            {

                                gameLoop = false;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        else if (map[upCheck] == 4 && boolKey == true)
                        {
                            map[(playerPosY * (_mapWidth - 1)) + (playerPosX)] = 0;
                            playerPosY -= 1;
                            playerPosX -= 1;
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        int downCheck = ((playerPosY + 1) * (_mapWidth - 1)) + (playerPosX + 1);
                        if (map[downCheck] != 1 && map[downCheck] != 4)
                        {
                            if (map[downCheck] == 3)
                            {
                                boolKey = true;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + (playerPosX)] = 0;
                            playerPosY += 1;
                            playerPosX += 1;
                            if (map[(playerPosY * (_mapWidth - 1)) + playerPosX] == 5)
                            {

                                gameLoop = false;
                            }
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        else if (map[downCheck] == 4 && boolKey == true)
                        {
                            map[(playerPosY * (_mapWidth - 1)) + (playerPosX)] = 0;
                            playerPosY += 1;
                            playerPosX += 1;
                            map[(playerPosY * (_mapWidth - 1)) + playerPosX] = 2;
                        }
                        break;

                    case ConsoleKey.Escape:
                        gameLoop = false;
                        closeProgram = true;
                        break;

                }



                Console.Clear();
                Render(map, _mapHeight, _mapWidth);
            }
            if (closeProgram == false)
            {
                Console.Clear();
                Console.WriteLine("You have escaped the room, congrats!");
                Console.ReadKey(true);
            }
        }

        //Renders the map
        public static void Render(int[] map, int _mapHeight, int _mapWidth)
        {
            for (int y = 0; y < _mapHeight; y++)
            {
                for (int x = 0; x < _mapWidth; x++)
                {

                    switch (map[(y * _mapWidth) + x])
                    {
                        case 0:
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("#");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("K");
                            break;
                        case 4:
                            Console.Write("D");
                            break;
                        case 5:
                            Console.Write(" ");
                            break;
                            //case 6:
                            //    //placeHolder for seed
                            //    break;
                    }

                }
                Console.WriteLine();
            }
        }
    }

}