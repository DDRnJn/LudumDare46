using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsMenuController : MonoBehaviour
{

    public Button menuButton;

    void Start()
    {
        Button button = this.menuButton.GetComponent<Button>();
        button.onClick.AddListener(LoadMainMenu);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
