using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject OptionsMenuScreen;
    public GameObject PauseMenuScreen;
    public GameObject LevelSelectMenuScreen;
    public GameObject GameScreenScreen;
    public GameObject BannerAd;

    public Game Game;

    public Options options;

    private List<GameObject> listScreens = new List<GameObject>();

    private void Awake()
    {
        listScreens.Add(MainMenuScreen);
        listScreens.Add(OptionsMenuScreen);
        listScreens.Add(PauseMenuScreen);
        listScreens.Add(LevelSelectMenuScreen);
        listScreens.Add(GameScreenScreen);
    }

    async public void OnEnable()
    {
        EnableMainMenuScreen();
        await System.Threading.Tasks.Task.Delay(100);
        options.InitVolumes();

    }

    private void DisableAllScreen()
    {
        foreach(GameObject go in listScreens)
        {
            go.SetActive(false);
        }
        BannerAd.SetActive(false);
    }

    public void EnableMainMenuScreen()
    {
        DisableAllScreen();
        MainMenuScreen.SetActive(true);
        Game.gameObject.SetActive(false);
    }

    public void EnableLevelSelectionMenuScreen()
    {
        DisableAllScreen();
        LevelSelectMenuScreen.SetActive(true);
    }

    public void EnableOptionsMenuScreen()
    {
        OptionsMenuScreen.SetActive(true);
    }

    public void DisableOptionsMenuScreen()
    {
        OptionsMenuScreen.SetActive(false);
    }

    public void EnablePauseMenuScreen()
    {
        PauseMenuScreen.SetActive(true);
    }

    public void DisablePauseMenuScreen()
    {
        PauseMenuScreen.SetActive(false);
    }

    public void EnableGameScreenScreen()
    {
        DisableAllScreen();
        GameScreenScreen.SetActive(true);
        Game.gameObject.SetActive(true);
        Game.StartGame();
        BannerAd.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
