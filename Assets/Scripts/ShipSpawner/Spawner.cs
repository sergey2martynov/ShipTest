using StaticData;
using UnityEngine;

namespace ShipSpawner
{
    public class Spawner
    {
        private PrefabHolder _prefabHolder;
        private SpawnConfig _spawnConfig;
        private Transform _shipParent;

        public Spawner(PrefabHolder prefabHolder, SpawnConfig spawnConfig, Transform shipParent)
        {
            _prefabHolder = prefabHolder;
            _spawnConfig = spawnConfig;
            _shipParent = shipParent;
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

            var ship = Object.Instantiate(_prefabHolder.ShipView, spawnPosition, Quaternion.identity,
                _shipParent);

            if (isSpawnRight)
            {
                ship.Move(_spawnConfig.LeftSpawnPositionX, 3);
            }
            else
            {
                ship.Move(_spawnConfig.RightSpawnPositionX, 3);
            }
        }
    }
}