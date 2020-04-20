using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public GameObject astronaut;
    public Text deathUI;

    private Astronaut _astronautScript;
    private string warningText = "";

    void Start()
    {
        deathUI.enabled = false;
        _astronautScript = astronaut.GetComponent<Astronaut>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_astronautScript.visible)
            restartLevel();

        if (_astronautScript.sanity <= 0)
            restartLevel();

        if (_astronautScript.distanceToOrigin > _astronautScript.deathDistance)
            restartLevel();

        if (_astronautScript.parts >= _astronautScript.targetParts)
            win();

        // Update death ui (why is this here? because it's 1hs to deadline 
        // and the other manager was not well thought out.
        if (_astronautScript.startAnimationOver)
        {
            if (_astronautScript.distanceToOrigin > _astronautScript.deathDistance * 90 / 100)
                warningText = "DANGER";
            if (_astronautScript.distanceToOrigin > _astronautScript.deathDistance * 75 / 100)
                warningText = "75% distance to no return!";
            if (_astronautScript.distanceToOrigin > _astronautScript.deathDistance * 50 / 100)
                warningText = "50% distance to no return";
            else if (_astronautScript.distanceToOrigin > _astronautScript.deathDistance * 25 / 100)
                warningText = "25% distance to no return";


            deathUI.enabled = true;
            deathUI.text = "<  " + string.Format("{0:N3}", _astronautScript.distanceToOrigin) + " " + warningText;


        }

    }

    private void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void win()
    {
        SceneManager.LoadScene("win", LoadSceneMode.Single);
    }
}
