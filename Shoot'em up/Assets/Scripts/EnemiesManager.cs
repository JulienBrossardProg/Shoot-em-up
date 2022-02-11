using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesManager : MonoBehaviour
{
    private List<Enemies> enemies;
    [SerializeField] private List<GameObject> ships;
    public static EnemiesManager instance;
    [SerializeField] private int randomShip;
    [SerializeField] private GameObject cam;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enemies = new List<Enemies>();
        ships = new List<GameObject>();
    }

    private void Update()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        if (Random.Range(0,300)==0)
        {
            randomShip = Random.Range(0, 2);
            if (randomShip==0)
            {
                enemies.Add(new Astra());
                ships.Add(Pooler.instance.Pop(enemies[enemies.Count-1].name));
                ships[ships.Count-1].transform.position = new Vector3(Random.Range(-8,9), cam.transform.position.y+6, 0);
            }
            else
            {
                enemies.Add(new Shmup());
                ships.Add(Pooler.instance.Pop(enemies[enemies.Count-1].name));
                ships[ships.Count-1].transform.position = new Vector3(Random.Range(-8,9), cam.transform.position.y+6, 0);
            } 
        }
    }

    public void Damage(GameObject go)
    {
        FindEnemie(go).currentHealth--;
        if (FindEnemie(go).currentHealth<1)
        {
            if (FindEnemie(go).name == "Shmup")
            {
                Pooler.instance.Pop(GunManager.instance.guns[Random.Range(0, 2)]).transform.position = go.transform.position;
            }

            ScoreManager.instance.score += FindEnemie(go).score;
            Pooler.instance.DePop(FindEnemie(go).name, go);
        }
    }

    public Enemies FindEnemie(GameObject go)
    {
        for (int i = 0; i < ships.Count; i++)
        {
            if (go.GetInstanceID()==ships[i].GetInstanceID())
            {
                return enemies[i];
            }
        }

        return null;
    }
    
}
