using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class WeaponsController : MonoBehaviour
{
    private InputAction fire;
    private InputAction aim;
    private PlayerControls playerControls;
    [SerializeField] private Transform aimTransform;

    [SerializeField] private GameObject weapon;
    private Vector3 defaultWeaponPosition;
    private bool aiming = false;
    // Awake is called FIRST, set up connections to other things here
    // so that they are available for everyone at start.
    void Awake() {
        playerControls = new PlayerControls();
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultWeaponPosition = weapon.transform.localPosition;
    }

    private void OnEnable()
    {
        InitializeControls();
    }

    private void OnDisable()
    {
        fire.Disable();
        aim.Disable();
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

    void Fire () 
    {
        Debug.Log("Bang.");
    }

    void AimDownSights () {
        if (aiming)
        {
            weapon.transform.localPosition = defaultWeaponPosition;
            aiming = false;
        }
        else
        {
            weapon.transform.localPosition = aimTransform.localPosition;
            aiming = true;
        }
    }

}
