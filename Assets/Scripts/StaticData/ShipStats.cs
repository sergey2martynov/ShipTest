using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ShipStats", menuName = "StaticData/ShipStats")]
    public class ShipStats : ScriptableObject
    {
        [SerializeField] private int _health;

        public int Health => _health;
    }
}
