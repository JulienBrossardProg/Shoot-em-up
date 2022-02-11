using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieLaser : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isStart = true;
    [SerializeField] private GameObject ship;

    private void Start()
    {
        StartCoroutine("DePop");
    }

    void Update()
    {
        Movement();
        StartCoroutine("DePop");
    }

    void Movement()
    {
        transform.position += Vector3.up*speed*Time.deltaTime;
    }

    IEnumerator DePop()
    {
        yield return new WaitForSeconds(2);
        Pooler.instance.DePop("Laser",gameObject);
        isStart = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemie") && isStart)
        {
            ship = other.gameObject;
            isStart = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.Damage(EnemiesManager.instance.FindEnemie(ship).damage);
            Pooler.instance.DePop(gameObject.tag,gameObject);
            isStart = true;
        }
    }
}
