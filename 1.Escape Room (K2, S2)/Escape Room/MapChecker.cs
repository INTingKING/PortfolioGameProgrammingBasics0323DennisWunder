using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    internal class MapChecker
    {
        
        
        public bool MapCheck(int MAP_HEIGHT, int MAP_WIDTH, int[] map, bool checker)
        {
            bool checkDoor = false;
            bool checkKey = false;
            Game game = new Game();
            
            
            //checks if excape is achievable
            
            while (checkDoor != true || checkKey != true)
            {

                bool resetWhile = false;
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    
                    for (int x = 0; x < MAP_WIDTH; x++)
                    {
                        if (map[y * MAP_WIDTH + x] == 2 )
                        {
                            if(map[(y * MAP_WIDTH) + (x - 1)] == 0)
                            {
                                map[(y * (MAP_WIDTH)) + (x - 1)] = 2;
                                resetWhile = true;
                            }
                            if(map[y * MAP_WIDTH + (x-1)] == 3)
                            {
                                if (checkKey == false)
                                {
                                    resetWhile = true;
                                }
                                checkKey = true;
                                map[(y * MAP_WIDTH) + (x - 1)] = 3;

                                
                            }
                            if(map[y * MAP_WIDTH + (x - 1)] == 4)
                            {
                                checkDoor = true;
                            }

                            if(map[(y * MAP_WIDTH) + (x + 1)] == 0)
                            {
                                map[(y * MAP_WIDTH) + (x + 1)] = 2;
                                resetWhile = true;
                            }
                            if (map[(y * MAP_WIDTH) + (x + 1)] == 3)
                            {
                                if (checkKey == false)
                                {
                                    resetWhile = true;
                                }
                                checkKey = true;
                                map[(y * MAP_WIDTH) + (x + 1)] = 3;
                                
                            }
                            if (map[(y * MAP_WIDTH) + (x + 1)] == 4)
                            {
                                checkDoor = true;
                            }

                            if (map[((y+1) * MAP_WIDTH) + x] == 0)
                            {
                                map[((y + 1) * MAP_WIDTH) + x] = 2;
                                resetWhile = true;
                            }
                            if(map[((y + 1) * MAP_WIDTH) + x] == 3)
                            {
                                if (checkKey == false)
                                {
                                    resetWhile = true;
                                }
                                checkKey = true;
                                map[((y + 1) * MAP_WIDTH) + x] = 3;
                                
                            }
                            if(map[((y + 1) * MAP_WIDTH) + x] == 4)
                            {
                                checkDoor = true;
                            }

                            if (map[((y - 1) * MAP_WIDTH) + x] == 0)
                            {
                                map[((y - 1) * MAP_WIDTH) + x] = 2;
                                resetWhile = true;
                            }
                            if(map[((y - 1) * MAP_WIDTH) + x] == 3)
                            {
                                if (checkKey == false)
                                {
                                    resetWhile = true;
                                }
                                checkKey = true;
                                map[((y - 1) * MAP_WIDTH) + x] = 3;
                                
                            }
                            if(map[((y - 1) * MAP_WIDTH) + x] == 4)
                            {
                                checkDoor = true;
                            }
                        }
                        if (checkKey == true)
                        {
                            if(map[y * MAP_WIDTH + x] == 3)
                            {
                                if (map[(y * MAP_WIDTH) + (x - 1)] == 0)
                                {
                                    map[(y * (MAP_WIDTH)) + (x - 1)] = 2;
                                    resetWhile = true;
                                }
                                if (map[y * MAP_WIDTH + (x - 1)] == 4)
                                {
                                    checkDoor = true;
                                }

                                if (map[(y * MAP_WIDTH) + (x + 1)] == 0)
                                {
                                    map[(y * MAP_WIDTH) + (x + 1)] = 2;
                                    resetWhile = true;
                                }
                                if (map[(y * MAP_WIDTH) + (x + 1)] == 4)
                                {
                                    checkDoor = true;
                                }

                                if (map[((y + 1) * MAP_WIDTH) + x] == 0)
                                {
                                    map[((y + 1) * MAP_WIDTH) + x] = 2;
                                    resetWhile = true;
                                }
                                if (map[((y + 1) * MAP_WIDTH) + x] == 4)
                                {
                                    checkDoor = true;
                                }

                                if (map[((y - 1) * MAP_WIDTH) + x] == 0)
                                {
                                    map[((y - 1) * MAP_WIDTH) + x] = 2;
                                    resetWhile = true;
                                }
                                if (map[((y - 1) * MAP_WIDTH) + x] == 4)
                                {
                                    checkDoor = true;
                                }
                            }
                        }
                        
                        
                    }
                }
                Console.Clear();
                Game.Render(map, MAP_HEIGHT, MAP_WIDTH);
                //System.Threading.Thread.Sleep(100);
                if (resetWhile == false)
                {
                    if (checkDoor == true && checkKey == true)
                    {
                        return true;
                    }
                    break;
                }
            }
            if (checkDoor == true && checkKey == true)
            {

                return true;
            }
            return false;
        }
        
    }
}
