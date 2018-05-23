using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public static SpawnManager Instance;

    public int Selected { set { _selected = value; _selectedObject = _oppositions[value]; withdraw = _oppositionsPrice[value]; } }

                         private int _selected;
    [SerializeField] private float _repiatTimeBonus;
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private GameObject[] _oppositions;
    [SerializeField] private int[] _oppositionsPrice;
    [SerializeField] private GameObject _bonus;
    [SerializeField] private int withdraw;
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
        StartCoroutine(SpawnBonus());
    }

    public void OppositionSpawn(GridElement grid)
    {
        if (grid.CanBuild && MainManager.Instance.CounterMoney >= withdraw && _selectedObject != null)
        {
            GameObject build = Instantiate(_selectedObject, new Vector2(grid.gameObject.transform.position.x, grid.gameObject.transform.position.y), Quaternion.identity, grid.gameObject.transform);
            grid.CanBuild = false;
            MainManager.Instance.CounterMoney = -withdraw;
            _selectedObject = null;
        }
    }

           
    private IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(5f);
        while (gameObject != null)
        {
            Instantiate(_bonus, new Vector2(Random.Range(-5f, 5f), 3f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
        
}
