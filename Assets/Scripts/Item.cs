using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private string[] _itemName = new string[2];
    [SerializeField] private Sprite[] _icon = new Sprite[2];
    [SerializeField] private int[] _count = new int[2];

    public string[] itemName => this._itemName;
    public Sprite[] icon => this._icon;
    public int[] count => this._count;

    //[SerializeField] private string _itemName;
    //[SerializeField] private Sprite _icon;
    //[SerializeField] private int _count;

    //public string itemName => this._itemName;
    //public Sprite icon => this._icon;
    //public int count => this._count;
}
