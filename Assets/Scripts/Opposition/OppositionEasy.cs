using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionEasy : Opposition
{
    public override int Health
    {
        get { return _health; }
        set {_health += value;if (_health <= 0) Destroy(gameObject); }
    }

    private void Start()
    {
        StartCoroutine(Skill());
    }

    public override IEnumerator Skill()
    {
        yield return new WaitForSeconds(_repeatTime);
        while(gameObject != null)
        {
            Instantiate(_classObj, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_repeatTime);
        }
    }
}
