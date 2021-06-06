using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(1,999)]
    public int Amount;
}

[CreateAssetMenu]
public class CraftingItems : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;
}
