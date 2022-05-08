using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text Score;
    [SerializeField] Text Level;
    [SerializeField] Sprite[] Lives;
    [SerializeField] Image _LivesDisplay;

    float TotalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate (float _scoreamount)
    {
        TotalScore += _scoreamount;

        Score.text = "Score : " + TotalScore;
    }

    public void LivesUpdateImage(int CurrentLives)
    {
        _LivesDisplay.sprite = Lives[CurrentLives];
    }
}
