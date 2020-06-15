using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamesession : MonoBehaviour
{
    [SerializeField] int playerlives = 3;
    [SerializeField] int score = 0;
    [SerializeField] Text lives;
    [SerializeField] Text scorebroad;
        
    public void Awake()
    {
        int gamesession = FindObjectsOfType<gamesession>().Length;
        if (gamesession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lives.text = playerlives.ToString();
        scorebroad.text = score.ToString();
    }
    public void AddToScore(int pointstoadd)
    {
        score += pointstoadd;
        scorebroad.text = score.ToString();
    }
    public void processplayerdeath()
    {
        if (playerlives >1 )
        {
            TakeLife();
        }
        else
        {
            ResetGameProgess();
        }
    }

    private void TakeLife()
    {
        playerlives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lives.text = playerlives.ToString();
        
    }

    private void ResetGameProgess()
    {
        SceneManager.LoadScene(0);
        DestroyObject(gameObject);
    }
}
