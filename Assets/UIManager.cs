using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public Text groupUI;
    public GameObject astronaut;

    private Transform _currentActive;
    private Item _currentActiveScript;
    private RectTransform _distMeterRectTransform;

    void Start()
    {
        groupUI.enabled = false;
        getCurrentActive();
    }

    void Update()
    {
        if (_currentActiveScript.visible)
        {
            getCurrentActive();
        }
    }

    void LateUpdate()
    {
        groupUI.text = string.Format("{0:N3}", _currentActiveScript.distanceToAstronaut) + "  >";
    }

    private void getCurrentActive()
    {
        float minDistance = 10000f;
        foreach (Transform child in this.transform)
        {

            Item _childScript = child.GetComponent<Item>();

            float distance = Vector2.Distance(child.position, astronaut.transform.position);
            if (distance < minDistance && !_childScript.visible)
            {
                minDistance = distance;
                _currentActive = child;
            }
        }

        if (!_currentActive.gameObject.activeInHierarchy)
        {
            groupUI.enabled = false;
        }
        else
        {
            _currentActiveScript = _currentActive.GetComponent<Item>();
            if (_currentActive != null)
            {
                groupUI.enabled = true;
                _distMeterRectTransform = groupUI.GetComponent<RectTransform>();
                alignDistMeter();
            }
        }
    }

    private void alignDistMeter()
    {
        // If anyone ever reads this: This was a fuckery to figure out and stole like 3hs.
        // Kids don't waste 3hs on 48hs jams in UI shit.

        Vector2 cameraViewportPosition = Camera.main.WorldToViewportPoint(_currentActive.position);
        Vector2 distMeterNewPos = new Vector2(_distMeterRectTransform.anchoredPosition.x, (cameraViewportPosition.y * canvasRectTransform.sizeDelta.y) - (canvasRectTransform.sizeDelta.y * 0.5f));

        _distMeterRectTransform.anchoredPosition = distMeterNewPos;

    }
}
