using Riddle;

var game = new Riddle.Riddle();

while (true)
{
    Console.WriteLine("Entrez votre nombre :");
    string userInput = Console.ReadLine();

    string result = game.Guess(userInput);
    Console.WriteLine(result);

    if (result == "Correct !")
        break;
}

Console.WriteLine("Félicitations, vous avez gagné !");
