using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject options;
    public GameObject chrono;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button chronoButton;
    public Button chronoN1Button;
    public Button chronoN2Button;
    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        chronoButton.onClick.AddListener(Enablechrono);
        chronoN1Button.onClick.AddListener(ChronoN1);
        chronoN2Button.onClick.AddListener(ChronoN2);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void ChronoN1()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(5);
    }
    public void ChronoN2()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(5);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        chrono.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
        chrono.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
        chrono.SetActive(false);
    }
    public void Enablechrono()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        chrono.SetActive(true);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
        chrono.SetActive(false);
    }
}
