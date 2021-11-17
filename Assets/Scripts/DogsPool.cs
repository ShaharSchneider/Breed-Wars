using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsPool : MonoBehaviour
{
    public static DogsPool instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject[] dogs;
    public int dogPoolSize = 10;
    private List<GameObject> dogsPool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < dogPoolSize; i++)
        {
            dogsPool.Add(dogs[Random.Range(0, dogs.Length)]);
        }
    }

    public GameObject getRandomDogFromPool()
    {
        GameObject randomDogPicked = Instantiate(dogsPool[Random.Range(0, dogsPool.Count)]);
        randomDogPicked.SetActive(true);

        return randomDogPicked;
    }
}
