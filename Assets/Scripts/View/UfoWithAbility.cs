
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    internal class UfoWithAbility: UFO, IAbilityEnemy
    {
        private List<IAbility> _ability;

        public UfoWithAbility(List<IAbility> ability)
        {
            _ability = ability;
        }

        public IAbility this[int index] => _ability[index];
        public string this[Target index]
        {
            get
            {
                var ability = _ability.FirstOrDefault(a => a.Target == index);
                return ability == null ? "Не поддерживается" : ability.ToString();
            }
        }

        public int MaxDamage => _ability.Select(a => a.Damage).Max();

        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _ability[Random.Range(0, _ability.Count)];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _ability.Count; i++)
            {
                yield return _ability[i];
            }
        }

        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _ability)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }

    }
}
