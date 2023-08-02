using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    public static class Program
    {
        public static void Main()
        {
            float damage = 0f;
            float health = 0f;
            float hp1 = 0;
            float hp2 = 0;
            float ap1 = 0;
            float ap2 = 0;
            float dp1 = 0;
            float dp2 = 0;
            float sp1 = 0;
            float sp2 = 0;
            string species1 = "";
            string species2 = "";




            int raceChoice2;
            int raceChoice1;
            raceChoice1 = InputAnfrageInt("Choose you first monster:\n 1 - Orc\n 2 - Troll\n 3 - Goblin\n(choose by entering the number)");

            while (true)
            {
                raceChoice2 = InputAnfrageInt("Choose you second monster, you can't choose the same monster twice:\n 1 - Orc\n 2 - Troll\n 3 - Goblin\n(choose by entering the number)");
                if (raceChoice1 != raceChoice2) { break; }
            }
            switch (raceChoice1)
            {
                case 1:
                    species1 = "Orc";
                    break;
                case 2:
                    species1 = "Troll";
                    break;
                case 3:
                    species1 = "Goblin";
                    break;
            }
            switch (raceChoice2)
            {
                case 1:
                    species2 = "Orc";
                    break;
                case 2:
                    species2 = "Troll";
                    break;
                case 3:
                    species2 = "Goblin";
                    break;
            }
            int placeHolder;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want the preset stats(1) or make the stats yourself(2)?");
                int.TryParse(Console.ReadLine(), out placeHolder);
                if (placeHolder == 1 || placeHolder == 2)
                {
                    break;
                }
            }
            switch (placeHolder)
            {
                case 1:
                    hp1 = 5f;
                    hp2 = 6f;
                    ap1 = 1f;
                    ap2 = 2f;
                    dp1 = 1f;
                    dp2 = 0f;
                    sp1 = 2f;
                    sp2 = 1f;
                    break;

                case 2:
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(
                            species1 + "\n" +
                            "Health: " + hp1 + "\n" +
                            "Angriffsstärke: " + ap1 + "\n" +
                            "Verteidigung: " + dp1 + "\n" +
                            "Geschwindigkeit: " + sp1 + "\n" +
                            "\n" +
                            species2 + "\n" +
                            "Health: " + hp2 + "\n" +
                            "Angriffsstärke: " + ap2 + "\n" +
                            "Verteidigung: " + dp2 + "\n" +
                            "Geschwindigkeit: " + sp2
                        );

                        if (hp1 > 0)
                        {
                            if (ap1 > 0)
                            {
                                if (dp1 > 0)
                                {
                                    if (sp1 > 0)
                                    {
                                        if (hp2 > 0)
                                        {
                                            if (ap2 > 0)
                                            {
                                                if (dp2 > 0)
                                                {
                                                    if (sp2 > 0)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        sp2 = InputAnfrageFloat(species2 + " Speed(1-10): ");
                                                    }
                                                }
                                                else
                                                {
                                                    dp2 = InputAnfrageFloat(species2 + " Verteidigung(1-10): ");
                                                }
                                            }
                                            else
                                            {
                                                ap2 = InputAnfrageFloat(species2 + " Angriffsstärke(1-10): ");
                                            }
                                        }
                                        else
                                        {
                                            hp2 = InputAnfrageFloat(species2 + " Health(1-10): ");
                                        }
                                    }
                                    else
                                    {
                                        sp1 = InputAnfrageFloat(species1 + " Speed(1-10): ");
                                    }
                                }
                                else
                                {
                                    dp1 = InputAnfrageFloat(species1 + " Verteidigung(1-10): ");
                                }
                            }
                            else
                            {
                                ap1 = InputAnfrageFloat(species1 + " Angriffsstaräke(1-10): ");
                            }

                        }
                        else
                        {
                            hp1 = InputAnfrageFloat(species1 + " Health(1-10): ");
                        }

                    }

                    break;
            }
            Monster monster1 = new Monster(hp1, ap1, dp1, sp1, raceChoice1);
            Monster monster2 = new Monster(hp2, ap2, dp2, sp2, raceChoice2);




            if (monster1.Speed() > monster2.Speed())
            {
                int count = 0;
                while (true)
                {
                    count++;
                    monster2.HealthInfo();
                    damage = monster1.Attack(monster2);
                    health = monster2.HealthInfo();
                    if (health <= 0f)
                    {

                        Console.WriteLine($"The {monster1.Name()} has won! It took him {count} turns!");
                        break;
                    }

                    monster1.HealthInfo();
                    damage = monster2.Attack(monster1);
                    health = monster1.HealthInfo();
                    if (health <= 0f)
                    {

                        Console.WriteLine($"The {monster2.Name()} has won! It took him {count} turns!");
                        break;
                    }
                }
            }
            else
            {
                int count = 0;
                int bigNumber = 10000;
                while (true)
                {
                    count++;
                    monster1.HealthInfo();
                    damage = monster2.Attack(monster1);
                    health = monster1.HealthInfo();
                    if (health <= 0f)
                    {

                        Console.WriteLine($"The {monster2.Name()} has won! It took him {count} turns!");
                        break;
                    }

                    monster2.HealthInfo();
                    damage = monster1.Attack(monster2);
                    health = monster2.HealthInfo();
                    if (health <= 0f)
                    {

                        Console.WriteLine($"The {monster1.Name()} has won! It took him {count} turns!");
                        break;
                    }
                    if (count == bigNumber)
                    {
                        int placeHolderChoice;
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("The battle seems to be infinite, do you want to continue?\n - enter 1\nOr do you want to exit the application?\n - enter 2");
                            int.TryParse(Console.ReadLine(), out placeHolderChoice);
                            if (placeHolderChoice == 1 || placeHolderChoice == 2)
                            {
                                break;
                            }
                        }
                        if (placeHolderChoice == 1)
                        {
                            bigNumber = bigNumber + 10000;
                        }
                        if (placeHolderChoice == 2)
                        {
                            Environment.Exit(0);
                        }

                    }
                }
            }


            Console.WriteLine("Program has finished");
            Console.ReadKey();
        }

        private static float InputAnfrageFloat(string abfrage)
        {
            float number;
            while (true)
            {

                Console.WriteLine(abfrage);
                float.TryParse(Console.ReadLine(), out number);
                if (number < 11 && number > 0)
                {
                    break;
                }
            }
            return number;
        }
        private static int InputAnfrageInt(string abfrage)
        {
            int number;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(abfrage);
                int.TryParse(Console.ReadLine(), out number);
                if (number < 4 && number > 0)
                {
                    break;
                }
            }
            return number;
        }
    }
    public class Monster
    {
        private float HP;
        private float AP;
        private float DP;
        private float S;
        private string Race;
        private int RA;
        public Monster(float _health, float _attackPower, float _defensePower, float _speed, int _race)
        {
            this.HP = _health;
            this.AP = _attackPower;
            this.DP = _defensePower;
            this.S = _speed;
            switch (_race)
            {
                case 1:
                    Race = "Orc";
                    break;
                case 2:
                    Race = "Troll";
                    break;
                case 3:
                    Race = "Goblin";
                    break;
            }
            this.RA = _race;
        }
        public float HealthInfo()
        {
            if (HP < 0f)
            {
                HP = 0f;
            }
            Console.WriteLine($"The {Race}s health is {HP}");
            return HP;
        }
        public float LoseHealth(float _damage)
        {
            float damage = _damage - DP;
            HP = HP - damage;
            return damage;
        }
        public float Attack(Monster _monster)
        {
            switch (RA)
            {
                case 1:
                    Console.WriteLine($"The Orc swings his gigantic axe towards the {_monster.Name()}!");
                    break;
                case 2:
                    Console.WriteLine($"The Troll hammers his strong arms on the {_monster.Name()}!");
                    break;
                case 3:
                    Console.WriteLine($"The Goblin swiftly stabs the {_monster.Name()}!");
                    break;
            }
            Console.WriteLine($"The {_monster.Name()} loses {_monster.LoseHealth(AP)} healthpoint(s)");
            return AP;
        }
        public float Speed()
        {
            return S;
        }
        public string Name()
        {
            return Race;
        }
    }
}
