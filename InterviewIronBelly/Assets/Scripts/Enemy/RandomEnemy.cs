using IronBelly.Controller;
using IronBelly.Pool;
using IronBelly.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IronBelly.Enemy 
{
    public class RandomEnemy : Singleton<RandomEnemy>
    {
        private Vector3 center = new Vector3(0,1,5);
        public Vector3 size;

        [Header("Initial quantity start in game")]
        public int startQuantity;
        [Header("Delay Spawn Hit Box")]
        public int delaySpawn = 3;

        //List to consult Activate Objects - Using in <KDTree>
        [SerializeField]
        private List<Transform> activateObjects;

        //Getters and Setters
        public List<Transform> ActivateObjects { get => activateObjects; set => activateObjects = value; }

        //Unity Event
        public UnityEvent OnUpdateActivateObject;

        public void StartSpawn()
        {
            for (int i = 0; i < startQuantity; i++)
                SpawnEnemy();
        }

        public void StartRandom()
        {
            StartCoroutine(DelaySpawn());
        }

        IEnumerator DelaySpawn()
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delaySpawn);
            StartCoroutine(DelaySpawn());
        }

        public void DespawnEnemy(GameObject enemy)
        {
            activateObjects.Remove(enemy.GetComponent<Transform>());
            OnUpdateActivateObject.Invoke();
        }

        public void SpawnEnemy()
        {
            Vector3 _pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            var enemy = ObjectPooler.Instance.GetFromPool();
            enemy.transform.position = _pos;

            //Event
            activateObjects.Add(enemy.GetComponent<Transform>());
            OnUpdateActivateObject.Invoke();

            //Data
            GamePlayData.Spawned += 1;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(center, size);
        }
    }
}