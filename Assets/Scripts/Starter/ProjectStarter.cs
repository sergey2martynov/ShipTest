using System;
using GameUpdater;
using PlayerInput;
using ShipSpawner;
using StaticData;
using UnityEngine;
using Weapon;

namespace Starter
{
    public class ProjectStarter : MonoBehaviour
    {
        [SerializeField] private PrefabHolder _prefabHolder;
        [SerializeField] private SpawnConfig _spawnConfig;
        [SerializeField] private Transform _shipParent;
        [SerializeField] private Updater _updater;
        [SerializeField] private UserInputManager _inputManager;
        [SerializeField] private LayerMask _background;
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private ShipStats _shipStats;

        private void Awake()
        {
            var shipSpawner = new Spawner(_prefabHolder, _spawnConfig, _shipParent, _updater,_shipStats);
            shipSpawner.Initialize();

            var rocketLauncherData = new WeaponDataBase(_weaponConfig.RocketLauncherDamage);
            var rocketLauncher = new RocketLauncherLogic(_inputManager, _background, rocketLauncherData, _weaponConfig,
                _prefabHolder, _updater);
            rocketLauncher.Initialize();

        }
    }
}
