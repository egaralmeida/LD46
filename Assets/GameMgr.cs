using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public GameObject astronaut;
    
    private Astronaut _astronautScript;

    void Start()
    {
        _astronautScript = astronaut.GetComponent<Astronaut>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_astronautScript.visible)
        {
            restartLevel();
        }
    }

    private void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
