using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Aim aim;

    public Rigidbody rb;
    public Transform firePoint;
    public Transform fireAngle;
    private Vector3 fullforce;
    public float bulletForce = 35f;
    private GameObject bullet;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireAngle.LookAt(aim.Point(firePoint));
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            rb = bullet.GetComponent<Rigidbody>();
            fullforce = fireAngle.forward * bulletForce * 1.5f;
            rb.AddForce(fullforce, ForceMode.Impulse);
        }
    }
}
