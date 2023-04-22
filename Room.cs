using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MagicBalls;

public class Room
{
    public TypeField[,] Level;
    public Door[] Doors;

    public Room(TypeField[,] level, Door[] doors)
    {
        Level = level;
        Doors = doors;
    }
    
    public static FieldElement[,] CrateRoomGround(TypeField[,] level, Rectangle startElementOptions)
    {
        int rows = level.GetUpperBound(0) + 1; // количество строк
        int columns = level.Length / rows; // количество столбцов
        var resulFloor = new FieldElement[rows, columns];
        var startX = startElementOptions.X;
        var startY = startElementOptions.Y;
        var sideOfSquareElement = startElementOptions.Height;
        var squareElementIndent = startElementOptions.Height;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var indentByRow = i * squareElementIndent;
                var indentByColumn = j * squareElementIndent;
                resulFloor[i, j] =
                    new FieldElement(
                        new Rectangle
                        (startX + indentByColumn, startY + indentByRow, sideOfSquareElement, sideOfSquareElement),
                        level[i, j], true);

            }
        }

        return resulFloor;
    }

    public static void DrawRoom(Room room, Rectangle startElementOptions)
    {
        foreach (var fieldElement in CrateRoomGround(room.Level,startElementOptions))
        {
            Game1.SpriteBatch.Draw(fieldElement.ViewTexture2D, fieldElement.Rectangle, Color.Snow);
        }

        foreach (var door in room.Doors)
        {
            Game1.SpriteBatch.Draw(door.DoorView, door.LocationRectangle, Color.Snow);
        }
    }

    public static Room ChangeRoom(MouseState mouse, Room nowRoom)
    {
        foreach (var door in nowRoom.Doors)
        {
            if (door.LocationRectangle.Contains(mouse.X, mouse.Y) )
            {
                return door.NextRoom;
            }
        }

        return nowRoom;
    }
}