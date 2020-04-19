using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprayBar : MonoBehaviour
{
    public Slider bar;
    public GameObject astronaut;

    private Astronaut _astronautScript;

    void Start()
    {
        //bar = this.GetComponent<Slider>();
        _astronautScript = astronaut.GetComponent<Astronaut>();
    }

    void Update()
    {
        bar.value = _astronautScript.sprayLevel;
    }
}
