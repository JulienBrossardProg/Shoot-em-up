using UnityEngine;
using Random = UnityEngine.Random;

public class AstraController : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private float speed;

    private void Update()
    {
        Fire();
        transform.position += Vector3.down*speed*Time.deltaTime;
    }

    void Fire()
    {
        if (Random.Range(0,300)==0)
        {
            laser = Pooler.instance.Pop("AstraLaser");
            laser.transform.position = transform.position;
        }
    }
    
    
}
