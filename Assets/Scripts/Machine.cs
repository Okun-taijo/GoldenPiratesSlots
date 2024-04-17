using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private RowRoll[] _rows;
    [SerializeField] private RecourceBank _recourceBank;
    [SerializeField] private int _cost;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _winAudioSource;
    [SerializeField] private AudioSource _jackpotAudio;
    [SerializeField] private float _minimumPosition;
    [SerializeField] private float _maximumPosition;
    [SerializeField] private ScenesLinks _scenesLinks;
    public void RollOnClickl()
    {
        if (_recourceBank.chips >= _cost)
        {
            if (_rows.All(row => row._isStopped))
            {
                _recourceBank.SpendChips(_cost);
                foreach (var row in _rows)
                {
                    row.StartRoll();
                }
                StartCoroutine(CheckPositions());
            }
        }
        else
        {
            _scenesLinks.MinigameLink();
        }
    }

    private IEnumerator CheckPositions()
    {
        yield return new WaitUntil(() => _rows.All(row => row._isStopped));
        List<float> yPositions = new List<float>();
        foreach (var row in _rows)
        {
            float finalY = row.GetFinalYPosition();
            yPositions.Add(finalY);
        }
        bool allPositionsEqual = yPositions.All(y => Mathf.Approximately(y, yPositions[0]));
        if (allPositionsEqual)
        {
            bool allPositionsInRange = _rows.All(row =>
            {
                float yPos = row.transform.localPosition.y;
                return yPos >= _minimumPosition && yPos <= _maximumPosition;
            });
            if (allPositionsInRange)
            {
                CheckJackpot(true);
            }
            else
            {
                CheckJackpot(false);
            }
        }
    }

    private void CheckJackpot(bool jackpot)
    {
        if (jackpot)
        {
            _animator.SetTrigger("Jackpot");
            _jackpotAudio.Play();
            _recourceBank.GainGold(5000);
        }
        else
        {
            _animator.SetTrigger("BigWin");
            _winAudioSource.Play();
            _recourceBank.GainGold(1000);
        }
    }
}
