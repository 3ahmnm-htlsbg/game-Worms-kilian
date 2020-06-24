
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

    public Vector3 raydir;
    
    // Update is called once per frame
    public GameObject projectile;
    void Update()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(this.gameObject.transform.Find("ray").gameObject.transform.position, raydir, out hit, 0.2f))
        {

            if (Input.GetKey(jumpKey))
            {
                rb.AddForce(vecJump);
            }
        }

        if (Input.GetKey(downKey))
        {
            rb.AddForce(-vecJump);
        }
        if (Input.GetKey(fowardKey))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0,0,0);
            left = false;
            rb.AddForce(vecForward);
        }

        if (Input.GetKey(backKey))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
            left = true;
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