using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class RedEnemy : AbstractEnemy
    {
        public override void Attack()
        {

            Debug.Log("Attack");

        }

        public override void Move()
        {

            Debug.Log("Move");

        }
    }
}
