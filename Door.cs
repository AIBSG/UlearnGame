using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MagicBalls;

public enum Direction
{
    Up,
    Left,
    Down,
    Right
}

public class Door
{
    public readonly Rectangle LocationRectangle;
    public readonly Texture2D DoorView;
    public Direction DirectionDoor;
    public Room NextRoom;

    public Door(Direction directionDoor, Room nextRoom)
    {
        DirectionDoor = directionDoor;
        NextRoom = nextRoom;
        LocationRectangle= FindDoorLocation
        (directionDoor, Game1.GraphicsDM.PreferredBackBufferHeight, Game1.GraphicsDM.PreferredBackBufferWidth, 70);
        DoorView = SetTextureToDoor(directionDoor);
    }

    private static Rectangle FindDoorLocation(Direction directionDoor, int heightWindow, int widthWindow, int sideOfButton)
    {
        int indent = 5;
        if (directionDoor == Direction.Down)
            return new Rectangle
                (widthWindow / 2 - sideOfButton / 2, heightWindow - sideOfButton - indent, sideOfButton, sideOfButton);

        if (directionDoor == Direction.Left)
            return new Rectangle
                (indent, heightWindow / 2 - sideOfButton / 2, sideOfButton, sideOfButton);
        if (directionDoor == Direction.Up)
            return new Rectangle
                (widthWindow / 2 - sideOfButton / 2, indent, sideOfButton, sideOfButton);
        if (directionDoor == Direction.Right)
            return new Rectangle
                (widthWindow - indent - sideOfButton, heightWindow / 2 - sideOfButton / 2, sideOfButton, sideOfButton);
        throw new Exception();
    }

    private static Texture2D SetTextureToDoor(Direction directionDoor)
    {
        if (directionDoor == Direction.Down) return Game1.DoorDown;
        if (directionDoor == Direction.Left) return Game1.DoorLeft;
        if (directionDoor == Direction.Right) return Game1.DoorRight;
        if (directionDoor == Direction.Up) return Game1.DoorUp;
        throw new Exception();
    }
    
}