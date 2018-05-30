using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IconController : MonoBehaviour {
    [SerializeField] private Button _mainButton;
    [SerializeField] private Slider _mainSlider;
    [SerializeField] private int _index;
    [SerializeField] private float _time;

    public void Click()
    {
        SpawnManager.Instance.Selected = _index;
        _mainButton.interactable = false;
        _mainSlider.gameObject.SetActive(true);
        _mainSlider.value = 0;
        StartCoroutine(Icon());
    }

    private IEnumerator Icon()
    {
        while (_mainSlider.value <= .9f)
        {
            _mainSlider.value += .1f;
            yield return new WaitForSeconds(60 / _time);
        }
        _mainButton.interactable = true;
        _mainSlider.gameObject.SetActive(false);
    }
}
