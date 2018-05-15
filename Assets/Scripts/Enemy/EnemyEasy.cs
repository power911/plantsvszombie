using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasy : Enemy
{
    public override float MoveSpeed
    {
        get; set;
    }

    public override IEnumerator GiveDamage()
    {
        yield return null;
    }
    
    public override IEnumerator Skill()
    {
        yield return null;
    }

    private void Update()
    {
        base.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bullet>() != null)
        {
            _health--;
            Destroy(collision.gameObject);
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
