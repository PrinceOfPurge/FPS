using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform shootPoint; // The point from which the projectile will be instantiated
    public float projectileSpeed = 10f; // Speed of the projectile

    void Update()
    {
        // Check if the fire button is pressed (default is left mouse button or Ctrl)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the shoot point
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        // Get the Rigidbody component of the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Set the velocity of the projectile
        rb.velocity = shootPoint.forward * projectileSpeed;
    }
}
