using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour {

    private bool fan;
    private bool inInfluence;
    private bool influencedFan;

    private float topAmountOfTime;
    private float amountOfTime;

    //variables for comminity influence
    private bool inPublicInfluence;
    public Transform ownInfluence;
    private float InfluenceSpeedReduction = 10f; //for houses convincing other houses

    private float paymentDelay = 2;
    private int[] moneyOptions = {10, 25, 50, 75, 100};
    private int pickedAmountOfMoney;

	void Start () {
        topAmountOfTime = Random.Range(1f, 5f);
        amountOfTime = topAmountOfTime;

        ownInfluence.gameObject.SetActive(false);

        pickedAmountOfMoney = moneyOptions[Random.Range(0, moneyOptions.Length)];
    }
	
	void Update () {

        if (!fan)
        {
            if (inInfluence || inPublicInfluence)
            {
                if(inInfluence)
                {
                    amountOfTime -= Time.deltaTime;
                }
                else
                {
                    if (amountOfTime > 1f)
                    {
                        amountOfTime -= Time.deltaTime / InfluenceSpeedReduction;
                    }
                }

                if(amountOfTime <= 0)
                {
                    fan = true;
                }
            }
            else if (amountOfTime < topAmountOfTime)
            {
                amountOfTime += Time.deltaTime;
            }
        }
        else
        {
            if (inInfluence)
            {
                if (!influencedFan)
                {
                    GameVariables.Notoriety += 1;
                    influencedFan = true;

                    //disscuss threshold
                    ownInfluence.gameObject.SetActive(true);
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;

                    paymentDelay -= Time.deltaTime;

                    if (paymentDelay <= 0)
                    {
                        if (!GameVariables.GoldDiskUpgrade)
                        {
                            GameVariables.Money += pickedAmountOfMoney;
                        }
                        else
                        {
                            GameVariables.Money += (pickedAmountOfMoney * 2);
                        }
                        paymentDelay = 2;
                    }
                }
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.gray;
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Infuence")
        {
            inInfluence = true;
        }

        if (other.gameObject.tag == "Public Influence")
        {
            inPublicInfluence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Infuence")
        {
            inInfluence = false;
        }

        if (other.gameObject.tag == "Public Influence")
        {
            inPublicInfluence = false;
        }
    }
}
