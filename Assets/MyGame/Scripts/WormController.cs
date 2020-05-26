using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public KeyCode jumpKey;
    public KeyCode fowardKey;
    public KeyCode backKey;
    public Rigidbody rb;
    public Vector3 x;
    public Vector3 y;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Debug.Log("Jump taste wurde gedrückt");
            rb.AddForce(x);
        }

        if (Input.GetKeyDown(fowardKey))
        {
            Debug.Log("Forwärts taste wurde gedrückt");
            rb.AddForce(y);

        }

        if (Input.GetKeyDown(backKey))
        {
            Debug.Log("Zurück taste wurde gedrückt");
            rb.AddForce(-y);

        }
    }
}