using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class WeaponsController : MonoBehaviour
{
    private InputAction _Primary;
    private InputAction _Secondary;
    private PlayerInput _input;

    [SerializeField] private GameObject _weapon;
    // Awake is called FIRST, set up connections to other things here
    // so that they are available for everyone at start.
    void Awake() {
        _input = GetComponent<PlayerInput>();
    }
    // Start is called before the first frame update
    void Start() {
        _Primary = _input.actions["Primary"];
        _Secondary = _input.actions["Secondary"];
        _Primary.performed += _ => OnPrimary();
        _Primary.Enable();
        _Secondary.performed += _ => OnSecondary();
        _Secondary.Enable();
    }

    // Update is called once per frame
    void Update() {
    }

    void OnPrimary () {
        Debug.Log("FUCK");
    }

    void OnSecondary () {
        _weapon.transform.Translate(new Vector3(-0.2f,0,0));
    }

}
