using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class StartObject : MonoBehaviour
{
    [SerializeField] private float _linkingRange;
    [SerializeField] private LayerMask _targetLayer;
   
    private void Update()
    {
        SearchForNextObject();
    }
    void SearchForNextObject()
    {
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, _linkingRange, _targetLayer);

        foreach (Collider2D objCollider in nearbyObjects)
        {
            LinkedObject linkedObject = objCollider.GetComponent<LinkedObject>();

            if (linkedObject != null)
            {
                float distanceToLinkedObject = Vector2.Distance(transform.position, linkedObject.transform.position);

                // Если расстояние больше _linkingRange, сбросить цель
                if (distanceToLinkedObject > _linkingRange)
                {
                    linkedObject.WasTargeted(false);
                }
                else
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, (linkedObject.transform.position - transform.position).normalized);
                    Debug.DrawRay(transform.position, (linkedObject.transform.position - transform.position).normalized * _linkingRange, Color.blue);
                    Debug.Log(hit.collider.gameObject);
                    if (hit.collider != null && hit.collider.gameObject == linkedObject.gameObject)
                    {
                        linkedObject.WasTargeted(true);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _linkingRange);
    }
}

