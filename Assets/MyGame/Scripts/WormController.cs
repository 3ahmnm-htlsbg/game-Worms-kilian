
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public KeyCode jumpKey;
    public KeyCode downKey;
    public KeyCode fowardKey;
    public KeyCode backKey;
    public KeyCode shootKey;
    public UnityEngine.Rigidbody rb;
    public Vector3 vecJump;
    public Vector3 vecForward;
    public Vector3 shootforce;
    private bool left;

    public GameObject gun;
    
    // Update is called once per frame
    public GameObject projectile;
    void Update()
    {
        if (Input.GetKey(jumpKey))
        {
            Debug.Log("Jump taste wurde gedrückt");
            rb.AddForce(vecJump);
        }

        if (Input.GetKey(downKey))
        {
            Debug.Log("Jump taste wurde gedrückt");
            rb.AddForce(-vecJump);
        }
        if (Input.GetKey(fowardKey))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0,0,0);
            left = false;
            Debug.Log("Forwärts taste wurde gedrückt");
            rb.AddForce(vecForward);
        }

        if (Input.GetKey(backKey))
        {
            // var Scale = this.gameObject.transform.localScale;
            // Vector2 invert = new Vector3(-1,1,1);
            // var flip = Scale * invert; 
            // this.gameObject.transform.localScale = flip;

      
            this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
            left = true;
            Debug.Log("Zurück taste wurde gedrückt");
            rb.AddForce(-vecForward);
        }


        if (Input.GetKeyDown(shootKey))
        {
            // Vector3 gunpos = gun.transform.position;
            var shot = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
            if(left) {
                shot.GetComponent<Rigidbody>().AddForce(-shootforce);
            } else {
                shot.GetComponent<Rigidbody>().AddForce(shootforce);
            }
        }

    }
}