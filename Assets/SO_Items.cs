using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "LD46/Item Data", order = 1)]
public class SO_Items : ScriptableObject
{
    public int partBonusValue = 3;
    public float sprayBonusValue = 25f;
    public int sanityValue = 25;
}