using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public Button startButton;

    public Button instructionsButton;
    // Start is called before the first frame update
    void Start()
    {
        Button button = this.startButton.GetComponent<Button>();
        button.onClick.AddListener(LoadLevel1);

        Button instructionsButton = this.instructionsButton.GetComponent<Button>();
        instructionsButton.onClick.AddListener(LoadInstructions);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
