using MarsRover.Interface;

namespace MarsRover.Model;

public class Rover
{
    private readonly ICommand _command;
    public Position Position { get; set; }
    private Position LastPosition { get; set; }
    

    public Rover(Position _position, ICommand command)
    {
        Position = _position;
        _command = command;
    }

    public Position ExplorePlateu(Plateu plateu,string commands)
    {
        foreach (var command in commands)
        {
            LastPosition = this.Position;
            switch (command)
            {
                case 'M':
                    this.Position = _command.MoveForward(this.Position);
                    break;
                case 'L':
                    this.Position = _command.TurnLeft(this.Position);
                    break;
                case 'R':
                    this.Position = _command.TurnRight(this.Position);
                    break;
            }

            if (Position.xCoordinate < 0 || Position.xCoordinate > plateu.xRange ||
                Position.yCoordinate < 0 || Position.yCoordinate > plateu.yRange)
            {
                return LastPosition;
            }
        }
        
        return this.Position;

    }
    
    
}