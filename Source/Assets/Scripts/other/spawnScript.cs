using UnityEngine;

public class spawnScript : MonoBehaviour
{

    private float spawnTimer = 15f;
    public GameObject[] ObjectsToSpawn;

    private float Timer;

    void Start()
    {
       
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)], rndPosWithin, transform.rotation);

            Timer = Random.Range(1f, spawnTimer);
        }
    }


}

