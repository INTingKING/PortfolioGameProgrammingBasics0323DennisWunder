using System;

namespace Sortier_Algorithmen
{
    internal class RandomListAutomated
    {
        public static int[] RandomListMaker()
        {
            var rand = new Random();
            int lengthOfRandomNumberList = 0;
            int[] randomNumberArray;
            while (lengthOfRandomNumberList < 1 || lengthOfRandomNumberList > 10_000)
            {
                Console.Clear();
                Console.WriteLine("How long should the List of random numbers be?\n(1-10.000)");
                int.TryParse(Console.ReadLine(), out lengthOfRandomNumberList);
            }

            randomNumberArray = new int[lengthOfRandomNumberList];

            for (int i = 0; i < randomNumberArray.Length; i++)
            {
                randomNumberArray[i] = rand.Next(1, lengthOfRandomNumberList + 1);
                //Console.WriteLine(randomNumberArray[i]);
            }

            return randomNumberArray;
        }
    }
}
