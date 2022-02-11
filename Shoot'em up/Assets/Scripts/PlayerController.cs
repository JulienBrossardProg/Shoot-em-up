using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject laser;

    public void Movement(float horizontal, float vertical)
    {

        if (transform.position.x>-8.1f && transform.position.x <8.1f)
        {
            transform.position +=  new Vector3(horizontal * speed*Time.deltaTime,  0 , 0);   
        }
        else
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, 0);
        }

        if (Mathf.Abs(transform.position.y-cam.position.y)<4.1f )
        {
            transform.position +=  new Vector3(0,  vertical*speed*Time.deltaTime , 0);  
        }

        else if(transform.position.y-cam.position.y<0)
        {
            transform.position = new Vector3(transform.position.x, cam.position.y-4, 0);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, cam.position.y+4, 0);
        }
    }

    public void Fire()
    {
        laser = Pooler.instance.Pop("Laser");
        laser.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        laser.transform.eulerAngles = Vector3.zero;
    }
}
