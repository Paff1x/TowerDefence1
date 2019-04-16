using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Renderer renderer;

    private Color _beginColor;
    private void Awake()
    {
        _beginColor = renderer.material.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TowerController.Instance.ActiveTowerPlace = this;
        renderer.material.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        TowerController.Instance.ActiveTowerPlace = null;
        renderer.material.color = _beginColor;

    }
}