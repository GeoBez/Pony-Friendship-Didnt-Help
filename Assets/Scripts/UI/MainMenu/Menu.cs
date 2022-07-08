using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance { get; private set; }
    public static bool GameIsPaused => (Instance && Instance.Menu_Pause.activeInHierarchy) || Time.timeScale == 0F;
    [SerializeField] private Button[] ButtonResetGame;
    [SerializeField] private Button[] ButtonToMenu;
    [SerializeField] private Button[] ButtonsPause;
    [SerializeField] private Text[] FieldTextStats;
    [SerializeField] private GameObject Menu_GameOver;
    [SerializeField] private GameObject Menu_Pause;
    [SerializeField] private GameObject Menu_VictoryMenu;
    [SerializeField] private UpgradeChoiceMenu Menu_UpgradeChoise;
    [SerializeField] private YandexSDK YandexSDK;
    public void Start()
    {
        PlayerStatistics.ResetAll();

        foreach (var buttonsReset in ButtonResetGame)
            buttonsReset.onClick.AddListener(RestartGame);
        foreach (var buttonsMenu in ButtonToMenu)
            buttonsMenu.onClick.AddListener(ToMenu);
        foreach (var buttonsContinue in ButtonsPause)
            buttonsContinue.onClick.AddListener(ShowPause);

        WaveController.EndWar += GetVictory;
        WaveController.Preporation += Menu_UpgradeChoise.MenuOpen;


        Menu_GameOver.SetActive(false);
        Instance = this;
        /*YandexSDK = YandexSDK.instance;
        YandexSDK.ShowInterstitial();*/

    }
    private void OnDestroy()
    {
        PlayerStatistics.ResetAll();
    }
    private void GetVictory()
    {
        Instance.UpdateFieldText();
        Menu_VictoryMenu.SetActive(true);
        Time.timeScale = 0;
    }
    private void ShowPause()
    {
        bool isActive = !Menu_Pause.activeInHierarchy;
        Menu_Pause.SetActive(isActive);
        SetPause(isActive);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameObject[] obj =  Enemy.Enemys.ToArray();
            foreach (GameObject game in obj)
            {
                game.GetComponent<Enemy>().TakeHit(1000);
            }
        }
    }
    /// <summary>
    /// ≈сли ставить паузу, то желательно через этот метод =)
    /// </summary>
    public static void SetPause(bool active)
    {
        if(!active)
            Preparation.ContinueTimer();
        Time.timeScale = active ? 0F : 1F;
    }
    private void UpdateFieldText()
    {
        string[] stats = PlayerStatistics.GetStatistic();
        for (int i = 0; i < FieldTextStats.Length; i++)
        {
            FieldTextStats[i].text = stats[i];
        }
    }
    public static void GetGameOver()
    {
        Instance.UpdateFieldText();
        Instance.Menu_GameOver.SetActive(true);
        SetPause(true);
    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartGame()
    {
        SetPause(false);
        ResetLevel();
    }
   
    public void ToMenu()
    {
        SetPause(false);
        SceneManager.LoadScene(0);
    }
    
}
