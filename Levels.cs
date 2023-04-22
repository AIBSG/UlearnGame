namespace MagicBalls;

public class Levels
{
    public static TypeField[,] TestLevel1 =
    {
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground }
    };
    
    public static TypeField[,] TestLevel2 =
    {
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground },
        { TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground, TypeField.Ground }
    };

    public static Room TestRoom = new Room(TestLevel1, new[] { new Door(Direction.Left, TestRoom2) });
    public static Room TestRoom2 = new Room(TestLevel2, new[] { new Door(Direction.Right, TestRoom) });
}