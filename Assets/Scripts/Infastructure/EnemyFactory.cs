

using UnityEngine;

namespace Asteroids
{
    internal class EnemyFactory : IEnemyFactory
    {
        public Enemy Create(EnemyTypes enemyType, Health hp)
        { 
            return Create(enemyType, hp, Vector3.zero);
        }

        public Enemy Create(EnemyTypes enemyType, Health hp, Vector3 position)
        {
            Enemy enemy;
            if (hp == null)
                throw new System.ArgumentException("Не передано здоровье");
            switch (enemyType)
            {
                case EnemyTypes.Asteroid1:
                    enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid1"), position, Quaternion.identity);
                    break;
                case EnemyTypes.Asteroid2:
                    enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid2"), position, Quaternion.identity);
                    // демонстрация работы прототипа (для астероида типа 2 будет создаваться два экземпляра, но их хп будут независимы)
                    var enemy2 = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid2"), position, Quaternion.identity);
                    enemy2.DependencyInjectHealth(hp.DeepCopy());
                    break;
                case EnemyTypes.UFO:
                    var ufo = Object.Instantiate(Resources.Load<UFO>("Enemy/UFO"), position, Quaternion.identity); 
                    ufo.DependencyInjectGameBuilder(new GameObjectBuilder());//ViewServicesFactory.Instance());
                    enemy = ufo;
                    break;

                default:
                    enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid1"));
                    break;
            }

            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
