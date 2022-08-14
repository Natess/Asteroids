namespace Asteroids
{
    public interface IFieldOfViewVisitor
    {
        void Visit(Enemy enemy);
        void Visit(Asteroid asteroid);
        void Visit(UFO ufo);
    }
}