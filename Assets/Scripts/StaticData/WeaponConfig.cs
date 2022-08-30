using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "StaticData/WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private Vector3 _spawnPositionProjectile;
        [SerializeField] private int _rocketLauncherDamage;
        [SerializeField] private float _rechargeDuration;

        public Vector3 SpawnPositionProjectile => _spawnPositionProjectile;
        public int RocketLauncherDamage => _rocketLauncherDamage;
        public float RechargeDuration => _rechargeDuration;
    }
}
