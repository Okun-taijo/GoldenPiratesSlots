using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedObject : MonoBehaviour
{
    [SerializeField] private float _searchingRange;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private bool _isTargeted = false;

    private void Update()
    {
      SearchLastObject(); 
    }
    public void WasTargeted(bool targeted)
    {
        _isTargeted = targeted;
    }
    private void SearchLastObject()
    {
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, _searchingRange, _targetLayer);
        
        foreach (Collider2D objCollider in nearbyObjects)
        {
            LastObject lastObject = objCollider.GetComponent<LastObject>();
            LinkedObject linkedObject = objCollider.GetComponent<LinkedObject>();
            if (linkedObject != null && linkedObject.gameObject != this.gameObject)
            {
                float distance = Vector2.Distance(transform.position, linkedObject.transform.position);
                if (distance <= _searchingRange)
                {
                    linkedObject.WasTargeted(true);
                }
                else
                {
                    linkedObject.WasTargeted(false);
                }
            }
            if (lastObject != null && lastObject.gameObject != gameObject)
            {
                Vector2 directionToLastObject = (lastObject.transform.position - transform.position).normalized;
                Vector2 startRaycastPosition = (Vector2)transform.position + directionToLastObject * 0.5f;
                RaycastHit2D hit = Physics2D.Raycast(startRaycastPosition, directionToLastObject, _searchingRange);
                float distance = Vector2.Distance(transform.position, lastObject.transform.position);
                Debug.DrawRay(startRaycastPosition, directionToLastObject * _searchingRange, Color.green);
              //  Debug.Log(hit.collider.gameObject);
                if (distance <= _searchingRange && _isTargeted==true)
                {
                    Debug.Log("Raycast hit LastObject! Victory!");
                    lastObject.AnnounceVictory();
                }
                /*float distance = Vector2.Distance(transform.position, lastObject.transform.position);
                if (distance <= _searchingRange)
                {
                    lastObject.AnnounceVictory();
                }*/

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Отображение радиуса поиска в редакторе
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _searchingRange);
    }

}
