using UnityEngine;

namespace CodeBase.Enemy.Factory
{
    public class RedEnemyFactory : AbstractEnemyFactory
    {
        public RedEnemyFactory(string prefabPath) : base(prefabPath) { }

        public override AbstractEnemy CreateEnemy(Vector3 position)
        {
            GameObject prefab = Resources.Load<GameObject>(_prefabPath);
            GameObject redEnemyObject = Instantiate(prefab, position, default);
            return redEnemyObject.GetComponent<RedEnemy>();
        }
    }
}