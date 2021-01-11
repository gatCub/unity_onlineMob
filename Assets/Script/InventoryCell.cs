using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class InventoryCell: MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Text _nameField;
    [SerializeField] private Text _discriprionField;
    [SerializeField] private Image _iconField;
    [SerializeField] private bool _isTry;

    private Transform _draggingParent;
    private Transform _originalParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //transform.SetParent(_draggingParent, _isTry);
        transform.parent = _draggingParent;
        Debug.Log("OnDegin = " + transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int closestIndex = 0;
        Vector3 origin = new Vector3(transform.position.x, transform.position.y, 0f);

        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {

            if (Vector3.Distance(origin, _originalParent.GetChild(i).position) < (Vector3.Distance(origin, _originalParent.GetChild(closestIndex).position)))
            {
                closestIndex = i;
            }
        }

        //transform.SetParent(_originalParent, _isTry);
        transform.parent = _originalParent;
        transform.SetSiblingIndex(closestIndex);
        Debug.Log($"Позиция в иерархии: {closestIndex},Vector3.Distance = {transform.position}");
    }

    public void Init(Transform dragginParent)
    {
        _draggingParent = dragginParent;
        _originalParent = transform.parent;
    }

    public void Render(IItem item)
    {
        _iconField.sprite = item.UIIcon;
        _nameField.text = item.Name;
        _discriprionField.text = item.Description;
    }
}

