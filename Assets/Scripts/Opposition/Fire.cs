using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
   [SerializeField] private Enemy _target;

    private void Start()
    {
        StartCoroutine(LifeController());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            if (_target == null)
            {
                _target = collision.GetComponent<Enemy>();
                StartCoroutine(FireController());
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            _target = null;
        }
    }


    private IEnumerator FireController()
    {
        while(_target != null)
        {
            _target.Health = -1;
            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator LifeController()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}