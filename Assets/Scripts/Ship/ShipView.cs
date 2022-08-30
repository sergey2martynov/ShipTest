using System;
using DG.Tweening;
using UnityEngine;

namespace Ship
{
    public class ShipView : MonoBehaviour
    {
        public event Action ShipArrived;
        public event Action<int> DamageRecieved;

        public void Move(float positionX, int duration)
        {
            transform.DOMove(new Vector3(positionX, transform.position.y, transform.position.z), duration).OnComplete(
                () => { ShipArrived?.Invoke(); });
        }

        public void TakeDamage(int damage)
        {
            DamageRecieved?.Invoke(damage);
        }
    }
}