using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{

    [SerializeField] private Transform gate;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        gate = GameObject.FindGameObjectWithTag("Gate").gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = gate.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Gate")
        {
            gameObject.GetComponent<Enemy>().ReachedGate();
        }
    }

    public void ReEnableNav()
    {
        agent.enabled = true;
        agent.destination = gate.position;
    }

}
