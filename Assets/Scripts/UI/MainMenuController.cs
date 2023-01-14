using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The basic encapsulated logic for the main menu.
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsView;

    

    public void StartPressed()
    {
        LevelLoader.Instance.LoadScene("02_GameScene");
    }

    public void OptionsPressed()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        UpdateMuteButton();
    }

    private void UpdateMuteButton()
    {
        var muteButtonText = OptionsMenu.transform.Find("MuteButton").GetComponentInChildren<TextMeshProUGUI>();
        if (muteButtonText)
        {
            if (GetMuteAudioFlag())
            {
                muteButtonText.text = "Unmute audio";
            }
            else
            {
                muteButtonText.text = "Mute audio";
            }
        }
        else
        {
            Debug.LogWarning("Toggle button not found, check:", this);
        }
    }

    public void OptionsBackPressed()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void CreditsPressed()
    {
        MainMenu.SetActive(false);
        CreditsView.SetActive(true);
    }

    public void CreditsBackPressed()
    {
        MainMenu.SetActive(true);
        CreditsView.SetActive(false);
    }

    public void MusicVolumeControl(float vol)
    {
        Debug.Log("vol is: " + vol);
    }

    public void SFXVolumeControl(System.Single vol)
    {
        Debug.Log("sfx vol is: " + vol);
    }

    public void QuitGame()
    {
        Utils.QuitGame();
    }

    public void OpenCodevemberOrg()
    {
        Application.OpenURL("https://codevember.org/");
    }

    public void OpenOtherProjects()
    {
        Application.OpenURL("https://codevember.org/projects");
    }

    public void ToggleMuteAudioFlag()
    {
        SetMuteAudioFlag(!GetMuteAudioFlag());
    }

    public void SetMuteAudioFlag(bool active)
    {
        Debug.Log("Set audio mute flag:" + active);
        PlayerPrefs.SetInt(AudioManager.PlayerPrefsMuteAudio, (active) ? 1 : 0);
        PlayerPrefs.Save();
        UpdateMuteButton();
    }

    public bool GetMuteAudioFlag()
    {
        var flag = PlayerPrefs.GetInt(AudioManager.PlayerPrefsMuteAudio);
        return flag == 1;
    }

}
