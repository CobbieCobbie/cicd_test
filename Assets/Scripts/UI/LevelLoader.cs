using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// A simple level loader, which is mainly based on brackeys level transition tutorial.
/// 
/// See https://www.youtube.com/watch?v=CE9VOZivb3I
/// For the async part, watch https://www.youtube.com/watch?v=YMj2qPq9CP8
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public class LevelLoader : AutoCleanupSingleton<LevelLoader>
{
    [Header("Transition settings")]
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    [Header("Linked objects")]
    public GameObject loadingScreen;
    public TextMeshProUGUI loadingText;
    public Button proceedButton;
    public TextMeshProUGUI proceedButtonText;

    private AsyncOperation operation;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void LoadScene(string levelName)
    {
        StartCoroutine(LoadLevelAsynchronously(levelName));
    }

    private IEnumerator LoadLevelAsynchronously(string levelName)
    {

        // Start transition
        transitionAnimator.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);
        loadingScreen.SetActive(true);

        // Load new scene
        operation = SceneManager.LoadSceneAsync(levelName);
        operation.allowSceneActivation = false;

        /* Use this code for a progress based approach
        while(operation.isDone == false) */
        while(operation.progress != 0.9f)
        {
            var progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Loading progress: " + progress);
            yield return null; // ...wait for one frame
        }
        // ...and wait at least a bit ;)
        yield return new WaitForSecondsRealtime(0.5f); 
        proceedButton.interactable = true;
        proceedButtonText.text = "> Click to proceed...";
    }

    public void ProceedButtonPressed()
    {
        operation.allowSceneActivation = true;
    }
}
