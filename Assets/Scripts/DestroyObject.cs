using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;

    public void DestroyChest()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
