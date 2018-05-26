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
        for (int i = 0; i < MaxX; i++)
        {
            for (int j = 0; j < MaxY; j++)
            {
                
                GameObject obj = Instantiate(GridChoose, new Vector2((float)i - MaxX / 2, (float)j - MaxY / 2), Quaternion.identity, transform);
                obj.GetComponent<GridElement>().Grid(i, j);
                GridObject[i, j] = obj;
                if (i == MaxX - 1) { SpawnEnemyManager.Instance.EnemySpawnPoint.Add(obj); }
            }
        }
    }

    public void IlluminationGrid(int x,int y)
    {
        for (; y < MaxY; y++)
        {
            for (; x < MaxX; x++)
            {
                GridObject[x, y].GetComponent<SpriteRenderer>().color = new Color(0, 255, 255, 255);
            }
        }
    }
    public void AntiIllunation()
    {
        for (int i = 0; i < MaxX; i++)
        {
            for (int j = 0; j < MaxY; j++)
            {
                GridObject[i, j].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
        }
    }
    
}
