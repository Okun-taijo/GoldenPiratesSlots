using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private int _chipsAmount;
    [SerializeField] private RecourceBank _recources;
    [SerializeField] private Animator _animator;

    private void Start()
    {
       // _animator = GetComponent<Animator>();
        _recources=FindAnyObjectByType<RecourceBank>();
    }
    public void OpenChips()
    {
        _animator.SetTrigger("Open");
        _recources.GainChips(_chipsAmount);
    }
}
