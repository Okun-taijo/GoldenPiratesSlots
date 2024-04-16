using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BankItems : MonoBehaviour
{
    public int _gemsCount;
    [SerializeField] private TextMeshProUGUI _gemsCounterText;
    [SerializeField] private RecourceBank _recources;

    private void Start()
    {
        _gemsCount = PlayerPrefs.GetInt("Gems", 0);
        UpdateGemsCounter();
    }
    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("Gems", _gemsCount);
    }
   public void BuyGems(int gems)
    {
        _gemsCount += gems;
        UpdateGemsCounter();
        SavePlayerPrefs();
    }
    public void SpendGems(int gems)
    {
        _gemsCount -= gems;
        UpdateGemsCounter();
        SavePlayerPrefs();
    }

    private void UpdateGemsCounter()
    {
        _gemsCounterText.text = _gemsCount.ToString();
    }

}
