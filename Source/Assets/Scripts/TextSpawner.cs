using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpawner : MonoBehaviour {

    public static Queue<string> TextQueue;
    public string[] RandomNewsTicks;

    public RectTransform EdgeOfScreen;
    public Text BaseTextPrefab; //a text feidl you can just modify

    RectTransform BottomRightOrigin;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spawnNewText();
    }

    private void spawnNewText()
    {
        string text;
        //Subtract text from queue
        if (TextQueue.Count > 0) //if there is anything in text queue
        {
            text = TextQueue.Dequeue();
        }
        else //queue random stuff
        {
            text = RandomNewsTicks[Random.Range(0, RandomNewsTicks.Length - 1)];
        }

        Transform positionToText;

        Text instanciatedText = Instantiate(BaseTextPrefab, EdgeOfScreen.transform);
        instanciatedText.GetComponent<RectTransform>().anchoredPosition = new Vector2(calculateLengthOfMessage(instanciatedText.text, instanciatedText), instanciatedText.rectTransform.sizeDelta.y);
    }

    int calculateLengthOfMessage(string message, Text text)
    {
        int totalLength = 0;

        Font myFont = text.font;  //chatText is my Text component
        CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = message.ToCharArray();

        foreach (char c in arr)
        {
            myFont.GetCharacterInfo(c, out characterInfo, text.fontSize);

            totalLength += characterInfo.advance;
        }

        return totalLength;
    }
}
