using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "SpawnConfig", menuName = "StaticData/SpawnConfig")]
    public class SpawnConfig : ScriptableObject
    {
        [SerializeField] private float _leftSpawnPositionX;
        [SerializeField] private float _rightSpawnPositionX;
        [SerializeField] private int _upSpawnPositionBorder;
        [SerializeField] private int _downSpawnPositionBorder;
        [SerializeField] private float _spawnPositionY;

        public float LeftSpawnPositionX => _leftSpawnPositionX;
        public float RightSpawnPositionX => _rightSpawnPositionX;
        public int UpSpawnPositionBorder => _upSpawnPositionBorder;
        public int DownSpawnPositionBorder => _downSpawnPositionBorder;
        public float SpawnPositionY => _spawnPositionY;
    }
}
