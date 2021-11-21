using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsPool : MonoBehaviour
{
    public static DogsPool instance;
    private static System.Random r = new System.Random();

    private void Awake()
    {
        instance = this;
        //for (int i = 0; i < dogPoolSize; i++)
        //{
        //    dogsPool.Add(dogs[r.Next(0, dogs.Length)]);
        //}
    }

    public GameObject[] dogs;
    //public int dogPoolSize = 10;
    //private List<GameObject> dogsPool = new List<GameObject>();

    void Start()
    {

    }

    public GameObject getRandomDogFromPool()
    {
        GameObject randomDogPicked = Instantiate(dogs[r.Next(0, dogs.Length)]);
        randomDogPicked.SetActive(true);

        return randomDogPicked;
    }
}
