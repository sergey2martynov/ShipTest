using GameUpdater;
using PlayerInput;
using Projectile;
using Ship;
using StaticData;
using UnityEngine;

namespace Weapon
{
    public class RocketLauncherLogic : WeaponLogicBase
    {
        private PrefabHolder _prefabHolder;
        private ProjectileView _projectileView;
        private Updater _updater;

        private float _elapsedTime;
        
        public RocketLauncherLogic(UserInputManager inputManager, LayerMask backGround, WeaponDataBase weaponDataBase, WeaponConfig weaponConfig, PrefabHolder prefabHolder, Updater updater) : base(inputManager, backGround, weaponDataBase, weaponConfig)
        {
            _prefabHolder = prefabHolder;
            _updater = updater;
        }

        public override void Initialize()
        {
            base.Initialize();
            RayCreatedOnMouseButtonPress += Shoot;
            _updater.Updated += OnUpdate;
        }

        private void Shoot(RaycastHit hit)
        {
            if (_elapsedTime > _weaponConfig.RechargeDuration)
            {
                _projectileView = Object.Instantiate(_prefabHolder.ProjectileView, _weaponConfig.SpawnPositionProjectile,
                    Quaternion.identity);
                _projectileView.CollidedWithShip += MakeDamage;
                _projectileView.ProjectileDestroed += OnProjectileDestroy;
                _projectileView.Move(hit.point);
                _elapsedTime = 0;
            }
        }

        private void OnUpdate()
        {
            _elapsedTime += Time.deltaTime;
        }

        private void MakeDamage(ShipView shipView)
        {
            shipView.TakeDamage(_weaponConfig.RocketLauncherDamage);
        }

        private void OnProjectileDestroy()
        {
            _projectileView.CollidedWithShip -= MakeDamage;
            _projectileView.ProjectileDestroed -= OnProjectileDestroy;
        }
    }
}