using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Indestructable : MonoBehaviour
{
    
    public static Indestructable indestructable;

    private void Start()
    {
        if (indestructable == null)
        {
            indestructable = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

