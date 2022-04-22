using IronBelly.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace IronBelly.Pool
{
    public class ObjectPooler : MonoBehaviour
    {
        //Singleton
        public static ObjectPooler Instance;

        //Pool
        public Queue<GameObject> pooledObjects;
        
        //public
        public GameObject objectToPool;
        public int amountPool;

        //private 
        private RandomEnemy randomEnemy;
       
        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            randomEnemy = GetComponent<RandomEnemy>();

            CreatePool();
            randomEnemy.StartSpawn();
            randomEnemy.StartRandom();
        }

        public void CreatePool()
        {
            pooledObjects = new Queue<GameObject>();
            for (int i = 0; i < amountPool; i++)
            {
                var objToAdd = Instantiate(objectToPool);
                objToAdd.transform.SetParent(transform);
                AddToPool(objToAdd);
            }
        }

        public void AddToPool(GameObject value)
        {
            value.SetActive(false);
            pooledObjects.Enqueue(value);
        }

        public GameObject GetFromPool()
        {
            if (pooledObjects.Count == 0)
                CreatePool();

            var obj = pooledObjects.Dequeue();
            
            obj.SetActive(true);

            return obj;
        }
    }
}
