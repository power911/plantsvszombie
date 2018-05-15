using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    [SerializeField] private int _bonus;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }  

    public void Click()
    {
        MainManager.Instance.CounterMoney = _bonus;
    }
}
