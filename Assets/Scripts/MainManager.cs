using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int SelectedNumber { set { _selectedNum = value; _selectedGO = _poolGO[value]; } }
    public int CounterMoney { get { return _counterMoney; }
                              set { _counterMoney += value; _counter.text = _counterMoney.ToString(); } }

    [SerializeField] private int _selectedNum;
    [SerializeField] private GameObject _selectedGO;

    [SerializeField] private Text _counter;
    [SerializeField] private int _counterMoney;

    [SerializeField] private GameObject[] _poolGO;
    [SerializeField] private int[] _poolPrice;

    [SerializeField] private GameObject _money;

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
        StartCoroutine(SpawnMoney());
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
        if (hit.transform.GetComponent<GridElement>() != null && _selectedGO != null)
        {
            hit.transform.GetComponent<GridElement>().Build(_selectedGO, _poolPrice[_selectedNum]);
            _selectedGO = null;
        }
        if(hit.transform.GetComponent<Support>() != null)
        {
            hit.transform.GetComponent<Support>().Clicked();
            Destroy(hit.transform.gameObject);
        }
    }
       
    private IEnumerator SpawnMoney()
    {
        yield return new WaitForSeconds(5f);
        while (gameObject != null)
        {
            Instantiate(_money, new Vector2(Random.Range(-5f, 5f), 3f), Quaternion.identity);
            yield return new WaitForSeconds(5f);                
        }
    }
}