namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            bool correctGuess = false;
            bool isRunning = true;

            while (isRunning)
            {
                int numberRange; 
                int maxAttempts;

                Console.WriteLine("Välkommen till NumbersGame!");
                Console.Write("\n" +
                              "\nVälj en svårighetsgrad 1-5: ");
                int difficulty = Convert.ToInt32(Console.ReadLine());

                switch (difficulty)
                {
                    case 1:
                        numberRange = 20;
                        maxAttempts = 6;
                        break;
                    case 2:
                        numberRange = 40;
                        maxAttempts = 5;
                        break;
                    case 3:
                        numberRange = 60;
                        maxAttempts = 4;
                        break;
                    case 4:
                        numberRange = 80;
                        maxAttempts = 3;
                        break;
                    case 5:
                        numberRange = 100;
                        maxAttempts = 2;
                        break;
                    default:
                        Console.WriteLine("Ogitligt svårighetsgrad!");
                        continue;

                }

                int randomNumber = random.Next(1, numberRange + 1); // +1 Allowes for full range guesses.

                Console.WriteLine($"\nJag tänker på ett nummer mellan 1-{numberRange}." +
                                  $"\nKan du gissa vilket? Du får {maxAttempts} försök!");

                for (int attempt = 1; attempt <= maxAttempts; attempt++)
                {
                    if (!int.TryParse(Console.ReadLine(), out int userGuess))
                    {
                        Console.WriteLine("Skriv ett heltal!");
                        continue;
                    }

                    Console.WriteLine();
                    correctGuess = CheckGuess(userGuess, randomNumber); 
                                                                        
                    if (correctGuess)
                    {
                        Console.WriteLine("Wohoo! Du klarade det!");
                        break;
                    }

                    if (attempt == maxAttempts)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {maxAttempts} försök! ");
                        Console.ReadKey();
                        break;
                    }
                }

                Console.WriteLine("\nVill du spela igen? Svara med ett ja.");
                string userRespons = Console.ReadLine();


                // Any key stroke apart from "ja" will end the loop.
                // To make sure any attempts of typing "ja" passes the check,
                // a conversion is made to lower case letters.

                string respons = userRespons.ToLower();

                if (respons != "ja")
                {
                    break;
                }

                Console.Clear();
            }
        }
                // Method: 
                // Handles two params (The random generated number, and the users number)
                // If the number is higher or lower the method will return false.
                // If the number is the same as the random number it returns true;
        static bool CheckGuess(int guess, int randomNumber)
        {
            if (guess < randomNumber)
            {
                Console.WriteLine("Tyvärr, du gissade för lågt!");
                return false;
            }
            if (guess > randomNumber)
            {
                Console.WriteLine("Tyvärr, du gissade för högt!");
                return false;
            }

            return true;
        }
    }
}
