namespace Asteroids.Lesson6
{
    internal abstract class ModificationWeapon : IFire
    {
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon DeleteModification(Weapon weapon);
        private Weapon _weapon;

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }
        public void RemoveModification(Weapon weapon)
        {
            _weapon = DeleteModification(weapon);
        }


        public void Fire()
        {
            _weapon.Fire();
        }
    }
}