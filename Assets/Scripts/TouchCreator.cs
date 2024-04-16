using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCreator : MonoBehaviour
{
    [SerializeField] private GameObject _objectForCreate;
    [SerializeField] private int _allowedCreations;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began)
            {
                if (_objectForCreate != null && _allowedCreations > 0)
                {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0f;
                    Instantiate(_objectForCreate, touchPosition, Quaternion.identity);
                    _allowedCreations--;
                }
            }
        }
    }
}
