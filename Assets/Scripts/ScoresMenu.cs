using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoresMenu : MonoBehaviour
{
    public TextMeshProUGUI levelOneText;
    public TextMeshProUGUI levelTwoText;

    private void Start()
    {
        levelOneText.text = PlayerPrefs.GetString("Level1Score", "00:00:00");
        levelTwoText.text = PlayerPrefs.GetString("Level2Score", "00:00:00");

    }
    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
