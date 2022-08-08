namespace Asteroids.Lesson6
{
    internal class InfantryUnit : IUnit
    {
        public InfantryUnit(string health)
        {
            Health = health;
        }

        public string Health { get; }
    }
}