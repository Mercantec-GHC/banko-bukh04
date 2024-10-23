using bingo;

class Bingo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select amount of plader (max 4)");
        string? plader = Console.ReadLine();

        //get copy object Plader
        var allPlades = new Plader();

        List<(string name, List<string[]>)> gamePlades = new List<(string name, List<string[]>)>();

        switch (plader)
        {
            case "1":
                gamePlades.Add(("Have1", allPlades.Have1));
                break;

            case "2":
                gamePlades.Add(("Have1", allPlades.Have1));
                gamePlades.Add(("Have2", allPlades.Have2));
                break;

            case "3":
                gamePlades.Add(("Have1", allPlades.Have1));
                gamePlades.Add(("Have2", allPlades.Have2));
                gamePlades.Add(("Have3", allPlades.Have3));
                break;

            case "4":
                gamePlades.Add(("Have1", allPlades.Have1));
                gamePlades.Add(("Have2", allPlades.Have2));
                gamePlades.Add(("Have3", allPlades.Have3));
                gamePlades.Add(("Have4", allPlades.Have4));
                break;

            default:
                Console.WriteLine("Invalid input");
                return;
        }

        Console.WriteLine("Selected plader:");
        foreach (var (name, plade) in gamePlades)
        {
            Console.WriteLine(name);
            foreach (var row in plade)
            {
                Console.WriteLine(string.Join(", ", row));
            }
            Console.WriteLine();
        }

        StartGame(gamePlades);
    }

    static void StartGame(List<(string name, List<string[]>)> plader)
    {
        bool completeOneRow = false;
        bool completeTwoRow = false;
        int drawnNumber;
        var calledNumbers = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter a number between 1 and 90:");
            if (!int.TryParse(Console.ReadLine(), out drawnNumber) || drawnNumber < 1 || drawnNumber > 90)
            {
                Console.WriteLine("Invalid number");
                continue;
            }
            // Convert from int to string
            string num = drawnNumber.ToString();

            if (!calledNumbers.Contains(num))
            {
                calledNumbers.Add(num);
            }

            Console.Clear();
            Console.WriteLine($"Drawn number: {num} \nUpdated plader:");

            foreach (var (name, plade) in plader)
            {
                Console.WriteLine(name); 
                foreach (var row in plade)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (calledNumbers.Contains(row[i])) // Check if the drawn number is present in the current row of the plade
                        {
                            Console.Write("X\t"); // If the number is found in the called numbers, output 'X' instead of the number for that position
                            row[i] = "X"; // Replace the value in the array with 'X' to indicate that this number has been drawn
                        }
                        else
                        {
                            Console.Write(row[i] + "\t");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            // Checking winning combinations
            foreach (var (name, winnerPlade) in plader)
            {
                //Count how many rows have a complete row ("X" instead of a number)
                int completedRows = winnerPlade.Count(r => r.All(x => x == "X"));
                switch (completedRows)
                {
                    case 1:
                        // INFO: check if the marker was set to show the winner only once
                        if (!completeOneRow)
                        {
                            Console.WriteLine($"{name} have a full row, Tillyke!");
                            completeOneRow = true;
                        }
                        break;

                    case 2:
                        if (!completeTwoRow)
                        {
                            Console.WriteLine($"{name} have a full two rows, Tillyke!");
                            completeTwoRow = true;
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Bingo or Banko! {name} is winner. Game over");
                        return;
                }
            }
            Console.WriteLine();
        }
    }
}
