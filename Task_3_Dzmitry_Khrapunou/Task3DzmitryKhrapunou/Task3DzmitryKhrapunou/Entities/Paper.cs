using System;
using Task3DzmitryKhrapunou.Data;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.Entities
{
    public class Paper: IMaterial
    {
        private Color color;
        public Color Color
        {
            set
            {
                if (IsColored == false)
                {
                    color = value;
                }
                else
                {
                    throw new Exception("This shape is already colored");
                }
            }
            get { return color; }
        }
        public bool IsColored { get; set; }

        public Paper(Color color)
        {
            Color = color;
            IsColored = true;
        }

        public Paper()
        {
            Color = Color.White;
            IsColored = false;
        }
    }
}
