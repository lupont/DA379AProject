using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    public float lookRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
