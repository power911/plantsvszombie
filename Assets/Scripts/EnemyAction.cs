using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class EnemyAction:MonoBehaviour {
    public Action[] Types;
}
public enum Action
{
    Easy_Simple = 0,
    Easy_Siple_Helm = 1,
    Easy_Green = 2,
    Easy_Green_Helm = 3,
    Easy_Shield = 4
}
