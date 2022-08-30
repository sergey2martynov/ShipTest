using System;

namespace Ship
{
    public class ShipData
    {
        private int _health;

        public event Action ShipDead;
        
        public int Health
        {
            get => _health;

            set
            {
                _health = value;
                
                if (_health <=0)
                    ShipDead?.Invoke();
            }
        }

        public ShipData(int health)
        {
            Health = health;
        }
    }
}
