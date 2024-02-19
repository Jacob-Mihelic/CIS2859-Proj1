using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }
}
