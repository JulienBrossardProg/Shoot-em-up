using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject[] backgrounds;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        LoadBackground();
    }

    public void GameOver()
    {
        Menu.instance.Pause();
        resume.gameObject.SetActive(false);
        gameOver.SetActive(true);
    }

    void LoadBackground()
    {
        if (cam.position.y!=0)
        {
            if ((cam.position.y-1)%20 < 0.01f)
            {
                backgrounds[1].transform.position = new Vector3(0, backgrounds[0].transform.position.y+10, 1);
            }
            else if((cam.position.y-1)%10 < 0.01f)
            {
                backgrounds[0].transform.position = new Vector3(0, backgrounds[1].transform.position.y+10, 1);
            }
        }
    }
    
}
