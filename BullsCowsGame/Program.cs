using System;

namespace BullsCowsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BullsCows();
        }
        public static void BullsCows()
        {
            Random rnd = new Random();
            int bullsInNumberTry = 0; // will be changed soon.
            int cowsInNumberTry = 0; // will be changed soon.
            int from = int.Parse(Console.ReadLine());
            int to = int.Parse(Console.ReadLine());
            int numberToGuess = 4956; //rnd.Next(from, to);
            Console.WriteLine(numberToGuess);
            int tryCounter = 0;
            while (bullsInNumberTry != 4)
            {
                int numberTry = GetValidNumber(from, to);
                bullsInNumberTry = CheckBulls(numberTry, numberToGuess);
                Console.WriteLine("B:{0}", bullsInNumberTry);
                cowsInNumberTry = CheckCows(numberTry, numberToGuess);
                Console.WriteLine("C:{0}", cowsInNumberTry);
                tryCounter++;
            }
            Console.WriteLine("Congrats. Tries: {0}", tryCounter);
        }
        public static int GetValidFrom()
        {
            int fromNumb = -1;
            while (fromNumb < 1000 && fromNumb > 9999)
            {
                fromNumb = int.Parse(Console.ReadLine());
            }
            return fromNumb;
        }
        public static int CheckBulls(int numberToCheckIn, int numberAimedGuess)
        {
            int countBulls = 0;
            while (numberToCheckIn > 0 && numberAimedGuess > 0)
            {
                int numberToCheckInCheck = numberToCheckIn % 10;
                int numberToCheckInNumberAimedG = numberAimedGuess % 10;
                numberToCheckIn /= 10;
                numberAimedGuess /= 10;
                if (numberToCheckInCheck == numberToCheckInNumberAimedG)
                    countBulls++;
            }
            return countBulls;
        }
        public static int CheckCows(int numberToCheckIn, int numberAimedGuess)
        {
            int dPlaceInNumber = 0;
            int countCows = 0;
            while (numberToCheckIn > 0)
            {
                int num = numberToCheckIn % 10;
                bool isContainsInNumToGuess = IsContains(num, dPlaceInNumber, numberAimedGuess);
                if (isContainsInNumToGuess)
                {
                    countCows++;
                }
                numberToCheckIn /= 10;
                dPlaceInNumber++;
            }
            return countCows;
        }
        public static bool IsContains(int numberInGuess, int digitnumPlaceNumber, int numberAimedToBeGuessed)
        {
            bool isFound = false;
            int digitTypeIndex = 0;
            while (numberAimedToBeGuessed > 0 && !isFound)
            {
                int numberToCheck = numberAimedToBeGuessed % 10;
                if (digitTypeIndex != digitnumPlaceNumber)
                {
                    if (numberToCheck == numberInGuess)
                        isFound = true;
                }
                numberAimedToBeGuessed /= 10;
                digitTypeIndex++;
            }
            return isFound;
        }
        public static int GetValidNumber(int fromAppropriative, int toAppropriative)
        {
            int number = -1;
            while (number < fromAppropriative || number > toAppropriative)
            {
                number = int.Parse(Console.ReadLine());
            }
            return number;
        }
    }
}
