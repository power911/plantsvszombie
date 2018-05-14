using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAlive
{
    float MoveSpeed { get; set; }
    float TakeDamage { get; set; }
    void Move();

	
}
