using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//IPointerClickHandler
{
    [SerializeField] private Renderer renderer;
    private Collider _collider;
    private TowerPlace _towerPlace;


    private Color _beginColor;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _beginColor = renderer.material.color;
        _towerPlace = TowerController.Instance.ActiveTowerPlace;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!GameManager.Instance.IsBattle)
            renderer.material.SetColor("_OutlineColor", Color.white);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!GameManager.Instance.IsBattle)
            renderer.material.SetColor("_OutlineColor", _beginColor);
    }

    public void OnMouseDrag()
    {
        if (!GameManager.Instance.IsBattle)
        {
            TowerController.Instance.DragableTower = this;
            _collider.enabled = false;
            if (_towerPlace)
                _towerPlace.gameObject.SetActive(true);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6f);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }
    private void OnMouseUp()
    {
        if (!GameManager.Instance.IsBattle)
        {
            if (TowerController.Instance.DragableTower == this && TowerController.Instance.ActiveTowerPlace)
            {
                _towerPlace = TowerController.Instance.SetTower(this);
            }
            if (_towerPlace)
            {
                transform.position = _towerPlace.transform.position;
                _towerPlace.gameObject.SetActive(false);
            }
            else
            {
                transform.position = transform.parent.position;
            }
            TowerController.Instance.ActiveTowerPlace = null;
            TowerController.Instance.DragableTower = null;
            _collider.enabled = true;
        }
    }
}
