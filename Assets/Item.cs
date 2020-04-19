using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Parts,
        Spray,
        Sanity,
    }

    public SO_Items itemValues;
    public GameObject astronaut;
    public ItemType itemType;
    public float distanceToAstronaut;
    public bool visible = false;

    void Update()
    {
        distanceToAstronaut = Vector2.Distance(this.transform.position, astronaut.transform.position);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.transform != null)
        {
            GameObject hitGameObject = hitInfo.gameObject;
            Astronaut hitScript = hitGameObject.GetComponent<Astronaut>();

            if (hitScript != null)
            {
                if (itemType == ItemType.Parts)
                    hitScript.parts += itemValues.partBonusValue;
                else if (itemType == ItemType.Spray)
                    hitScript.sprayLevel += itemValues.sprayBonusValue;
                else if (itemType == ItemType.Sanity)
                    hitScript.sanity += itemValues.sanityValue;

                this.gameObject.SetActive(false);
            }
        }
    }

    void OnBecameVisible()
    {
        visible = true;
    }
}
