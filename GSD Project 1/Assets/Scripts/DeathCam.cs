using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCam : MonoBehaviour
{
    private Camera cam;

    public bool checker = true;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.isActiveAndEnabled && checker == true)
        {
            transform.Translate(0, 0, 90 * Time.deltaTime * -1);

            if (transform.position.y > 90)
            {
                checker = false;
            }
            
        }
    }
}
