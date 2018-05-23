using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class EnemyAction:MonoBehaviour {
    public Action[] Types;
}
public enum Action
{
    EasyEnemy_OMON_with_out_cap = 0,
}
