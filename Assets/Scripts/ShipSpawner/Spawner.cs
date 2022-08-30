using GameUpdater;
using Ship;
using StaticData;
using UnityEngine;

namespace ShipSpawner
{
    public class Spawner
    {
        private PrefabHolder _prefabHolder;
        private SpawnConfig _spawnConfig;
        private Transform _shipParent;
        private Updater _updater;
        private ShipStats _shipStats;

        private float _elapsedTime;

        public Spawner(PrefabHolder prefabHolder, SpawnConfig spawnConfig, Transform shipParent, Updater updater, ShipStats shipStats)
        {
            _prefabHolder = prefabHolder;
            _spawnConfig = spawnConfig;
            _shipParent = shipParent;
            _updater = updater;
            _shipStats = shipStats;
        }

        public void Initialize()
        {
            _updater.Updated += OnUpdate;
        }

        private void OnUpdate()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > 5)
            {
                SpawnShip();
                _elapsedTime = 0;
            }
        }

        public void SpawnShip()
        {
            Vector3 spawnPosition;
            bool isSpawnRight = false;

            if (Random.Range(0, 2) == 0)
            {
                spawnPosition = new Vector3(_spawnConfig.LeftSpawnPositionX, _spawnConfig.SpawnPositionY,
                    Random.Range(_spawnConfig.UpSpawnPositionBorder, _spawnConfig.DownSpawnPositionBorder));
            }
            else
            {
                spawnPosition = new Vector3(_spawnConfig.RightSpawnPositionX, _spawnConfig.SpawnPositionY,
                    Random.Range(_spawnConfig.UpSpawnPositionBorder, _spawnConfig.DownSpawnPositionBorder));
                isSpawnRight = true;
            }

            var shipData = new ShipData(_shipStats.Health);
            var shipView = Object.Instantiate(_prefabHolder.ShipView, spawnPosition, Quaternion.identity,
                _shipParent);
            var shipLogic = new ShipLogic(shipView, shipData);
            shipLogic.Initialize();

            if (isSpawnRight)
            {
                shipView.Move(_spawnConfig.LeftSpawnPositionX, 3);
            }
            else
            {
                shipView.Move(_spawnConfig.RightSpawnPositionX, 3);
            }
        }
    }
}