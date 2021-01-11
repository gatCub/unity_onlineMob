using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invrntory : MonoBehaviour
{
    [SerializeField] private List<AssetsItem> Items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _draggingParent;

    public void OnEnable()
    {
        Render(Items);
    }

    public void Render(List<AssetsItem> items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Init(_draggingParent);
            cell.Render(item);
        });
    }
}
