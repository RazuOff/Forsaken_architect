using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
  [SerializeField] private TMP_Text scoreText;

  private int score;
  private void Start()
  {
    LoadScore();
    scoreText.text = "score: "+ score.ToString();
  }


  private void LoadScore()
  {
    score = PlayerPrefs.GetInt("Score");
    
  }


  public void OnNextButton()
  {
    SceneManager.LoadScene(0);
  }
}
