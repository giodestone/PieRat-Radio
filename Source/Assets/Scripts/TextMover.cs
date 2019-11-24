using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMover : MonoBehaviour {

    public float speed = 10.0f;

    private GameObject outOfBounds;

    RectTransform rectTransform;

    private void Start()
    {
        outOfBounds = GameObject.FindGameObjectWithTag("UIOutOfBounds");
        if (!outOfBounds)
        {
            Debug.Log("Error: Out of bounds not found for text.");
        }

        rectTransform = this.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        //check if out of bounds
        if (outOfBounds.GetComponent<RectTransform>().rect.Contains(rectTransform.rect.position) &&
            outOfBounds.GetComponent<RectTransform>().rect.Contains(rectTransform.rect.size + rectTransform.rect.position))
        {
            Destroy(this, 0.1f);
        }

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + speed * Time.deltaTime, rectTransform.anchoredPosition.y);
	}
}
