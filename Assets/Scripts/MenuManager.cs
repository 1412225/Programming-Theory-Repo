using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.IO;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string playerName { get; private set; } // ENCAPSULATION
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TextMeshProUGUI nameError;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        if (nameField.text != string.Empty)
        {
            playerName = nameField.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            nameError.enabled = true;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
