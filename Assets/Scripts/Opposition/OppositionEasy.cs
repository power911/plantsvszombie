using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionEasy : Opposition
{
    
    public override int Health
    {
        get { return _health; }
        set {_health += value;if (_health <= 0) { gameObject.GetComponentInParent<GridElement>().CanBuild = true; Destroy(gameObject); } }
    }
        
    public override IEnumerator Skill()
    {
        while (_enemy != null)
        {
            GameObject obj = Instantiate(_classObj, new Vector2(transform.position.x + 0.65f, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(_repeatTime);
        }
    }
}

