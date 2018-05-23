using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridElement : MonoBehaviour , IPointerDownHandler {

    [SerializeField] private GridElement _grid;

    public bool CanBuild = true;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        SpawnManager.Instance.OppositionSpawn(_grid);
    }
}
