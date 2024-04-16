using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLinks : MonoBehaviour
{
   public void MainMenuLink()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SlotsLink()
    {
        SceneManager.LoadScene("SlotMachineScene");
    }

    public void MinigameLink()
    {
        SceneManager.LoadScene("MinigameScene");
    }

    public void BankLink()
    {
        SceneManager.LoadScene("BankScene");
    }

    public void ShipsLink()
    {
        SceneManager.LoadScene("RaycastGame");
    }

    public void GemsLink()
    {
        SceneManager.LoadScene("GemsMachine");
    }
}
