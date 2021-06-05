using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerMovement player;
    UIManager ui;
    int levelCount;
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public IEnumerator GameWin()
    {
        yield return new WaitForSecondsRealtime(2f);
        int randomIndex = Random.Range(1,SceneManager.sceneCountInBuildSettings - 1);
        PlayerPrefs.SetInt("Scene", randomIndex);
        levelCount = PlayerPrefs.GetInt("LevelText");
        levelCount++;
        Debug.Log(levelCount);
    }

    public void ReloadeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        ui.attackButton.SetActive(false);
        StartCoroutine(player.DelayDeath());
    }

    public void StartGame()
    {
        player.anim.SetBool("Run", true);
        Time.timeScale = 1;
        ui.gameCotroller.SetActive(true);
        ui.gameMenu.SetActive(false);
    }
}
