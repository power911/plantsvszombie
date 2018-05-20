using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionSupport : Opposition {

    
    public override int Health{ get{ return _health;}
                                set{_health += value; if (_health <= 0) { Destroy(gameObject); } }}

    public override GameObject EnemyObject
    {
        set{ }
    }

    private void Start()
    {
        StartCoroutine(Skill());
    }
    
    public override IEnumerator Skill()
    {
        yield return new WaitForSeconds(_repeatTime);
        while (gameObject != null)
        {
            GameObject obj = Instantiate(_classObj, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, transform.position.y + 5f), ForceMode2D.Force);
            yield return new WaitForSeconds(_repeatTime);
        }
    }
}