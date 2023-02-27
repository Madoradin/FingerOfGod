using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGravity : MonoBehaviour
{
    private bool isDead;
    private bool isLifted;
    [SerializeField] private float maxHeight = 7f;
    [SerializeField] private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        isLifted = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            isLifted = true;

            if (transform.position.y > maxHeight)
            {
                isDead = true;
            }
        }
        animator.SetBool("Lifted", isLifted);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && isDead == true)
        {
            gameObject.GetComponent<Enemy>().DestroyObject();
            Destroy(gameObject);
        }

        isLifted = false;
        gameObject.GetComponent<EnemyNav>().ReEnableNav();
    }
}
