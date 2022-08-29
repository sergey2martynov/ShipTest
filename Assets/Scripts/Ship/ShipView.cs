using DG.Tweening;
using UnityEngine;

namespace Ship
{
    public class ShipView : MonoBehaviour
    {
        public void Move(float positionX, int duration)
        {
            transform.DOMove(new Vector3(positionX, transform.position.y, transform.position.z), duration);
        }
    }
}
