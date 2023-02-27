using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{

    private float deathTime = 1f;

    private Color tempcolor;
    // Start is called before the first frame update
    void Start()
    {
        tempcolor = gameObject.GetComponent<Renderer>().material.color;
        Invoke("DestroyObject", deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        tempcolor.a = Mathf.MoveTowards(tempcolor.a, 0, Time.deltaTime);
        gameObject.GetComponent<Renderer>().material.color = tempcolor;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
