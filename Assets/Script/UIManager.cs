using UnityEngine;
using System.Collections;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private CanvasGroup uiPanel;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float fadeDuration = 1.0f;

    private void OnEnable()
    {
        gameManager.OnStateChanged += UpdateUI;
    }

    private void OnDisable()
    {
        gameManager.OnStateChanged -= UpdateUI;
    }

    private void UpdateUI(GameManager.GameState newState)
    {
        string newText = GetTextForState(newState);
        UpdateText(newText);
        FadeInPanel();
    }

    private string GetTextForState(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.Intro:
                return "Welcome onboard! We'll guide you through the steps to wear a lifejacket safely.";
            case GameManager.GameState.LocateLifeJacket:
                return "First, please locate your life jacket under the seat.";
            case GameManager.GameState.WearLifeJacket:
                return "Great! Please put on your life jacket.";
            case GameManager.GameState.SecureBuckle:
                return "Next, please secure the buckle.";
            case GameManager.GameState.Inflate:
                return "Please pull the red toggle to inflate the lifejacket. \n Remember only do it when you exit the aircraft!";
            case GameManager.GameState.Completed:
                return "Amazing! \n You now know how to wear and use a lifejacket safely!";
            default:
                return "Unknown step.";
        }
    }

    private void UpdateText(string text)
    {
        infoText.text = text;
    }

    private void FadeInPanel()
    {
        StartCoroutine(DoFadeIn());
    }

    private IEnumerator DoFadeIn()
    {
        float currentTime = 0.0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            uiPanel.alpha = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            yield return null;
        }
        
        uiPanel.alpha = 1;
    }
}