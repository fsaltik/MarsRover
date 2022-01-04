using MarsRover.Enums;
using MarsRover.Interface;

namespace MarsRover.Commands;

public class Command : ICommand
{
    public Position TurnLeft(Position position)
    {
        position.Direction =
            position.Direction == EnumDirections.E
                ? EnumDirections.N
                : (EnumDirections) (int) position.Direction - 1;
        return position;
    }

    public Position TurnRight(Position position)
    {
        position.Direction =
            position.Direction == EnumDirections.N
                ? EnumDirections.E
                : (EnumDirections) (int) position.Direction + 1;
        return position;
    }

    public Position MoveForward(Position position)
    {
        switch (position.Direction)
        {
            case EnumDirections.E :
                position.xCoordinate++;
                break;
            case EnumDirections.S :
                position.yCoordinate--;
                break;
            case EnumDirections.W :
                position.xCoordinate--;
                break;
            case EnumDirections.N :
                position.yCoordinate++;
                break;
        }

        return position;
    }
}