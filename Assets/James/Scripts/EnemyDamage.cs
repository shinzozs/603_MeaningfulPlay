using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    EnemyPathing pathing;
    // Start is called before the first frame update
    void Start()
    {
        pathing = this.GetComponent<EnemyPathing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !pathing.enemy.isStopped) { SceneManagers.StaticLoad(SceneManagers.GetCurrentScene());}
    }
}
