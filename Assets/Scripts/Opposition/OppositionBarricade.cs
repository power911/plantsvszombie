using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionBarricade : Opposition
{
    public override int Health
    {
        get{ return _health;  }
        set{ _health += value;if (_health <= 0) { Destroy(gameObject); } }
    }

    public override IEnumerator Skill()
    {
        yield return null;
    }
}
