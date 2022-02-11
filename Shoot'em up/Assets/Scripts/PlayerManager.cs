using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public static PlayerManager instance;
    [SerializeField] private bool isInvicible;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Image playerHealthBar;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.fillAmount = currentHealth / maxHealth;
    }

    public void Damage(int damage)
    {
        if (!isInvicible)
        {
            if (currentHealth-damage<=0)
            {
                currentHealth = 0;
                GameManager.instance.GameOver();
            }

            else
            {
                currentHealth -= damage;
            }

            playerHealthBar.fillAmount = currentHealth / maxHealth;
            StartCoroutine(Invincible());
        }
    }

    IEnumerator Invincible()
    {
        isInvicible = true;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        isInvicible = false;
    }
}
