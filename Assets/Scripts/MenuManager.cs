using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField nameInputField;
    public Button startButton;
    public Text errorText;

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClick);
        }

        if (errorText != null)
        {
            errorText.gameObject.SetActive(false);
        }

        if (nameInputField != null)
        {
            nameInputField.onValueChanged.AddListener(OnNameValueChanged);
        }
    }

    void OnNameValueChanged(string value)
    {
        if (errorText != null && errorText.gameObject.activeSelf)
        {
            errorText.gameObject.SetActive(false);
        }
    }

    void OnStartButtonClick()
    {
        if (nameInputField == null || string.IsNullOrWhiteSpace(nameInputField.text))
        {
            if (errorText != null)
            {
                errorText.text = "Please enter your name!";
                errorText.gameObject.SetActive(true);
            }
            return;
        }

        string playerName = nameInputField.text.Trim();
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerName = playerName;
        }

        SceneManager.LoadScene("main");
    }
}