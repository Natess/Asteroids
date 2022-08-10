namespace Asteroids
{
    internal interface IHealth
    {
        float Health { get; }

        void Damage();
        void AddHealth(int health);
    }
}
