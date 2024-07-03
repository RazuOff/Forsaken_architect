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
  [SerializeField] private Slider energySlider;
  [SerializeField] private TMP_Text scoreText;
  [SerializeField] private GameObject pausePanel, perksPanel;
  [SerializeField] private string winScene, loseScene;
  private int score = 0;
  public static UIController instance;

  private void Awake()
  {
    instance = this;
  }

  private void OnEnable()
  {
    InputController.OnInputMenu += PausePanelOpen;
    InputController.OnInputMenu += ClosePerksMenu;
    InputController.OnPerkMenuOpen += OpenPerksMenu;
  }

  private void OnDisable()
  {
    InputController.OnInputMenu -= PausePanelOpen;
    InputController.OnInputMenu -= ClosePerksMenu;
    InputController.OnPerkMenuOpen -= OpenPerksMenu;
  }
  public void LoseSceneLoad()
  {

    PlayerPrefs.SetInt("Score", score);
    SceneManager.LoadScene(loseScene);

  }
    
  public void WinSceneLoad()
  {
    PlayerPrefs.SetInt("Score", score);
    SceneManager.LoadScene(winScene);

  }

  public void PausePanelOpen()
  {

    if (pausePanel.activeSelf)
    {
      Time.timeScale = 1f;
      pausePanel.SetActive(false);
      InputController.instance.isActive = true;

    }
    else if (!perksPanel.activeSelf) 
    {
      Time.timeScale = 0f;
      pausePanel.SetActive(true);
      InputController.instance.isActive = false;

    }
  }
  public void OnRestartButton()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  private void OpenPerksMenu()
  {
    if (!perksPanel.activeSelf)
    {
      Time.timeScale = 0f;
      perksPanel.SetActive(true);
      InputController.instance.isActive = false;
    }
  }

  private void ClosePerksMenu()
  {
    if (perksPanel.activeSelf)
    {
      Time.timeScale = 1f;
      perksPanel.SetActive(false);
      InputController.instance.isActive = true;
    }
  }

  public void OnPerkMenuButton()
  {
    if (perksPanel.activeSelf)
    {
      Time.timeScale = 1f;
      perksPanel.SetActive(false);
      InputController.instance.isActive = true;
    }
    else
    {
      Time.timeScale = 0f;
      perksPanel.SetActive(true);
      InputController.instance.isActive = false;
    }
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
