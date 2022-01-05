using MarsRover.Commands;
using MarsRover.Interface;
using MarsRover.Enums;
using MarsRover.Model;


ServiceProvider serviceProvider =
    new ServiceCollection().AddTransient<ICommand, Command>()
        .BuildServiceProvider();

var input = Console.ReadLine();

input += "\n" + Console.ReadLine();
input += "\n" + Console.ReadLine();
input += "\n" + Console.ReadLine();
input += "\n" + Console.ReadLine();

// var input = string.Format(@"5 5
// 1 2 N
// LMLMLMLMM
// 3 3 E
// MMRMMRMRRM");

GetRoverPosition(input);

void GetRoverPosition(string input)
{
    var values = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    var range = values[0].Split(" ");
    var plateu = CreatePlateu(range);

    for (int i = 1; i < values.Length; i++)
    {
        var position = CreatePosition(values[i].Split(" "), range);
        var commands = values[i + 1];

        var command = serviceProvider.GetService<ICommand>();
        var rover = new Rover(position, command);
        rover.ExplorePlateu(plateu, commands);
        Console.WriteLine($"{rover.Position.xCoordinate} {rover.Position.yCoordinate} {rover.Position.Direction}");
        i++;
    }
}

Plateu CreatePlateu(string[] plateuRanges)
{
    int x, y;
    if (plateuRanges[0] != null && int.TryParse(plateuRanges[0], out x))
        if (plateuRanges[1] != null && int.TryParse(plateuRanges[1], out y))
        {
            if (x > 0 && y > 0)
            {
                return new Plateu(x, y);
            }
        }

    throw new Exception("Plateu could not be created ");
}


Position CreatePosition(string[] position, string[] range)
{
    int x, y;
    if (position[0] != null && int.TryParse(position[0], out x))
        if (position[1] != null && int.TryParse(position[1], out y))
        {
            var directions = new string[] {"E", "S", "W", "N"};
            if (x > 0 && y > 0
                      && x <= Convert.ToInt32(range[0]) && y <= Convert.ToInt32(range[1])
                      && directions.Contains(position[2]))
            {
                var roverPosition = new Position(x, y);
                switch (position[2])
                {
                    case "S":
                        roverPosition.Direction = EnumDirections.S;
                        break;
                    case "W":
                        roverPosition.Direction = EnumDirections.W;
                        break;
                    case "N":
                        roverPosition.Direction = EnumDirections.N;
                        break;
                    default:
                        roverPosition.Direction = EnumDirections.E;
                        break;
                }

                return roverPosition;
            }
        }

    throw new Exception("Rover could not landed on the plateu");
}