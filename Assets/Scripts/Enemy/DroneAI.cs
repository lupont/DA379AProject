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


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += new Vector3(0.01f, 0, 0);
        // transform.rotation.eulerAngles = new Vector3(1f, 0, 0);
        // transform.Rotate(1f, 0, 0);

        var position = transform.position;
        var rotation = transform.rotation;

        if (Time.time > fireRate + lastShot) 
        {
            var go = Instantiate(bullet, position, rotation);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
            Destroy(go, 3);
            lastShot = Time.time;
        }

        if (target != null) 
        {
            Debug.Log("Target was not null");
            if (agent != null)
            {
                Debug.Log("Agent was not null");
                var p = target.transform.position;
                Debug.Log($"Target pos: {p.x} {p.y} {p.z}");
                Debug.Log(agent.SetDestination(p));
            }
            else Debug.Log("Agent was null");
        }
        else Debug.Log("Target was null");
    }
}
