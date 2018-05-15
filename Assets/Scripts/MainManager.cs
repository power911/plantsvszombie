using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int CounterMoney { get { return _counterMoney; }
                              set { _counterMoney += value; _counter.text = _counterMoney.ToString(); } }

   
    [SerializeField] private Text _counter;
    [SerializeField] private int _counterMoney;

      
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

}