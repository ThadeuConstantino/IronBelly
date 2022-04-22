using IronBelly.Enemy;
using IronBelly.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler weaponHandler;

    private float fireRate = 15f;

    private Animator zoomCameraAnim;

    private Camera mainCam;

    private GameObject crosshair;

    void Awake()
    {
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT)
                                  .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        mainCam = Camera.main;
    }

    void Update()
    {
        WeaponShoot();
        ZoomInOut();
    }

    void WeaponShoot()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            weaponHandler.ShootAnimation();
            BulletFired();
        }
    }

    void ZoomInOut()
    {
        if (Input.GetMouseButtonDown(1))
            zoomCameraAnim.Play(AnimationTags.ZOOM_IN);

        if (Input.GetMouseButtonUp(1))
            zoomCameraAnim.Play(AnimationTags.ZOOM_OUT);
    }

    void BulletFired()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.tag == Tags.ENEMY)
                hit.transform.GetComponent<EnemyCube>().Hit();
            
        }
    }
}































