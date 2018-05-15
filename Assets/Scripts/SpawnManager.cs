using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public static SpawnManager Instance;

    public int Selected { set { _selected = value; _selectedObject = _oppositions[value]; } }

    public List<GameObject> EnemySpawnPoint = new List<GameObject>();

                     private int _selected;
    [SerializeField] private float _repiatTimeBonus;
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private GameObject[] _oppositions;
    [SerializeField] private int[] _oppositionsPrice;
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private GameObject _bonus;
    

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
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }

    }

    private void MouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.transform.GetComponent<GridElement>() != null && _selectedObject != null)
        {
            hit.transform.GetComponent<GridElement>().Build(_selectedObject, _oppositionsPrice[_selected]);
            _selectedObject = null;
        }
        if (hit.transform.GetComponent<Bonus>() != null)
        {
            hit.transform.GetComponent<Bonus>().Click();
            Destroy(hit.transform.gameObject);
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

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        while (gameObject != null)
        {
            Instantiate(_enemy[Random.Range(0, _enemy.Length)], EnemySpawnPoint[Random.Range(0,EnemySpawnPoint.Count)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

}
