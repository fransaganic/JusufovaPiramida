using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour{

    public static bool pritisniZaInfo = false;

    [SerializeField]
    GameObject textPritisniZaInfo;

    bool pritisnuto = true;

    [SerializeField]
    GameObject infoText;

    [SerializeField]
    GameObject crossHair;

    private void Update() {
        if (pritisniZaInfo) {
            textPritisniZaInfo.SetActive(true);
        } else {
            textPritisniZaInfo.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            Pressed();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            pritisnuto = false;
            Pressed();
        }
    }

    void Pressed() {
        pritisniZaInfo = false;
        if (pritisnuto) {
            PrikaziInformacije();
            pritisnuto = !pritisnuto;
        } else {
            izlazIzPrikazaInformacija();
            pritisnuto = !pritisnuto;
        }
    }

    public void PrikaziInformacije() {
        infoText.SetActive(true);
        crossHair.SetActive(false);
    }

    public void izlazIzPrikazaInformacija() {
        infoText.SetActive(false);
        crossHair.SetActive(true);
    }
}
