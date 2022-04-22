using IronBelly.Enemy;
using IronBelly.Utils;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestNeighbour : MonoBehaviour
{
    public Transform Player;

    //First add your enemy transform in C# List
    public List<Transform> EnemyList;

    private KdTree<Transform> enemyKdTree = new KdTree<Transform>();
    private Transform nearestEnemy;

    void Start()
    {
        Player = gameObject.transform;
    }

    private void OnEnable()
    {
        LoadData();
        RandomEnemy.Instance.OnUpdateActivateObject.AddListener(LoadData);
    }

    private void OnDisable()
    {
        RandomEnemy.Instance.OnUpdateActivateObject.RemoveListener(LoadData);
    }

    public void LoadData()
    {
        EnemyList.Clear();
        enemyKdTree.Clear();

        foreach (var go in RandomEnemy.Instance.ActivateObjects)
        {
            if(go != gameObject.transform)
                EnemyList.Add(go.transform);
        }

        
        enemyKdTree.AddAll(EnemyList);
    }

    void Update()
    {
        if(EnemyList.Count == 0)
            return;

        enemyKdTree.UpdatePositions();

        nearestEnemy = enemyKdTree.FindClosest(Player.position);
        
        if(nearestEnemy)
            Debug.DrawLine(gameObject.transform.position, nearestEnemy.position, Color.red);
    }
}