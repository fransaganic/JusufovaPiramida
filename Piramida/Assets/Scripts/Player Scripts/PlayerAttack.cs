using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

    private WeaponManager weapon_Manager;
    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    private bool is_Aiming;


    float timePassed;

    private void Awake() {
        weapon_Manager= GetComponent<WeaponManager>();
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT)
            .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        timePassed = 0;
        mainCam = Camera.main;
    }

    private void Start() {
        
    }

    private void Update() {
        if (!PauzaSkripta.isPaused){
        ZoomInAndOut();
        WeaponShoot();
        timePassed += Time.deltaTime;
        }
    }
    void WeaponShoot() {
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE) {
            //different from GetMouseButtonDown
            //here is when we are holding mouse button
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire && timePassed > 0.3) {
                timePassed = 0;
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                BulletFired();
            }
            //if we have regular weapon that shoots once
        } else {
            if (Input.GetMouseButtonDown(0)) {
                //handle axe
                if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG ) {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                //handle shoot
                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET && timePassed > 2) {
                    timePassed = 0;
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                    BulletFired();
                }
            }
        }
    }

    void ZoomInAndOut() {
        //we are going to AIM
        if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.AIM) {
            if (Input.GetMouseButtonDown(1)) {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crosshair.SetActive(false);
            }
            //release mouse button zoom out
            if (Input.GetMouseButtonUp(1)) {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crosshair.SetActive(true);
            }
        }

        if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.SELF_AIM) {
            if (Input.GetMouseButtonDown(1)) {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(true);
                is_Aiming = true;
            }

            if (Input.GetMouseButtonUp(1)) {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(false);
                is_Aiming = false;
            }
        }
    }

    void BulletFired() {
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 2)) {
            print("We hit: " + hit.transform.gameObject.name);
            if(hit.transform.gameObject.tag == "Dragon" ){
                //transform.parent = hit.transform.gameObject.transform;
                hit.transform.gameObject.GetComponent<DragonScript>().TakeDamage(10);           }
        }
    }
}
