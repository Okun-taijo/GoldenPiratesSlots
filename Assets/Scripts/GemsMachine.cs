using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsMachine : MonoBehaviour
{
    [SerializeField] private Image[] _slots;
    [SerializeField] private Sprite[] _symbols;
    [SerializeField] private float _spinTime;
    [SerializeField] private int _price;
    [SerializeField] private Button _toShipsGame;
    [SerializeField] private int _winGain;
    private bool isSpinning = false;
    [SerializeField] private BankItems _gemsBank;
    [SerializeField] private RecourceBank _recources;
    [SerializeField] private AudioSource _jackpotSound;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        InitializeSlots();
    }

    public void OnClickSpin()
    {
        if (_gemsBank._gemsCount >= _price)
        {
            _gemsBank.SpendGems(_price);
            if (!isSpinning)
            {
                StartCoroutine(SpinSlots());
            }
        }
    }


    private void InitializeSlots()
    {
        foreach (Image slots in _slots)
        {
            int randomSymbolIndex = Random.Range(0, _symbols.Length);
            slots.sprite = _symbols[randomSymbolIndex];
            slots.rectTransform.localScale = new Vector3(0.8f, 0.6f, 1f);
        }
    }

    private IEnumerator SpinSlots()
    {
        isSpinning = true;
        float elapsedTime = 0.0f;
        while (elapsedTime < _spinTime)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                int randomSymbolIndex = Random.Range(0, _symbols.Length);
                _slots[i].sprite = _symbols[randomSymbolIndex];
                _slots[i].rectTransform.localScale = new Vector3(0.8f, 0.6f, 1f);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isSpinning = false;
        CheckResults();
    }

    private void CheckResults()
    {
        Sprite[] currentSprites = new Sprite[_slots.Length];
        for (int i = 0; i < _slots.Length; i++)
        {
            currentSprites[i] = _slots[i].sprite;
        }

        if (currentSprites[0] == currentSprites[1] && currentSprites[1] == currentSprites[2])
        {
                _recources.GainGold(_winGain);
                _toShipsGame.gameObject.SetActive(true);
            _jackpotSound.Play();
            _animator.SetTrigger("Win");
        }
    }
}
