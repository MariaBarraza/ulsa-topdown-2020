using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    int score = 0;
    [SerializeField]
    Text txtScore;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int points)
    {
        this.score += points;
        txtScore.text = $"Score: {score} pts";
    }
}
