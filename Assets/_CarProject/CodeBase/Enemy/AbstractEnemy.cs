using UnityEngine;

namespace CodeBase.Enemy
{
    public abstract class AbstractEnemy : MonoBehaviour
    {
        public abstract void Attack();
        public abstract void Move();
    }
}