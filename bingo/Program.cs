using bingo;

class Bingo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select the number of plader (max 3)");
        string plader = Console.ReadLine();

        //get copy object Plader
        var allPlades = new Plader();

        List<List<string[]>> gamePlade = new List<List<string[]>>();

        switch (plader)
        {
            case "1":
                gamePlade.Add(allPlades.ID1);
                break;

            case "2":
                gamePlade.Add(allPlades.ID1);
                gamePlade.Add(allPlades.ID2);
                break;

            case "3":
                gamePlade.Add(allPlades.ID1);
                gamePlade.Add(allPlades.ID2);
                gamePlade.Add(allPlades.ID3);
                break;

            default:
                Console.WriteLine("Invalid input");
                return;
        }

        Console.WriteLine("Selected plader:");
        foreach (var list in gamePlade)
        {
            foreach (var row in list)
            {
                Console.WriteLine(string.Join(", ", row)); 
            }
            Console.WriteLine(); 
        }
        StartGame(gamePlade);
    }

    static void StartGame(List<List<string[]>> plader)
    {
        var calledNumbers = new List<string>();
        bool hasWinner = false;
        int drawnNumber;
        while (true)
        {
            Console.WriteLine("Enter a number between 1 and 90:");
            if (!int.TryParse(Console.ReadLine(), out drawnNumber) || drawnNumber <= 1 || drawnNumber >= 90)
            {
                Console.WriteLine("Invalid number");
                continue;
            }

            string num = drawnNumber.ToString();

            if (!calledNumbers.Contains(num))
            {
                calledNumbers.Add(num);
            }
            Console.Clear();
            Console.WriteLine($" Drawn number: {num} \n Updated plader:");

            foreach (var plade in plader)
            {
                foreach (var row in plade)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (calledNumbers.Contains(row[i]))
                        {
                            Console.Write("X\t"); 
                            row[i] = "X"; 
                        }
                        else
                        {
                            Console.Write(row[i] + "\t"); 
                        }
                    }
                    Console.WriteLine();
                    if (row.All(x => x.Contains("X")))
                    {
                        hasWinner = true;
                    }
                }
                Console.WriteLine();
            }
            if (hasWinner)
            {
                Console.WriteLine("We have a winner,  tillyke!");
                break;
            }
            Console.WriteLine();
        }
    }
}
