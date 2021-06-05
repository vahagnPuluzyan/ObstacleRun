using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerMovement player;

    public GameObject gameCotroller;
    public GameObject gameMenu;
    public GameObject reloadeMenu;
    public GameObject attackButton;
    public GameObject swipeImage;
    public GameObject tapImage;
    public Image flipButton;
    public Image rollButton;
    public Text lvlText;

    private void Start()
    {
        lvlText.text = PlayerPrefs.GetFloat("LevelCount").ToString();
        player = FindObjectOfType<PlayerMovement>();
        Time.timeScale = 0;
    }

    void Update()
    {
        if (player.flip)
        {
            flipButton.color = new Color32(108, 108, 108, 255);
        }
        else
        {
            flipButton.color = new Color32(108, 108, 108, 140);
        }
        if (player.roll)
        {
            rollButton.color = new Color32(108, 108, 108, 255);
        }
        else
        {
            rollButton.color = new Color32(108, 108, 108, 140);
        }
    }
}
