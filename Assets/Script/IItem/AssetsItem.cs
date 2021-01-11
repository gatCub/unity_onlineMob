using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetsItem :ScriptableObject, IItem
{
    public string Name => _name;

    public Sprite UIIcon => _uiIcon;

    public string Description => _discription;

    [SerializeField] private string _name;
    [SerializeField] private string _discription;
    [SerializeField] private Sprite _uiIcon;
}
