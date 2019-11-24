using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public int moneyDeduct = 20;
    public float deductDelay = 5;
    private float setDeductDelay;

    public Transform moneyText;
    public Transform moneyInfo;

    private float infoDelay;
    public float setinfoDelay = 1;
    public string[] DeductTexts;
    private int textChoice;

    public static int playerFule;
    public Transform fuleText;

    void Start () {
        setDeductDelay = deductDelay;
    }

	void Update () {

        moneyText.gameObject.GetComponent<UnityEngine.UI.Text>().text = "£" + GameVariables.Money.ToString();

        deductDelay -= Time.deltaTime;

        if (deductDelay <= 0)
        {
            GameVariables.Money -= moneyDeduct;
            infoDelay = setinfoDelay;
            textChoice = Random.Range(0, DeductTexts.Length);
            deductDelay = setDeductDelay;
        }

        if(infoDelay > 0)
        {
            moneyInfo.gameObject.GetComponent<UnityEngine.UI.Text>().text = DeductTexts[textChoice];
            infoDelay -= Time.deltaTime;
        }
        else if (GameVariables.GoldDiskUpgrade)
        {
            moneyInfo.gameObject.GetComponent<UnityEngine.UI.Text>().text = "x2";
        }
        else
        {
            moneyInfo.gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        }

        fuleText.gameObject.GetComponent<UnityEngine.UI.Text>().text = "Fuel :" + playerFule.ToString();
    }
}
