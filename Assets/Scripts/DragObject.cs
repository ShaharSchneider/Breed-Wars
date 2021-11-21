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
        Vector3 mousePos = GetMouseWorldPos();
        Collider2D[] overlap = Physics2D.OverlapAreaAll(mousePos, mousePos);

        if (overlap.Length > 1)
        {
            Collider2D draggedTo = overlap[1];

            if (draggedTo.name.ToString().StartsWith("Pebble"))
            {
                if (draggedTo.tag.Contains("team"))
                {
                    int teamIndex = int.Parse(draggedTo.tag[draggedTo.tag.Length - 1].ToString());

                    if (Team.instance.isValidPosition(teamIndex) && Team.instance.buyDog(teamIndex, gameObject))
                    {
                        Vector3 pos = draggedTo.transform.position;
                        transform.position = new Vector3(pos.x + (float)0.1, pos.y + (float)0.5, -2);
                    }
                    else
                    {
                        transform.position = firstDragPosition;
                    }
                }
                else
                {
                    transform.position = firstDragPosition;
                }
            }
            else if (draggedTo.name.StartsWith("Sell"))
            {
                if (!Team.instance.sellDog(gameObject))
                {
                    transform.position = firstDragPosition;
                }
            }
            else
            {
                transform.position = firstDragPosition;
            }
        }
        else
        {
            transform.position = firstDragPosition;
        }
    }
}
