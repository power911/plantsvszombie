using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    private Enemy _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            if (_target == null)
            {
                _target = collision.GetComponent<Enemy>();
                StartCoroutine(TrapController());
            }
        }
    }

    private IEnumerator TrapController()
    {
        yield return new WaitForSeconds(1f);
        _target.Health = -_target.Health;
        GetComponentInParent<GridElement>().CanBuild = true;
        Destroy(gameObject);
    }
}
