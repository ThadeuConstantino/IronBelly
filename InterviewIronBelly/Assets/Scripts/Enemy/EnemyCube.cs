using IronBelly.Controller;
using IronBelly.Pool;
using UnityEngine;

namespace IronBelly.Enemy
{
    public class EnemyCube : MonoBehaviour
    {
        public void Hit()
        {
            GamePlayData.Hit += 1;
            GamePlayData.Spawned -= 1;

            //Dead
            RandomEnemy.Instance.DespawnEnemy(gameObject);
            ObjectPooler.Instance.AddToPool(gameObject);
        }
    }
}