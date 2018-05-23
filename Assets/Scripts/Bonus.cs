using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bonus : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private int _bonus;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }  
    
    public void OnPointerDown(PointerEventData eventData)
    {
        MainManager.Instance.CounterMoney = +_bonus;
        Destroy(gameObject);
    }
}
