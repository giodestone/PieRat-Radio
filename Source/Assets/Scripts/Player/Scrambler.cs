using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scrambler : MonoBehaviour {

    public float ScramblerRechargeTime = 10f;
    public GameObject particleEffectPrefab;

    float lastTimeUsedScrambler;
	// Use this for initialization
	void Start () {
        lastTimeUsedScrambler = 0f;   	
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetButton("Fire1") && lastTimeUsedScrambler + ScramblerRechargeTime < Time.time)
        {
            lastTimeUsedScrambler = Time.time;
            //Instantiate(particleEffectPrefab, transform.position, transform.rotation);
            CapsuleCollider boatInfluenceCapsule = GameObject.FindGameObjectWithTag("Infuence").GetComponent<CapsuleCollider>();
            //Collider[] colliders = Physics.OverlapCapsule(transform.position, boatInfluenceCapsule.center, boatInfluenceCapsule.radius);
            Collider[] colliders = Physics.OverlapSphere(transform.position, boatInfluenceCapsule.radius);
            Debug.Log("Scrambler loc: " + transform.position + boatInfluenceCapsule.radius);
            foreach(var collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    EnemyMover enemyMover = collider.gameObject.GetComponent<EnemyMover>();
                    enemyMover.Scramble();
                    Debug.Log("Scrambled.");
                }
            }
        }
	}
}
