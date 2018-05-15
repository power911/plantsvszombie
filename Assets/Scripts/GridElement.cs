using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour {

    public bool CanBuild = true;

    public void Build(GameObject building, int withdraw)
    {
        if (CanBuild && MainManager.Instance.CounterMoney>=withdraw)
        {
            GameObject build = Instantiate(building, new Vector2(transform.position.x, transform.position.y), Quaternion.identity,transform);
            CanBuild = false;
            MainManager.Instance.CounterMoney = -withdraw;
        }
    }
}
