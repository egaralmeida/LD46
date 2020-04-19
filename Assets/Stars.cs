using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // Stars backgrounds generated here: http://wwwtyro.github.io/procedural.js/space/

    public GameObject[] stars;
    public Transform astronaut;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float posX = astronaut.transform.position.x;
        if (posX >= stars[1].transform.position.x && posX < stars[2].transform.position.x)
        {
            stars[2].SetActive(true);
            stars[0].SetActive(false);
        }
        else if (posX >= stars[2].transform.position.x && posX < stars[3].transform.position.x)
        {
            stars[3].SetActive(true);
            stars[1].SetActive(false);
        }
        else if (posX >= stars[3].transform.position.x)
        {
            stars[0].SetActive(true);

            Vector2 astronautNewPos = new Vector2(stars[0].transform.position.x, astronaut.transform.position.y);
            astronaut.transform.position = astronautNewPos;
            
            stars[3].SetActive(false);
            stars[1].SetActive(true);
        }
    }

}

