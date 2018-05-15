﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    [SerializeField] protected int _health;
    [SerializeField] protected float _speed;
    public abstract float MoveSpeed { get; set; }
    public abstract IEnumerator Skill();
    public abstract IEnumerator GiveDamage();
    public void Move()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
    }
}