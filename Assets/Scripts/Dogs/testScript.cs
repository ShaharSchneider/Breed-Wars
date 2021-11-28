using UnityEngine;

//TODO: DELETE THIS SCRIPT
public class testScript : MonoBehaviour
{
    void Start()
    {
        //Dog a = new Boxer(1, 1);
        //Dog b = new Poodle(2, 2);
        //Dog a = new BassetHound(3, 4);
        //Dog b = new ScottishTerrier(5, 6);
        Dog a = new ShibaInu(2, 2);
        Dog b = new SiberianHusky(2, 2);
        a.gameObject.transform.position = new Vector3(-6.0811f, -1.2312f, -1);
        b.gameObject.transform.position = new Vector3(0f, -1.2312f, -1);
    }
}
