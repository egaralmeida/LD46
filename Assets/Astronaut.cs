using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public GameObject myCamera;
    public float sprayLevel = 100;
    public float sprayDecay = 0.1f;
    public float sprayForce = 1f;
    public float impulseForce = 1f;
    public float maxVelocity = 0.632f;

    private Rigidbody2D _rb;
    private bool _startAnimationOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_startAnimationOver)
        {
            Vector2 newCamPos = new Vector2(this.transform.position.x, 0);
            myCamera.transform.position = newCamPos;
        }
        else if (this.transform.position.x > 0)
        {
            _startAnimationOver = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (Input.mousePosition.y < Screen.height / 2)
                _rb.AddForce(Vector2.up * sprayForce);
            else
                _rb.AddForce(Vector2.down * sprayForce);

            sprayLevel -= sprayDecay;
            if (sprayLevel <= 0)
            {
                sprayLevel = 0;
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (Input.mousePosition.y < Screen.height / 2)
                _rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
            else
                _rb.AddForce(Vector2.down * impulseForce, ForceMode2D.Impulse);
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
}
