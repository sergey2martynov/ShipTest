using Ship;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "PrefabHolder", menuName = "StaticData/PrefabHolder")]
    public class PrefabHolder : ScriptableObject
    {
        [SerializeField] private ShipView _shipView;
        public ShipView ShipView => _shipView;
    }
}
