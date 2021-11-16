using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        int activePanel = 0;
    
        public Transform mainMenu;
        public Transform optionsPanel;
        public Transform creditsPanel;

        public Transform[] panels;

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
            InitCreditsMenu();
        }

        public void HideCreditsMenu()
        {
            ResetCreditsMenu();
            creditsPanel.DOLocalMoveX(1000, 0.5f);
            mainMenu.DOLocalMoveX(0, 0.5f);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        void InitCreditsMenu()
        {
            panels[0].DOLocalMoveX(0, 0f);
        }

        void ResetCreditsMenu()
        {
            foreach (Transform panel in panels)
            {
                panel.DOLocalMoveX(800, .5f);
            }

            activePanel = 0;
        }

        public void NextSlide()
        {
            panels[activePanel].DOLocalMoveX(800, .5f);
            
            activePanel++;

            if (activePanel > panels.Length - 1)
            {
                activePanel = 0;
            }
            
            panels[activePanel].DOLocalMoveX(0, .5f);
        }
    }
}
