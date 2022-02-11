using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("yo");
        if (other.gameObject.CompareTag("Enemie"))
        {
            PlayerManager.instance.Damage(EnemiesManager.instance.FindEnemie(other.gameObject).damage);
        }

        if (other.gameObject.CompareTag("Gun") || other.gameObject.CompareTag("LaserGun"))
        {
            GunManager.instance.ChangeGun(other.gameObject.tag);
            Pooler.instance.DePop(other.gameObject.tag,other.gameObject);
        }
    }
}
