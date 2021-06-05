using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    int currentScene = 0;
    float lvlCount = 0;
    UIManager uiManager;
    PlayerMovement player;
 
    void Start()
    {
        instance = this;
        player = FindObjectOfType<PlayerMovement>();
        currentScene = PlayerPrefs.GetInt("Scene");
        if (currentScene == 0) {
            currentScene = 1;
            lvlCount = currentScene;
            PlayerPrefs.SetFloat("LevelCount",lvlCount);
        }
        SceneManager.LoadScene(currentScene,LoadSceneMode.Additive);
    }
}