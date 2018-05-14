using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour {

    [SerializeField] private int _add;

	public void Clicked()
    {
        MainManager.Instance.CounterMoney = +_add;
    }
}
