using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneAI : MonoBehaviour
{
    private NavMeshAgent agent;
    
    private GameObject target;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletVel = 5;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private LayerMask mask;

    private float lastShot = 0;

    [SerializeField]
    private float lookRadius = 20;

    private float yPosition;

    [SerializeField]
    private int maxHealth;

    private int health;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.baseOffset = 3;
        agent.Warp(transform.position);
        yPosition = transform.position.y;
        transform.Rotate(0, 180, 0);
        mask = LayerMask.GetMask("LocalPlayer");

        health = maxHealth;
    }

    bool FindPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players != null && players.Length > 0)
        {
            target = players[0];
            return true;
        }

        target = null;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();

        if (target == null)
            return;

        Vector3 targetDir = target.transform.position - transform.position;
        targetDir.y = targetDir.y + 2;
        
        Quaternion rot = Quaternion.LookRotation(targetDir);
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance < lookRadius)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

            if (distance >= agent.stoppingDistance)
                agent.SetDestination(target.transform.position);

            if (Time.time > fireRate + lastShot) 
            {
                var go = Instantiate(bullet, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
                go.GetComponent<BulletScript>()?.setShooter("drone");
                Destroy(go, 3);
                lastShot = Time.time;
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.GetComponent<BulletScript>()?.shooter == "drone")
                return;

            health = Mathf.Clamp(health - 10, 0, maxHealth);

            if (health == 0)
                GameObject.FindObjectOfType<DroneSpawner>()?.Kill(this.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
