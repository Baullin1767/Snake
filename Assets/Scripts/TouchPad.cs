using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TouchPad : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 origin;
    private Vector2 direction;

    private Vector2 smothingDirection;
    public float smothing = 0.1f;

    private void Awake()
    {
        direction = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        Vector2 directionRaw = currentPosition - origin;
        direction = directionRaw.normalized;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
    }

    public Vector2 GetDirection()
    {
        smothingDirection = Vector2.MoveTowards(smothingDirection, direction, smothing);
        return smothingDirection; 
    }
}
