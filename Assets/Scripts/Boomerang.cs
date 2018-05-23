using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    public Opposition Oppos;

    private void Start()
    {
        StartCoroutine(BoommerangController());
    }

    private void Update()
    {
      transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }

    private IEnumerator BoommerangController()
    {
        yield return new WaitForSeconds(5f);
        _speed = -_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Opposition>() == Oppos)
        {
            Destroy(gameObject);
        }
    }
}

