using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGravity : MonoBehaviour
{
    private bool isDead;
    [SerializeField] private float maxHeight = 7f;


    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > maxHeight)
        {
            isDead = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" && isDead == true)
        {
            gameObject.GetComponent<Enemy>().DestroyObject();
            Destroy(gameObject);
        }

        gameObject.GetComponent<EnemyNav>().ReEnableNav();
    }
}
