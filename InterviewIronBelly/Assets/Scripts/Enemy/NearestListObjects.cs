using IronBelly.Utils;
using UnityEngine;

namespace IronBelly.Enemy
{
    public class NearestListObjects : MonoBehaviour
    {
        public static NearestListObjects Instance;

        public KdTree<EnemyCube> nearestObjects = new KdTree<EnemyCube>();

        void Awake()
        {
            Instance = this;
        }

        public void AddToTree(EnemyCube value)
        {
            nearestObjects.Add(value);
        }
    }
}