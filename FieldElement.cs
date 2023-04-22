using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MagicBalls;

public class FieldElement
{
    public Rectangle Rectangle;
    public TypeField Type;
    public bool Free;
    public readonly Texture2D ViewTexture2D;

    public FieldElement(Rectangle rectangle, TypeField type, bool free)
    {
        Rectangle = rectangle;
        Type = type;
        Free = free;
        if (type == TypeField.Ground) ViewTexture2D = Game1.GroundTexture;
    }

    public static void PointToField(MouseState mouse, FieldElement element)
    {
        if (element.Rectangle.Contains(mouse.Position))
            Game1.SpriteBatch.Draw(Game1.Pointer, element.Rectangle, Color.White);
    }



}