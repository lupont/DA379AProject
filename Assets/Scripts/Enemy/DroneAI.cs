using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneAI : MonoBehaviour
{
    private NavMeshAgent agent;
    
    [SerializeField]
    private GameObject target;


    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletVel = 5;

    [SerializeField]
    private float fireRate;


    private float lastShot = 0;

    private float lookRadius = 15;

    private float yPosition;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.baseOffset = 3;
        agent.Warp(transform.position);
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += new Vector3(0.01f, 0, 0);
        // transform.rotation.eulerAngles = new Vector3(1f, 0, 0);
        transform.Rotate(1f, 0, 0);

        var position = transform.position;
        var rotation = transform.rotation;

        // transform.position.Set(position.x, yPosition + 2 * Mathf.Sin(1 * Time.time), position.z);
 
        if (Time.time > fireRate + lastShot) 
        {
            var go = Instantiate(bullet, position, rotation);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
            Destroy(go, 3);
            lastShot = Time.time;
        }

        if (target != null && agent != null) 
        {
            Vector3 targetDir = target.transform.position - transform.position;
            float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));
            
            if (angleToPlayer >= -90 && angleToPlayer <= 90) // 180° FOV
            {
                var tp = target.transform.position;
                var p = tp * 0.9f;
                Debug.Log($"Target pos: {p.x} {p.y} {p.z}");
                Debug.Log(agent.SetDestination(p));
            }
        }
        else Debug.Log("Target or agent was null");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
