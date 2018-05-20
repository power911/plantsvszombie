using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    [SerializeField] private Opposition _opposition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            _opposition.GetComponent<Opposition>().EnemyObject = collision.gameObject;
        }
    }

}
