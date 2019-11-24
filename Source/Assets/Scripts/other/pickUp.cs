using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {

    private bool touched;
    private float animTimeDestroy = 1f;

    private float timeDestroy;

    public Animator anim;

	void Start () {
        timeDestroy = Random.Range(8f, 18f);
    }
	
	void Update () {

        timeDestroy -= Time.deltaTime;


        if (touched || timeDestroy <= 0)
        {
            anim.SetTrigger("pickup");

            animTimeDestroy -= Time.deltaTime;

            if(animTimeDestroy <= 0)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touched = true;
        }
    }
}
