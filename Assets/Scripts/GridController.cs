using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridController : MonoBehaviour {
    public static GridController Instance;

    public int MaxX;
    public int MaxY;
    public GameObject GridChoose;
    public GameObject[,] GridObject;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GridObject = new GameObject[MaxX, MaxY];
        StartCoroutine(I());
        //for (int i = 0; i < MaxX; i++)
        //{
        //    for (int j = 0; j < MaxY; j++)
        //    {
        //        int random = Random.Range(0, GridChoose.Length);
        //        GameObject obj = Instantiate(GridChoose[random], new Vector2((float)i - MaxX / 2, (float)j - MaxY / 2), Quaternion.identity, transform);
        //        GridChoose[random].GetComponent<GridElement>().Grid(i, j);
        //        GridObject[i, j] = obj;
        //        if (i == MaxX - 1) { SpawnEnemyManager.Instance.EnemySpawnPoint.Add(obj); }
        //    }
        //}
    }

    public void IlluminationGrid(int x,int y)
    {
        for (; x < MaxX; x++)
        {
            for (;  y < MaxY; y++)
            {
                GridObject[x, y].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            }
        }  
    }

    IEnumerator I()
    {
        for (int i = 0; i < MaxX; i++)
        {
            for (int j = 0; j < MaxY; j++)
            {
                GameObject obj = Instantiate(GridChoose, new Vector2(i - MaxX/2, (float)j - MaxY/2), Quaternion.identity,transform);
                GridChoose.GetComponent<GridElement>().Grid(i, j);
                GridObject[i, j] = obj;
                yield return new WaitForSeconds(0.5f);
                //if (i == MaxX - 1) { SpawnEnemyManager.Instance.EnemySpawnPoint.Add(obj); }
            }
        }
    }
}
