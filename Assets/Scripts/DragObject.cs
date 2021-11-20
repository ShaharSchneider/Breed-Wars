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
    }

    private Vector3 GetMouseWorldPos()
    {
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
        lastEnteredPebble = PebbleSpawning.instance.getCurrentPebbleByPosition(transform.position);

        if (lastEnteredPebble != null)
        {
            if (lastEnteredPebble.tag.Contains("team"))
            {
                int teamIndex = int.Parse(lastEnteredPebble.tag[lastEnteredPebble.tag.Length - 1].ToString());

                if (Team.instance.isValidPosition(teamIndex))
                {
                    Team.instance.buyDog(teamIndex, gameObject);

                    Vector3 pos = lastEnteredPebble.transform.position;
                    transform.position = new Vector3(pos.x + (float)0.1, pos.y + (float)0.5, -2);
                } else
                {
                    transform.position = firstDragPosition;
                }
            } else if (lastEnteredPebble.tag.Equals("shop")) {
                Vector3 pos = lastEnteredPebble.transform.position;
                transform.position = new Vector3(pos.x + (float)0.1, pos.y + (float)0.5, -2);
                Team.instance.sellDog(gameObject);
            }
        } else {
            transform.position = firstDragPosition;
        }
    }
}
