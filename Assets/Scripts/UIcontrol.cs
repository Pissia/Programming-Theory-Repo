using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{
    public static UIcontrol instance;
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;
    //Incapsulation
    public int _score
    {
        get { return score; }
        set
        {
            if(value > 0)
            {
                score = value;
            }
            else
            {
                Debug.Log("You can't set a negative scores!");
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        UpdateScore(); 
    }

    public void UpdateScore()
    {
        scoreText.text = $"Loaded skids: {score}";
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
