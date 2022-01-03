using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_InputField usernameInput;
    // Start is called before the first frame update
    void Start()
    {
        if (PointsManager.instance != null)
        {
            usernameText.text = PointsManager.instance.usernameBest;
            scoreText.text = "" + PointsManager.instance.scoreBest;
            usernameInput.text = PointsManager.instance.username;
        }
    }
    public void StartGame()
    {
        PointsManager.instance.username = usernameInput.text;
        PointsManager.instance.SaveData();//Save data to save also the last username used
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        //Save the current data
        PointsManager.instance.SaveData();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
