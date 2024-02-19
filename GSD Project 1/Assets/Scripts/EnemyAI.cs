using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private PlayerHit PlayerHit;

    private Rigidbody rb;
    public GameObject player;
    // checks if the AI's view is blocked
    public bool check;
    public bool breaker = true;

    public GameObject healer;
    public Rigidbody br;
    public Transform firePoint;
    public Transform fireAngle;
    private Vector3 fullforce;
    public float bulletForce = 35f;
    private GameObject bullet;
    public GameObject bulletPrefab;

    public int health;

    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float obstacleRange = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");

        PlayerHit = player.GetComponent<PlayerHit>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "Player")
            {
                check = false;
                breaker = true;
            }
            else
            {
                check = true;
                if (breaker == true)
                {
                    Debug.Log("START!");
                    StartCoroutine(Cooldown());
                    breaker = false;
                }
            }
        }

        if (check == true && PlayerHit.isDead == false)
        {
            Follow();
        }
        else
        {
            Wander();
        }
        
        if (health == 0)
        {
            OnDeath();
        }
        
    }

    void Follow()
    {
        transform.LookAt(player.transform.position);

        if (rb.transform.rotation.y < 0.5f && rb.transform.rotation.y > -0.5f)
        {
            rb.transform.Translate(transform.forward * Time.deltaTime * speed);
        }
        else if (rb.transform.rotation.y > 0.5f || rb.transform.rotation.y < -0.5f)
        {
            rb.transform.Translate(transform.forward * Time.deltaTime * speed * -1);
        }
    }

    void Wander()
    {
        transform.rotation = Quaternion.identity;
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    IEnumerator Cooldown()
    {
        while (check == true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Waited");
            Shoot();
        }
    }

    void Shoot()
    {
        fireAngle.LookAt(player.transform.position);
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        br = bullet.GetComponent<Rigidbody>();
        fullforce = fireAngle.forward * bulletForce * 1.5f;
        br.AddForce(fullforce, ForceMode.Impulse);
    }

    public void SetHealth(int waveNum)
    {
        health = waveNum;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            health --;
        }
    }

    void OnDeath()
    {
        Instantiate(healer, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
