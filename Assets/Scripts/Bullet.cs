using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public Bullet(int damage, float speed)
    {
        _damage = damage;
        _speed = speed;
    }
    private void Start()
    {
        Destroy(gameObject, 6.5f);
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }
}
