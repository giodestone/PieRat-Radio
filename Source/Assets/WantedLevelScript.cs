using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedLevelScript : MonoBehaviour {
    public EnemySpawner EnemySpawner;

    public GameObject star1, star2, star3, star4, star5; //ORDER MATTERS!

    private WantedLevel currentWantedLevel;
	// Use this for initialization
	void Start () {
        updateCurrentWantedLevel();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        updateCurrentWantedLevel();
        Debug.Log(GameVariables.Notoriety + " " + currentWantedLevel.Stars + " per level: " + GameVariables.MaxNotoreity / 6);
        switch (currentWantedLevel.Stars)
        {
            case 0:
                star1.active = false;
                star2.active = false;
                star3.active = false;
                star4.active = false;
                star5.active = false;
                break;
            case 1:
                star1.active = true;
                star2.active = false;
                star3.active = false;
                star4.active = false;
                star5.active = false;
                break;
            case 2:
                star1.active = true;
                star2.active = true;
                star3.active = false;
                star4.active = false;
                star5.active = false;
                break;
            case 3:
                star1.active = true;
                star2.active = true;
                star3.active = true;
                star4.active = false;
                star5.active = false;
                break;
            case 4:
                star1.active = true;
                star2.active = true;
                star3.active = true;
                star4.active = true;
                star5.active = false;
                break;
            case 5:
                star1.active = true;
                star2.active = true;
                star3.active = true;
                star4.active = true;
                star5.active = true;
                break;
        }

    }

    void updateCurrentWantedLevel()
    {
        foreach (var wantedLevel in EnemySpawner.WantedLevels)
        {
            if (GameVariables.Notoriety >= wantedLevel.RangeLow &&
                GameVariables.Notoriety <= wantedLevel.RangeHigh)
            {
                currentWantedLevel = wantedLevel;
                break;
            }
        }
    }
}
