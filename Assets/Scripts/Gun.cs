using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float range = 100f;
    public void Shoot()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            Debug.DrawRay(fpsCam.transform.position, hit.point - fpsCam.transform.position, Color.red, 3f);
        }
    }

    public void PullTrigger()
    {

    }
}
