using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel, SettingsPanel;
    [SerializeField] private AudioSource AudioSFX, AudioBGM;
    [SerializeField] private TMP_Dropdown ResolutionDropdown;
    [SerializeField] private Slider SFXSlider, BGMSlider;
    [SerializeField] private Toggle FullscreenToggle;
    private Resolution[] resolutions;
    private List<string> options = new List<string>();
    void Start()
    {
        //MainPanel.SetActive(false);
        //SettingsPanel.SetActive(false);
        AudioSFX.volume = PlayerPrefs.GetFloat("SFX");
        AudioBGM.volume = PlayerPrefs.GetFloat("BGM");
        SFXSlider.value = AudioSFX.volume;
        BGMSlider.value = AudioBGM.volume;
        FullscreenToggle.isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        int currResolutionIdx = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution resolution = resolutions[i];
            options.Add(resolution.width + "x" + resolution.height);
            if(resolution.Equals(Screen.currentResolution))
            {
                currResolutionIdx = i;
            }
        }
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currResolutionIdx;
        ResolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        MainPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        MainPanel.SetActive(false);
    }

    public void ToSettings()
    {
        MainPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void ToMain()
    {
        SettingsPanel.SetActive(false);
        MainPanel.SetActive(true);
        PlayerPrefs.SetFloat("SFX", AudioSFX.volume);
        PlayerPrefs.SetFloat("BGM", AudioBGM.volume);
    }

    public void ChangeFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeSFXVolume(float volume)
    {
        AudioSFX.volume = volume;
    }

    public void ChangeBGMVolume(float volume)
    {
        AudioBGM.volume = volume;
    }

    public void ChangeResolution(int index)
    {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
    }

    public void ToggleSettings()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }

    public void SceneMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SceneGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
