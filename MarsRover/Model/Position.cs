
using MarsRover.Enums;

public class Position
{
    public Position(int xCoordinate, int yCoordinate)
    {
        this.xCoordinate = xCoordinate;
        this.yCoordinate = yCoordinate;
    }

    public int xCoordinate { set; get; }
    public int yCoordinate { set; get; }
    public EnumDirections Direction { set; get; }
    
}