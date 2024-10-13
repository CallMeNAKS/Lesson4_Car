using UnityEngine;

namespace CodeBase.Enemy.Factory
{
    public abstract class AbstractEnemyFactory : MonoBehaviour
    {
        protected string _prefabPath;


        public AbstractEnemyFactory(string prefabPath)
        {
            _prefabPath = prefabPath;
        }

        public abstract AbstractEnemy CreateEnemy(Vector3 position);
    }
}