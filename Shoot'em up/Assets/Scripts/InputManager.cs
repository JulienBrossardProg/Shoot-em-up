using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    private void Update()
    {
        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)
        {
            playerController.Movement(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
        
        if (Input.GetKeyDown("joystick button 0") && !Menu.instance.isMenu && GunManager.instance.isGun)
        {
            playerController.Fire();
        }
        
        if (Input.GetKey("joystick button 0") && !Menu.instance.isMenu && GunManager.instance.isLaserGun)
        {
            playerController.Fire();
        }

        if (Input.GetKeyDown("joystick button 0") && Menu.instance.isMenu)
        {
            Menu.instance.selectedButton.Select();
        }

        if (Input.GetKeyDown("joystick button 7") && !Menu.instance.isMenu)
        {
            Menu.instance.Pause();
        }
    }
}
