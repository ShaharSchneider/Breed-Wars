using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private Vector3 firstDragPosition;
    private GameObject lastEnteredPebble;

    void OnMouseDown()
    {
        firstDragPosition = gameObject.transform.position;

        // Store offset = gameobject world pos - mouse world pos
        //mOffset = firstDragPosition - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 mouse = GetMouseWorldPos();
        transform.position = new Vector3(mouse.x, mouse.y, -1);
    }

    void OnMouseUp()
    {
        if (lastEnteredPebble != null)
        {
            Vector3 pos = lastEnteredPebble.transform.position;
            transform.position = new Vector3(pos.x + (float)0.1, pos.y + (float)0.5, pos.z - 1);

            int teamIndex = int.Parse(lastEnteredPebble.tag[lastEnteredPebble.tag.Length - 1].ToString());
            Team.instance.buyDog(teamIndex, gameObject);
        } else {
            transform.position = firstDragPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("team"))
        {
            int teamIndex = int.Parse(other.tag[other.tag.Length - 1].ToString());
            
            if (Team.instance.isValidPostion(teamIndex))
            {
                lastEnteredPebble = other.gameObject;

                //This is for debug
                other.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.Equals(lastEnteredPebble))
        {
            lastEnteredPebble = null;

            if (other.tag.Contains("team"))
            {
                //This is for debug
                other.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
