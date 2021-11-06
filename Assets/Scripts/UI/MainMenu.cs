using DG.Tweening;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Transform mainMenu;
    public Transform optionsPanel;
    public Transform creditsPanel;
    
    public void ShowMainMenu(Transform menuToHide)
    {
        mainMenu.DOLocalMoveX(0, 1f);
    }

    public void ShowOptionsMenu()
    {
        mainMenu.DOLocalMoveX(-1000, 0.5f);
        optionsPanel.DOLocalMoveX(0, 0.5f);
    }

    public void HideOptionsMenu()
    {
        optionsPanel.DOLocalMoveX(1000, 0.5f);
        mainMenu.DOLocalMoveX(0, 0.5f);
    }

    public void ShowCreditsMenu()
    {
        mainMenu.DOLocalMoveX(-1000, 0.5f);
        creditsPanel.DOLocalMoveX(0, 0.5f);
    }

    public void HideCreditsMenu()
    {
        creditsPanel.DOLocalMoveX(1000, 0.5f);
        mainMenu.DOLocalMoveX(0, 0.5f);
    }
}
