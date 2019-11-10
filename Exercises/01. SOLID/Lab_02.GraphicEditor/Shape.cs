using System;

namespace GraphicEditor
{
    public abstract class Shape : IShape
    {
        public virtual void Draw()
        {
            Console.WriteLine($"I'm {this.GetType().Name}");
        }
    }
}