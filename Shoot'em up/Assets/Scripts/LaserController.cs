using System;
using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float speed;

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
        yield return new WaitForSeconds(1);
        Pooler.instance.DePop("Laser",gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemie"))
        {
            EnemiesManager.instance.Damage(other.gameObject);
            Pooler.instance.DePop("Laser",gameObject);
        }
    }
}
