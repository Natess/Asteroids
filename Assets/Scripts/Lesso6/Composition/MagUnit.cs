namespace Asteroids.Lesson6
{
    internal class MagUnit : IUnit
    {
        public MagUnit(string health)
        {
            Health = health;
        }

        public string Health { get; }
    }
}