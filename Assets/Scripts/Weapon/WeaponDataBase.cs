using System;

namespace Weapon
{
    public class WeaponDataBase
    {
        private int _damage;
        
        public int Damage
        {
            get => _damage;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Damage cannot be equal on less than zero");
                }

                _damage = value;
            }
        }

        public WeaponDataBase(int damage)
        {
            Damage = damage;
        }
    }
}
