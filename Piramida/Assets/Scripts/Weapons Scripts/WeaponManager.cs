using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour{
    [SerializeField]
    private WeaponHandler[] weapons;

    private int current_Weapon_Index;

    private void Start() {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);

    }

    private void Update() {
        if (!PauzaSkripta.isPaused){
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            TurnOnSelectedWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            TurnOnSelectedWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            TurnOnSelectedWeapon(3);
        }
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex) {
        if (current_Weapon_Index == weaponIndex)
            return;

        weapons[current_Weapon_Index].gameObject.SetActive(false);

        weapons[weaponIndex].gameObject.SetActive(true);

        current_Weapon_Index = weaponIndex;
    }

    public WeaponHandler GetCurrentSelectedWeapon() {
        return weapons[current_Weapon_Index];
    }
}
