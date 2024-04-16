using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGems : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private RecourceBank _recources;
    [SerializeField] private BankItems _items;
    [SerializeField] private int _amount;

    public void OnClickBuy()
    {
        if (_cost<=_recources.gold)
        {
            _items.BuyGems(_amount);
            _recources.SpendGold(_cost);
            
        }
    }
}
