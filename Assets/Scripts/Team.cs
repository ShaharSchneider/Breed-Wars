using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Team : MonoBehaviour
{
    private GameObject[] team = new GameObject[5];
    private GameObject[] xp = new GameObject[5];
    private const int DOG_BUY_VALUE = 3;
    private const int DOG_SELL_VALUE = 1;

    public Sprite xp11;

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

                dog.tag = "team" + position;

                if (i != -1)
                {
                    team[i] = null;
                    Destroy(xp[i]);
                    xp[i] = null;
                }


                GameObject dogXP = new GameObject();
                dogXP.AddComponent<SpriteRenderer>().sprite = xp11;
                dogXP.transform.position = new Vector3((float)(-4.9 + (1.67f) * position), 0.8f, -2);

                xp[position] = dogXP;
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
            Destroy(xp[i]);
            xp[i] = null;
            Coins.instance.sell(DOG_SELL_VALUE);
            return true;
        }
        return false;
    }
}
