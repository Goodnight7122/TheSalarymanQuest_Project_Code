using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public GameObject WinMenu;
    public GameObject Player;
    public GameObject Timer;
    public AudioSource WaterSound;
    void Start()
    {
        WinMenu.gameObject.SetActive(false);
        WaterSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SpecialKT")
        {
            GameWin();
            WaterSound.PlayOneShot(WaterSound.clip, 1.0F);
            Timer.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<FirstPersonController>().enabled = false;
        }
    }

    public void GameWin()
    {
        WinMenu.gameObject.SetActive(true);
    }
}
