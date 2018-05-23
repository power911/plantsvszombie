using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Opposition : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _repeatTime;
    [SerializeField] protected GameObject _classObj;
    [SerializeField] protected GameObject _enemy;
    public  GameObject EnemyObject { set { _enemy = value; StartCoroutine(Skill()); } }
    public abstract int Health { get; set; }
    public abstract IEnumerator Skill();
    
}
