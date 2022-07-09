namespace Asteroids
{
    public interface IEnemyHealth
    {
        public Health HP { get; set; }

        public void Damage();

    }
}