using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreDesplay : MonoBehaviour {


    public Transform moneyDesplay;
    public Transform fanDesplay;

	void Start () {
		
	}

	void Update () {
        moneyDesplay.gameObject.GetComponent<UnityEngine.UI.Text>().text = "£" + GameVariables.MoneyAtDeath.ToString();
        fanDesplay.gameObject.GetComponent<UnityEngine.UI.Text>().text =  GameVariables.InfluenceAtDeath.ToString();
    }
}
