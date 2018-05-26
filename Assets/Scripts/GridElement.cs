using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridElement : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

    public SpriteRenderer Sprite;

    [SerializeField] private GridElement _grid;
   
    public void Grid(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool CanBuild = true;
    public int X;
    public int Y;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        SpawnManager.Instance.OppositionSpawn(_grid);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SpawnManager.Instance.ReturnGO != null)
        {
            GridController.Instance.IlluminationGrid(X,Y);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
