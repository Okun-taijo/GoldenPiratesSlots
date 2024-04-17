using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecourceBank : MonoBehaviour
{
    public int gold;
    public int chips;
    [SerializeField] private TextMeshProUGUI _textForGold;
    [SerializeField] private TextMeshProUGUI _textForChips;
    private void Start()
    {
        gold = PlayerPrefs.GetInt("Gold", 0);
        chips = PlayerPrefs.GetInt("Chips", 100);
        ChangeChipsText();
        ChangeGoldText();
    }

    private void SavePrefs()
    {
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Chips", chips);
        PlayerPrefs.Save();
    }
    public void ChangeGoldText()
    {
        _textForGold.text = gold.ToString();
    }
    public void ChangeChipsText()
    {
        _textForChips.text = chips.ToString();
    }
    public void GainGold(int gains)
    {
        gold += gains;
        ChangeGoldText();
        SavePrefs();
    }

    public void GainChips(int gains)
    {
        chips += gains;
        ChangeChipsText();
        SavePrefs();
    }
    public void SpendGold(int price)
    {
        gold-= price;
        ChangeGoldText();
        SavePrefs();
    }
    public void SpendChips(int price)
    {
        chips -= price;
        ChangeChipsText();
        SavePrefs();
    }
}
