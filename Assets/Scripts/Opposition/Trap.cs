﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().Health = -collision.GetComponent<Enemy>().Health;
            GetComponentInParent<GridElement>().CanBuild = true;
            Destroy(gameObject);
        }
    }
}
