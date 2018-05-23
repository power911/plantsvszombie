using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasy : Enemy
{
    private void Start()
    {
        MainManager.Instance.EnemySlider.value += (MainManager.Instance.EnemySlider .maxValue / SpawnEnemyManager.Instance.RepleyCounter) / (SpawnEnemyManager.Instance.Action.Types.Length*2);
    }

    public override float MoveSpeed
    {
        get; set;
    }
        
    public override IEnumerator Skill(GameObject target)
    {
        var obj = target.GetComponent<Opposition>();
        while(target != null)
        {
           obj.Health = -1;
           yield return new WaitForSeconds(_repiat);
        }
    }

    private void Update()
    {
        if (_target == null)
        {
            base.Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bullet>() != null)
        {
            _health--;
            if (collision.GetComponent<Bullet>().DestroyObj)
            {
                Destroy(collision.gameObject);
            }
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.GetComponent<Opposition>() != null)
        {
            _target = collision.gameObject;
            StartCoroutine(Skill(_target));
        }
    }
}
