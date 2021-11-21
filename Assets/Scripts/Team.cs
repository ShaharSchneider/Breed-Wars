using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Team : MonoBehaviour
{
    private GameObject[] team = new GameObject[5];
    private const int DOG_BUY_VALUE = 3;
    private const int DOG_SELL_VALUE = 1;

    public static Team instance;
    private void Awake()
    {
        instance = this;
    }

    public bool isValidPosition(int position)
    {
        return team[position] == null;
    }

    public bool buyDog(int position, GameObject dog)
    {
        if (isValidPosition(position))
        {
            if (dog.tag.StartsWith("team") || Coins.instance.buy(DOG_BUY_VALUE))
            {
                int i = Array.IndexOf(team, dog);

                if (i != -1)
                {
                    team[i] = null;
                }

                dog.tag = "team" + position;
                team[position] = dog;
                return true;
            }
        }

        return false;
    }

    public bool sellDog(GameObject dog)
    {
        int i = Array.IndexOf(team, dog);
        if (i != -1)
        {
            team[i] = null;
            Destroy(dog);
            Coins.instance.sell(DOG_SELL_VALUE);
            return true;
        }
        return false;
    }
}
