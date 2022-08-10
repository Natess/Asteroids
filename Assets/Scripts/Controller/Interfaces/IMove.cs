namespace Asteroids
{
    internal interface IMove
    {
        float Speed { get; }

        void Move(float horizontal, float vertical, float deltaTime);

        void AddSpeed(int speed);
    }
}
