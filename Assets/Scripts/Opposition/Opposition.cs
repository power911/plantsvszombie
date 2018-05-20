using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Opposition : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _repeatTime;
    [SerializeField] protected GameObject _classObj;
    public abstract GameObject EnemyObject { set; }
    public abstract int Health { get; set; }
    public abstract IEnumerator Skill();
    
	
}
