using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableOnTouch : MonoBehaviour
{
    private bool _isDragging = false;
    private Vector3 _offset;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        _offset = transform.position - Camera.main.ScreenToWorldPoint(touch.position);
                        _isDragging = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(touch.position) + _offset;
                        transform.position = new Vector3(Mathf.Clamp(newPosition.x, -5f, 5f), Mathf.Clamp(newPosition.y, -5f, 5f), 0f);
                       
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isDragging = false;
                    break;
            }
        }
    }
}
