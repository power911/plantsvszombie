using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridController : MonoBehaviour {

    [SerializeField] private int _maxX;
    [SerializeField] private int _maxY;
    [SerializeField] private GameObject[] _gridObj;

    private void Awake()
    {
        Generate();
    }
    
    private void Generate()
    {
        for (int i = 0; i < _maxX; i++)
        {
            for (int j = 0; j < _maxY; j++)
            {
                GameObject obj = Instantiate(_gridObj[Random.Range(0,_gridObj.Length)], new Vector2((float)i - _maxX / 2, (float)j - _maxY / 2), Quaternion.identity,transform);
                if(i == _maxX-1) { SpawnManager.Instance.EnemySpawnPoint.Add(obj); }
            }
        }
        
    }
}
