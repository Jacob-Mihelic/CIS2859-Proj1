using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class PlayerHit : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth PlayerHealth;
    public bool isDead = false;
    private GameObject capsule;

    public Camera FPS;
    public Camera Dead;
    // Start is called before the first frame update
    void Start()
    {
        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Rigidbody rb = capsule.AddComponent(typeof(Rigidbody)) as Rigidbody;
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.GetHealth() == 0f && isDead == false)
        {
            Debug.Log("Player has died");
            isDead = true;
            var copy = Instantiate(capsule, player.transform.position, Quaternion.identity);
            copy.transform.Rotate(-90, 0, 0);
            FPS.enabled = false;
            Dead.enabled = true;

            Destroy(player);

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "EnemyBullet")
        {
            PlayerHealth.LoseHealth(1);
        }
    }
}
