using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public static ScoreManager instance;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
