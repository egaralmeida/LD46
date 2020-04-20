using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public enum ItemType
    {
        Parts,
        Spray,
        Sanity,
    }
    public Slider bar;
    public GameObject astronaut;
    public ItemType itemType;

    private Astronaut _astronautScript;

    void Start()
    {
        _astronautScript = astronaut.GetComponent<Astronaut>();
    }

    void Update()
    {
        if(itemType == ItemType.Spray)
            bar.value = _astronautScript.sprayLevel;
        else if(itemType == ItemType.Sanity)
            bar.value = _astronautScript.sanity;
        else
            bar.value = _astronautScript.parts;
    }
}
