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

    private float lookRadius = 15;

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
            // Debug.Log($"Found player: {players[0].gameObject.ToString()}");
            return true;
        }

        target = null;
        // Debug.Log("Did not find player");
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += new Vector3(0.01f, 0, 0);
        // transform.rotation.eulerAngles = new Vector3(1f, 0, 0);
        FindPlayer();

        // transform.position.Set(position.x, yPosition + 2 * Mathf.Sin(1 * Time.time), position.z);
 
        // if (Time.time > fireRate + lastShot) 
        // {
        //     var go = Instantiate(bullet, position, rotation);
        //     go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
        //     Destroy(go, 3);
        //     lastShot = Time.time;
        // }

        // float viewAngle = 90;

        // transform.Rotate(1, 1, 1);

        if (target != null) 
        {
        //     bool inView = false;
        //     bool isVisible = false;

        //     Vector3 fwd_r = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward;
        //     Vector3 fwd_l = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward;
        //     Debug.DrawRay(transform.position, fwd_r * 2, Color.blue);
        //     Debug.DrawRay(transform.position, fwd_l * 2, Color.blue);


            Vector3 targetDir = target.transform.position - transform.position;
            targetDir.y = targetDir.y + 2;
            float angleToPlayer = (Vector3.Angle(transform.forward, targetDir));
            
        //     inView = angleToPlayer < (viewAngle / 2.0f);

        //     if (Physics.Raycast(transform.position, targetDir, out RaycastHit hit, float.PositiveInfinity))
        //     {
        //         isVisible = hit.collider.gameObject.Equals(target);
        //         Debug.Log(hit.collider.gameObject.name);

        //         Debug.DrawLine(transform.position, hit.transform.position, Color.magenta);

        //     }

        //     Color c = inView ? (isVisible ? Color.green : Color.yellow) : Color.red;
        //     Debug.DrawLine(transform.position, target.transform.position, c);

            // Debug.Log($"In View: {inView}, Is Visible: {isVisible}");
            // Vector3 lookDir = transform.forward * lookRadius;

            float distance = Vector3.Distance(target.transform.position, transform.position);
            Quaternion rot = Quaternion.LookRotation(targetDir);

            if (distance < lookRadius)
            {
                // transform.Rotate(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
                if (distance >= agent.stoppingDistance)
                {
                    agent.SetDestination(target.transform.position);

                    if (Time.time > fireRate + lastShot) 
                    {
                        var go = Instantiate(bullet, transform.position, transform.rotation);
                        go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
                        Destroy(go, 3);
                        lastShot = Time.time;
                    }
                }
            }

            // Debug.DrawRay(transform.position, lookDir, Color.cyan);
            
            // if (Physics.Raycast(transform.position, lookDir, out RaycastHit hit, Mathf.Infinity))
            // {
            //     Debug.DrawRay(transform.position, targetDir * hit.distance, Color.yellow);
            //     if (hit.collider.gameObject.CompareTag("Player"))
            //     {
            //         agent.SetDestination(target.transform.position);
            //         transform.Rotate(targetDir);
            //         Debug.Log("FOUND THE PLAYER!!!!!!!!!!!!!!!!!!!!");

                    
            //     }
            //     else 
            //     {
            //         transform.Rotate(1, 1, 1);
            //         Debug.Log("NOT THE PLAYER???????????????????");
            //     }
            //     // Debug.Log("Did Hit");
            //     // var tp = target.transform.position;
            //     // var p = tp * 0.9f;
            //     // Debug.Log($"Target pos: {p.x} {p.y} {p.z}");
            //     // Debug.Log(agent.SetDestination(p));
            //     // agent.SetDestination(p);
            // }
            // else
            // {
            //     transform.Rotate(1, 1, 1);
            // }
            // else Debug.Log("Can not see the player");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
