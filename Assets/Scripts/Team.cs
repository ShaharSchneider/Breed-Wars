using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Team : MonoBehaviour
{
    private GameObject[] team = new GameObject[5];

    public static Team instance;
    private void Awake()
    {
        instance = this;
    }

    public bool isValidPosition(int position)
    {
        return team[position] == null;
    }

    public void buyDog(int position, GameObject dog)
    {
        if(isValidPosition(position))
        {
            int i = Array.IndexOf(team, dog);
            
            if (i != -1)
            {
                team[i] = null;
            }

            team[position] = dog;
        }

        for (int i = 0; i < team.Length; i++)
        {
            if(!isValidPosition(i))
            {
                Debug.Log(team[i].name);
            }
        }
    }
}
