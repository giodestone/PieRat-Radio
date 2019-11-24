using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContol : MonoBehaviour
{

    public float speed = 10f;
    public float reverseSpeed = 10f;
    public float torque;

    private float driftFactor = 0.8f;

    Rigidbody rb;

    public float fule = 10f;
    public float fuleTankGain = 10f;
    private float fuleSpeedReduction = 2f;

    //influence upgrade
    public Transform influence;
    private Vector3 startSize;
    public float upgradeSize = 5;
    private float flexUpgradeSize;
    private float sizeTimer;
    public float setSizeTimer =1;


    //speed upgrade
    public float speedIncrease = 5;
    private float speedTimer;
    public float setspeedTimer =1;

    //gold disk
    private float goldTimer;
    public float setGoldTimer =1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startSize = influence.localScale;
    }

    void Update()
    {
        if (fule > 0 && !GameVariables.IsGameOver)
        {
            if (Input.GetButton("Reverse"))
            {
                if (speedTimer < 0)
                {
                    rb.AddForce(-transform.forward * reverseSpeed);
                }
                else
                {
                    rb.AddForce(transform.forward * (reverseSpeed + speedIncrease));
                }
                fule -= Time.deltaTime / fuleSpeedReduction;
            }
            else if (Input.GetButton("Drive"))
            {
                if (speedTimer < 0)
                {
                    rb.AddForce(transform.forward * speed);
                }
                else
                {
                    rb.AddForce(transform.forward * (speed + speedIncrease));
                }
                fule -= Time.deltaTime / fuleSpeedReduction;
            }

            Money.playerFule = Mathf.RoundToInt(fule);
        }
        else
        {
            GameVariables.IsGameOver = true;
            fule = fuleTankGain;
        }

        float t = Mathf.Lerp(0, torque, rb.velocity.magnitude / 5);
        rb.angularVelocity = transform.up * t * Input.GetAxis("Horizontal");

        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if(sizeTimer > 0)
        {
            flexUpgradeSize = upgradeSize;
            sizeTimer -= Time.deltaTime;
        }
        else if (flexUpgradeSize > 0)
        {
            flexUpgradeSize = 0;
        }

        influence.localScale = new Vector3(startSize.x + GameVariables.influenceIncrease + flexUpgradeSize, startSize.y, startSize.z + GameVariables.influenceIncrease + flexUpgradeSize);

        if (speedTimer >= 0)
        {
            speedTimer -= Time.deltaTime;
        }

        if(goldTimer >= 0)
        {
            GameVariables.GoldDiskUpgrade = true;
            goldTimer -= Time.deltaTime;
        }
        else if (GameVariables.GoldDiskUpgrade)
        {
            GameVariables.GoldDiskUpgrade = false;
        }
    }

    Vector3 ForwardVelocity()
    {
        return transform.forward * Vector3.Dot(rb.velocity, transform.forward);
    }

    Vector3 RightVelocity()
    {
        return transform.right * Vector3.Dot(rb.velocity, transform.right);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barel")
        {
            fule = fuleTankGain;
        }

        if (other.gameObject.tag == "Boy")
        {
            sizeTimer = setSizeTimer;
        }

        if (other.gameObject.tag == "Speed")
        {
            rb.AddForce(transform.forward * (speed / 1.5f), ForceMode.Impulse);
            speedTimer = setSizeTimer;
        }

        if (other.gameObject.tag == "Gold")
        {
            goldTimer = setGoldTimer;
        }
    }
}
