using Projectile;
using Ship;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "PrefabHolder", menuName = "StaticData/PrefabHolder")]
    public class PrefabHolder : ScriptableObject
    {
        [SerializeField] private ShipView _shipView;
        [SerializeField] private ProjectileView _projectileView;
        public ShipView ShipView => _shipView;
        public ProjectileView ProjectileView => _projectileView;
    }
}
