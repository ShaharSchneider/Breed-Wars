using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebbleSpawning : MonoBehaviour
{
    private GameObject[] pebbles = new GameObject[11];
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
                tag = "shop";
            }

            GameObject pebble = Instantiate(selector, currentVector, Quaternion.identity) as GameObject;
            pebble.transform.localScale = new Vector3((float)width, (float)height);
            pebble.tag = tag;
            pebble.SetActive(true);
            pebbles[i] = pebble;
        }
    }
}
