using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridController : MonoBehaviour {

    public  int MaxX;
    public int MaxY;
    public GameObject[] GridChoose;
    public GameObject[,] GridObject;
    public int[,] GridNumber;

    private void Start()
    {
        GridNumber = new int[MaxX, MaxY];
        GridObject = new GameObject[MaxX, MaxY];
        Debug.Log(GridNumber.Length);
        for (int i = 0; i < MaxX; i++)
        {
            for (int j = 0; j < MaxY; j++)
            {
                GameObject obj = Instantiate(GridChoose[Random.Range(0, GridChoose.Length)], new Vector2((float)i - MaxX / 2, (float)j - MaxY / 2), Quaternion.identity, transform);
                GridObject[i, j] = obj;
                Debug.Log(obj + " " + i + " " + j);
                if (i == MaxX - 1) { SpawnEnemyManager.Instance.EnemySpawnPoint.Add(obj); }
            }
        }
    }
}
