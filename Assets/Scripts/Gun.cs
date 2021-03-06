using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VaudinGames.Audio;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Animator animator;
    [SerializeField] float range = 100f;
    [SerializeField] int maxAmmo = 17;
    [SerializeField] Logger logger;
    private RandomAudioPlayer randomAudioPlayer;
    private int currentAmmo;
    private bool hasAmmo = true;

    private void Awake()
    {
        randomAudioPlayer = GetComponent<RandomAudioPlayer>();
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        hasAmmo = true;
    }

    public void Shoot()
    {
        animator.Play("Shoot");
        

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
        {
            logger.Log(this, $"Raycast hit {hit.transform.name}.");
            Debug.DrawRay(cam.transform.position, hit.point - cam.transform.position, Color.red, 3f);
        }

        SpendAmmo();
    }

    public void Cock()
    {
        animator.Play("Cock");
    }

    private void SpendAmmo()
    {
        currentAmmo--;
        logger.Log(this, $"Ammo spent. New ammo count: {currentAmmo}.");
        hasAmmo = currentAmmo > 0;
    }

    public void PullTrigger()
    {
        if (!hasAmmo) 
        {
            logger.Log(this, "Tried pulling trigger, but out of ammo!");
            return; 
        }
        Shoot();
    }
}
