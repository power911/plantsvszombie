using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] protected int _damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected bool _destroy;
    
    public bool DestroyObj { get { return _destroy; } }

    private void Start()
    {
        Destroy(gameObject, 6.5f);
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }
}
