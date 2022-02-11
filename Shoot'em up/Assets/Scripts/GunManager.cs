using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{
    delegate void Guns();
    private Guns currentGunDelegate;
    public string[] guns;
    public static GunManager instance;
    [SerializeField] private Image gun;
    [SerializeField] private Image laserGun;
    public bool isGun;
    public bool isLaserGun;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        guns = new string[2];
        guns[0] = "Gun";
        guns[1] = "LaserGun";
    }

    void LaserGun()
    {
        laserGun.gameObject.SetActive(true);
        gun.gameObject.SetActive(false);
        isLaserGun = true;
        isGun = false;
    }

    void Gun()
    {
        gun.gameObject.SetActive(true);
        laserGun.gameObject.SetActive(false);
        isLaserGun = false;
        isGun = true;
    }

    public void ChangeGun(string tag)
    {
        if (tag == "Gun")
        {
            currentGunDelegate = Gun;
        }
        else if(tag == "LaserGun")
        {
            currentGunDelegate = LaserGun;
        }
        currentGunDelegate.Invoke();
    }
}
