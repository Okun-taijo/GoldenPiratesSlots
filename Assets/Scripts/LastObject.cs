using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastObject : MonoBehaviour
{
    [SerializeField] private RecourceBank _recources;
    [SerializeField] private GameObject _wonPanel;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private GameObject _disactivate;
    public void AnnounceVictory()
    {
        _disactivate.SetActive(false);
        _winSound.Play();
        _wonPanel.SetActive(true);
        _recources.GainChips(150);
        _recources.GainGold(150);
    }
}
