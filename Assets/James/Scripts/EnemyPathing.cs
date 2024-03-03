using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour
{
    private NavMeshAgent enemy;
    [SerializeField]
    private Transform player;

    private bool rayCollision;
    private RaycastHit hit;
    private int layerMask;

    [SerializeField]
    private float stopDistance = 7f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponent<NavMeshAgent>();

        // Bit shift the index of the layer (6 and 7) to get a bit mask
        layerMask = (1 << 6) | (1 << 7);

        // This would cast rays only against colliders in layer 6.
        // But instead we want to collide against everything except layer 6. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hit.collider);
        if (this.GetComponentInChildren<Renderer>().isVisible && rayCollision && !hit.collider.isTrigger && hit.collider.CompareTag("Player"))
        {
            enemy.isStopped = true;
        }
        else
        { 
            enemy.isStopped = false;
            enemy.SetDestination(player.position);
        }
    }

    private void FixedUpdate()
    {
        rayCollision = Physics.Raycast(this.transform.position, player.position - this.transform.position, out hit, stopDistance, layerMask);
        //Debug.DrawRay(this.transform.position, (player.position - this.transform.position) * hit.distance, Color.yellow);
        /*
        rayCollision = 
            Physics.Raycast(player.position, new Vector3(this.transform.position.x + radius, this.transform.position.y, this.transform.position.z) - player.position, out hit, 5f, layerMask) || 
            Physics.Raycast(player.position, new Vector3(this.transform.position.x - radius, this.transform.position.y, this.transform.position.z) - player.position, out hit, 5f, layerMask) ||
            Physics.Raycast(player.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + radius) - player.position, out hit, 5f, layerMask) ||
            Physics.Raycast(player.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - radius) - player.position, out hit, 5f, layerMask);
        */
    }
}
