using Task3DzmitryKhrapunou.Data;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.Entities
{
    public class Film: IMaterial
    {
        public Color Color { get; }
        public bool IsColored { get; set; }

        public Film()
        {
            Color = Color.NoColor;
            IsColored = false;
        }
    }
}
