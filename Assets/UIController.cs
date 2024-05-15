using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
  [SerializeField] private Slider energySlider;
  [SerializeField] private TMP_Text scoreText;

  private int score = 0;
  public static UIController instance;

  private void Awake()
  {
    instance = this;
  }

  public void ChangeEnergySlider(float maxValuem, float currentValue)
  {
    energySlider.maxValue = maxValuem;
    energySlider.value = currentValue;
  }

  public void ChangeScore(float scoreToAdd)
  {
    score += (int)scoreToAdd;
    scoreText.text = score.ToString("0");
  }


}
