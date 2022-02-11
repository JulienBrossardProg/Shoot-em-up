using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    [SerializeField] private Button resetLevel;
    [SerializeField] private Button quit;
    [SerializeField] private Button continueGame;
    public Button selectedButton;
    public bool isMenu;
    [SerializeField] private Color selectedColor;

    private void Awake()
    {
        instance = this;
        EventSystem.current.firstSelectedGameObject = resetLevel.gameObject;
    }
    

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == resetLevel.gameObject)
        {
            selectedButton = resetLevel;
            selectedButton.image.color = selectedColor;
            continueGame.image.color = Color.white;
            quit.image.color = Color.white;
        }
        else if(EventSystem.current.currentSelectedGameObject == continueGame.gameObject)
        {
            selectedButton = continueGame;
            selectedButton.image.color = selectedColor;
            resetLevel.image.color = Color.white;
            quit.image.color = Color.white;
        }
        else
        {
            selectedButton = quit;
            selectedButton.image.color = selectedColor;
            continueGame.image.color = Color.white;
            resetLevel.image.color = Color.white;
        }
        
    }

    public void Pause()
    {
        isMenu = true;
        resetLevel.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        continueGame.gameObject.SetActive(true);
        //selectedButton = continueGame;
        Time.timeScale = 0;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("01");
        isMenu = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        isMenu = false;
    }
    
}
