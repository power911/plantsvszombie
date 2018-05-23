using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionBoomerang : Opposition
{
    [SerializeField] private GameObject _returnedBullet;
    [SerializeField] private Opposition _opposition;

    public override int Health
    {
        get { return _health; } set { _health += value; if (_health <= 0) { gameObject.GetComponentInParent<GridElement>().CanBuild = true; Destroy(gameObject); } }
    }
    public override IEnumerator Skill()
    {
        while (_enemy != null)
        {
            if (_returnedBullet == null)
            {
                GameObject obj = Instantiate(_classObj, new Vector2(transform.position.x + 0.65f, transform.position.y), Quaternion.identity,transform);
                _returnedBullet = obj;
                obj.GetComponent<Boomerang>().Oppos = _opposition;
                yield return new WaitForSeconds(_repeatTime);
            }
            yield return null;
        }
    }
}
