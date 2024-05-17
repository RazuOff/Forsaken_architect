using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
  [SerializeField] Slider soundSlider, musicSlider;
  [SerializeField] GameObject settingsPanel;

  private float sound, music;

  private void Start()
  {
    LoadPerfs();    
  }

  
  public void PlayButton()
  {
    SceneManager.LoadScene(1);
    
  }
  public void SettingsButton()
  {
    settingsPanel.SetActive(true);
    soundSlider.value = sound;
    musicSlider.value = music;
  }
  public void SaveButton()
  {
    SavePrefs();
    settingsPanel.SetActive(false);
  }

  public void ExitButton()
  {
    Application.Quit();
  }


  private void LoadPerfs()
  {
    sound = PlayerPrefs.GetFloat("Sound");
    music = PlayerPrefs.GetFloat("Music");
  }

  private void SavePrefs()
  {
    sound = soundSlider.value;
    music = musicSlider.value;
    PlayerPrefs.SetFloat("Sound", sound);
    PlayerPrefs.SetFloat("Music", music);
    PlayerPrefs.Save();
  }

}
