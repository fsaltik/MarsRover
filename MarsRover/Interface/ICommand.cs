
namespace MarsRover.Interface;

public interface ICommand
{
    public Position TurnLeft(Position position);
    public Position TurnRight(Position position);
    public Position MoveForward(Position position);
}