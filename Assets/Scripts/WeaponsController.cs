using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class WeaponsController : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Gun gun;

    private InputAction fire;
    private InputAction aim;
    private PlayerControls playerControls;
    
    private Vector3 defaultWeaponPosition;
    private bool aiming = false;
    // Awake is called FIRST, set up connections to other things here
    // so that they are available for everyone at start.
    private void Awake() {
        playerControls = new PlayerControls();
    }
    // Start is called before the first frame update
    private void Start()
    {
        defaultWeaponPosition = gun.transform.localPosition;
    }

    private void OnEnable()
    {
        InitializeControls();
    }


    private void InitializeControls()
    {
        fire = playerControls.Player.Fire;
        aim = playerControls.Player.Aim;
        fire.performed += _ => Fire();
        fire.Enable();
        aim.performed += _ => AimDownSights();
        aim.Enable();
    }

    private void Fire () 
    {
        gun.PullTrigger();
    }

    private void AimDownSights () {
        if (aiming)
        {
            gun.transform.localPosition = defaultWeaponPosition;
            aiming = false;
        }
        else
        {
            gun.transform.localPosition = aimTransform.localPosition;
            aiming = true;
        }
    }


    private void OnDisable()
    {
        fire.Disable();
        aim.Disable();
    }

}
