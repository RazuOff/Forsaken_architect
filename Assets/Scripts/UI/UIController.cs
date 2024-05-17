using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
  [SerializeField] private InputController inputController;
  [SerializeField] private Slider energySlider;
  [SerializeField] private TMP_Text scoreText;
  [SerializeField] private GameObject pausePanel, winPanel, losePanel;
  [SerializeField] private TMP_Text scoreTextWin, scoreTextLose;
  private int score = 0;
  public static UIController instance;

  private void Awake()
  {
    instance = this;
  }

  private void OnEnable()
  {
    InputController.OnInputMenu += PausePanelOpen;
  }

  private void OnDisable()
  {
    InputController.OnInputMenu -= PausePanelOpen;
  }
  public void LosePanelOpen()
  {


    Time.timeScale = 0f;
    losePanel.SetActive(true);
    scoreTextLose.text = "score: " + score.ToString("0");
    inputController.isActive = false;


  }

  public void WinPanelOpen()
  {

    Time.timeScale = 0f;
    winPanel.SetActive(true);
    scoreTextWin.text = "score: " + score.ToString("0");
    inputController.isActive = false;



  }

  public void PausePanelOpen()
  {

    if (pausePanel.activeSelf)
    {
      Time.timeScale = 1f;
      pausePanel.SetActive(false);
      inputController.isActive = true;

    }
    else
    {
      Time.timeScale = 0f;
      pausePanel.SetActive(true);
      inputController.isActive = false;

    }
  }
  public void OnRestartButton()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
  public void OnMainMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(0);
  }
  public void ChangeEnergySlider(float maxValuem, float currentValue)
  {
    energySlider.maxValue = maxValuem;
    energySlider.value = currentValue;
  }

  public void ChangeScore(float scoreToAdd)
  {
    score += (int)scoreToAdd;
    scoreText.text = "score: " + score.ToString("0");
  }


}
