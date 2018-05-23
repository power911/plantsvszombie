using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour {
    public static SpawnEnemyManager Instance;
    
    public List<GameObject> EnemySpawnPoint = new List<GameObject>();
    public EnemyAction Action;
    public int RepleyCounter;

    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private float _repiat;
    
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
       StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < RepleyCounter; i++)
        {
            yield return new WaitForSeconds(5f);
            int counter = 0;
            while (counter < Action.Types.Length)
            {
                GameObject enemy = Instantiate(_enemy[(int)Action.Types[counter]], EnemySpawnPoint[Random.Range(0, EnemySpawnPoint.Count)].transform.position, Quaternion.identity);
                counter++;
                yield return new WaitForSeconds(_repiat);
            }
            counter = 0;
            foreach (int n in Action.Types)
            {
                GameObject enemy = Instantiate(_enemy[(int)Action.Types[counter]], EnemySpawnPoint[Random.Range(0, EnemySpawnPoint.Count)].transform.position, Quaternion.identity);
                counter++;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
