using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebbleSpawning : MonoBehaviour
{
    public static PebbleSpawning instance;
    private void Awake()
    {
        instance = this;
    }

    private GameObject[] pebbles = new GameObject[11];
    private List<GameObject> dogs = new List<GameObject>();
    public GameObject selector; //selected in the editor
    private float width = (float)1.29;
    private float height = (float)1.58;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pebbles.Length; i++)
        {
            Vector3 currentVector;
            string tag;
            if (i < 5)
            {
                currentVector = new Vector3((float)(-5 + (width * 1.3) * i), (float)-0.5, -1);
                tag = "team" + i;
            }
            else
            {
                currentVector = new Vector3((float)(-5 + (width * 1.3) * (i - 5)), (float)-2.22, -1);

                GameObject dog = DogsPool.instance.getRandomDogFromPool();
                dog.transform.position = new Vector3(currentVector.x + (float)0.1, currentVector.y + (float)0.5, currentVector.z - 1);
                dogs.Add(dog);
                tag = "shop";
            }

            GameObject pebble = Instantiate(selector, currentVector, Quaternion.identity) as GameObject;
            pebble.transform.localScale = new Vector3((float)width, (float)height);
            pebble.tag = tag;
            pebble.SetActive(true);
            pebbles[i] = pebble;
        }
    }

    public GameObject getCurrentPebbleByPosition(Vector3 pos)
    {
        for (int i = 0; i < pebbles.Length; i++)
        {
            Collider2D c = pebbles[i].GetComponent<Collider2D>();

            if (IsInside(c, pos))
            {
                return pebbles[i];
            }
        }

        return null;
    }

    private bool IsInside(Collider2D c, Vector3 point)
    {
        return c.bounds.Contains(point);
    }
    void OnMouseUp()
    {
        List<GameObject> tempDogs = new List<GameObject>();

        for (int i = 5; i < pebbles.Length; i++)
        {
            Vector3 currentVector = new Vector3((float)(-4.9 + (width * 1.3) * (i - 5)), (float)-1.72, -2);

            GameObject dog = DogsPool.instance.getRandomDogFromPool();
            dog.transform.position = currentVector;
            tempDogs.Add(dog);

            if (!dogs[i - 5].tag.StartsWith("team"))
            {
                Destroy(dogs[i - 5]);
            }
        }

        dogs.Clear();
        dogs.AddRange(tempDogs);
    }
}
