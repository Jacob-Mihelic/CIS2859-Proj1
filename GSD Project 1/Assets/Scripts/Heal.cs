using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    private GameObject bar;
    private Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.FindWithTag("HealthBar");
        healthBar = bar.GetComponent<Slider>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            healthBar.value += 2;
            Destroy(gameObject);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
