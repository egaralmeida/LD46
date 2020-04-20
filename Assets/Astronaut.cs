using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    // Lap time is ~02:45 minutes (165 seconds)

    public GameObject myCamera;
    public float sprayLevel = 100;
    public int parts = 0;
    public int targetParts = 50;
    public float sanity = 100f;
    public float sprayDecay = 0.1f;
    public float impulseDecay = 25f;
    public float sprayForce = 1f;
    public float impulseForce = 1f;
    public float maxVelocity = 0.632f;
    public float deathDistance = 40;
    public bool visible = true;
    public float distanceToOrigin = 0f;
    public bool startAnimationOver = false;

    private Rigidbody2D _rb;
    private Vector2 _originPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _originPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkBonusValues();
        goInsane();

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 mouseToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        distanceToOrigin = Vector2.Distance(this.transform.position, _originPosition);

        if (startAnimationOver)
        {
            Vector2 newCamPos = new Vector2(this.transform.position.x, 0);
            myCamera.transform.position = newCamPos;

            if (Input.GetButton("Fire1"))
            {
                if (sprayLevel >= sprayDecay) // squeeze out those last few molecules... keep it alive!
                {
                    sprayLevel -= sprayDecay;
                    if (mouseToWorld.y < this.transform.position.y)
                        _rb.AddForce(Vector2.up * sprayForce);
                    else
                        _rb.AddForce(Vector2.down * sprayForce);
                }
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                if (sprayLevel >= impulseDecay)
                {
                    sprayLevel -= impulseDecay;
                    if (mouseToWorld.y < this.transform.position.y)
                        _rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
                    else
                        _rb.AddForce(Vector2.down * impulseForce, ForceMode2D.Impulse);
                }
            }
        }
        else if (this.transform.position.x > 0)
        {
            startAnimationOver = true;
        }
    }

    void FixedUpdate()
    {
        // The kick towards eternity
        _rb.AddForce(Vector2.right * 0.5f);

        if (_rb.velocity.x > maxVelocity)
        {
            _rb.velocity = new Vector2(maxVelocity, _rb.velocity.y);  // <-- I'm not even sorry.
        }
    }

    private void checkBonusValues()
    {
        if (sprayLevel > 100)
            sprayLevel = 100;
        else if (sprayLevel < 0)
            sprayLevel = 0;

        if (sanity > 100)
            sanity = 100;
        else if (sanity < 0)
            sanity = 0;

        if (parts > 100)
            parts = 100;
    }

    private void goInsane()
    {
        if(startAnimationOver)
            sanity -= Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        visible = false;
    }
}
