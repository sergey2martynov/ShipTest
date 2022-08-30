using System;
using DG.Tweening;
using Ship;
using UnityEngine;

namespace Projectile
{
    public class ProjectileView : MonoBehaviour
    {

        public event Action<ShipView> CollidedWithShip;
        public event Action ProjectileDestroed;
        public void Move(Vector3 target)
        {
            transform.DOMove(target, 1).OnComplete(() =>
            {
                ProjectileDestroed?.Invoke();
                Destroy(gameObject);
            });
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ShipView shipView))
            {
                CollidedWithShip?.Invoke(shipView);
            }
        }
    }
}
