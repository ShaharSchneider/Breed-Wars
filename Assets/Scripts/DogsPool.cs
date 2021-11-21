using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsPool : MonoBehaviour
{
    public static DogsPool instance;
    public GameObject[] dogs;
    private static System.Random r = new System.Random();

    private void Awake()
    {
        instance = this;
    }

    public GameObject getRandomDogFromPool()
    {
        GameObject randomDogPicked = Instantiate(dogs[r.Next(0, dogs.Length)]);
        randomDogPicked.SetActive(true);

        return randomDogPicked;
    }
}
