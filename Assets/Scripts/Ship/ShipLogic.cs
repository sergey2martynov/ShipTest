using UnityEngine;

namespace Ship
{
    public class ShipLogic
    {
        private ShipView _view;
        private ShipData _shipData;

        public ShipLogic(ShipView view, ShipData shipData)
        {
            _view = view;
            _shipData = shipData;
        }

        public void Initialize()
        {
            _view.ShipArrived += DestroyShip;
            _shipData.ShipDead += DestroyShip;
            _view.DamageRecieved += TakeDamage;
        }

        private void DestroyShip()
        {
            _view.ShipArrived -= DestroyShip;
            Object.Destroy(_view.gameObject);
        }

        private void TakeDamage(int damage)
        {
            _shipData.Health -= damage;
        }
    }
}
