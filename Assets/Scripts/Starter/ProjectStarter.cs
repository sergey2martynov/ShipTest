using System;
using ShipSpawner;
using StaticData;
using UnityEngine;

namespace Starter
{
    public class ProjectStarter : MonoBehaviour
    {
        [SerializeField] private PrefabHolder _prefabHolder;
        [SerializeField] private SpawnConfig _spawnConfig;
        [SerializeField] private Transform _shipParent;

        private void Awake()
        {
            var shipSpawner = new Spawner(_prefabHolder, _spawnConfig, _shipParent);

            for (int i = 0; i < 3; i++)
            {
                shipSpawner.SpawnShip();
            }
        }
    }
}
