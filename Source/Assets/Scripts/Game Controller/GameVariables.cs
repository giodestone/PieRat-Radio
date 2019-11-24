using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static float percentage = 0.35f; //basically if 0.8f you will need to have influence over 80% of buildings to have 5 stars.
    public static float WantedLevelValue = 0f; //Affects current wanted level. Should stay between 0 and 500. Every 100 is a new level.
    public static float Money = 1000f; //In GBP
    public static float MaxNotoreity = 0f;
    public static float Notoriety = 0f;

    public static bool GoldDiskUpgrade = false;
    public static float influenceIncrease;

    public static bool IsGameOver = false;
    public static float TimeOfDeath = 0;

    public static float MoneyAtDeath;
    public static float InfluenceAtDeath;

    public static void GameOver()
    {
        IsGameOver = true;
        TimeOfDeath = Time.time;
        MoneyAtDeath = Money;
        InfluenceAtDeath = Notoriety;  
    }

    private void Start()
    {
        GameObject[] allHouses = GameObject.FindGameObjectsWithTag("house");
        int totalHouses = allHouses.Length;

        influenceIncrease = (Notoriety / totalHouses) * 5;

        //Debug.Log(totalHouses);

        float notor = (totalHouses * percentage); //each house has max each of noteriety so no need to add anything.
        MaxNotoreity = notor;
        notor /= 6; //divide by 6 to get the increments.

        EnemySpawner enemySpawner = GetComponent<EnemySpawner>();
        WantedLevel[] wantedLevels = enemySpawner.WantedLevels;
        float curRage = 0f;
        for (int i = 0; i < wantedLevels.Length; i++)
        {
            wantedLevels[i].RangeLow = curRage;
            curRage += notor;
            wantedLevels[i].RangeHigh = curRage;
        }
        wantedLevels[wantedLevels.Length - 1].RangeHigh = float.PositiveInfinity; //make sure that the last noteriety is just as long as possible
    }

}
