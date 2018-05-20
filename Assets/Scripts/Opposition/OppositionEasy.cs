using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionEasy : Opposition
{
    [SerializeField] private GameObject _enemy;
    

    public override int Health
    {
        get { return _health; }
        set {_health += value;if (_health <= 0) { gameObject.GetComponentInParent<GridElement>().CanBuild = true; Destroy(gameObject); } }
    }

    public override GameObject EnemyObject
    {
        set { _enemy = value; StartCoroutine(Skill()); }
    }

    public override IEnumerator Skill()
    {
        while(_enemy != null)
        {
            Instantiate(_classObj, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_repeatTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<Enemy>() != null)
        {
            _enemy = collision.gameObject;
            StartCoroutine(Skill());
        }
    }
}
