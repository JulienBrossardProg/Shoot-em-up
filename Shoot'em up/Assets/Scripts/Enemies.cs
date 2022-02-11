using UnityEngine;

public class Enemies
{
    public int damage;
    public string name;
    public int maxHealth;
    public int currentHealth;
    public int score;

    public Enemies()
    {
        damage = 10;
        name = "Starship";
        maxHealth = 1;
        currentHealth = maxHealth;
        score = 10;
    }
}
