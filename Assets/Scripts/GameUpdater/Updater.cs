using System;
using UnityEngine;

namespace GameUpdater
{
    public class Updater : MonoBehaviour
    {
        public event Action Updated;
        private void Update()
        {
            Updated?.Invoke();
        }
    }
}
