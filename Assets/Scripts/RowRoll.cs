using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RowRoll : MonoBehaviour
{
    [SerializeField] private int _minimumSpinDuration;
    [SerializeField] private int _maximumSpinDuration;
    [SerializeField] private float _spinSpeed;
    [SerializeField] private float _trashHold;
    public bool _isStopped { get; set; }
    private int _spinDuration;
    private float _distance;
    private float _finalYPosition;
    private void Start()
    {
        _isStopped = true;
    }
    public void StartRoll()
    {
        StartCoroutine(Roll());
    }
    private IEnumerator Roll()
    {
        _isStopped = false;
        _spinDuration=Random.Range(_minimumSpinDuration, _maximumSpinDuration);
        _spinDuration = Mathf.FloorToInt(_spinDuration);
        _distance = _spinSpeed * _spinDuration;
        float elapsedTime = 0f;
        while (elapsedTime < _spinDuration)
        {
            transform.Translate(Vector3.down * _spinSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            if (transform.localPosition.y <= _trashHold)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 1.12f, transform.localPosition.z);
            }
            
            yield return null;
        }
        _isStopped = true;
        _finalYPosition = transform.localPosition.y;
    }
    public float GetFinalYPosition()
    {
        return _finalYPosition;
    }
}

