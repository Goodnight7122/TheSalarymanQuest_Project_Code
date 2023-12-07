using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour
{
    public float eyeDistance = 5.0f;
    private Ray ray;
    private RaycastHit hitData;

    public TextMeshProUGUI infoText;
    public AudioSource PickupPaper;


    public TextMeshProUGUI Note1Code;
    public TextMeshProUGUI Note2Code;
    public TextMeshProUGUI Note3Code;
    public TextMeshProUGUI Note4Code;
    public TextMeshProUGUI Note5Code;

    public GameObject Player;
    public GameObject Note1;
    public GameObject NoteOB1;

    public GameObject Note2;
    public GameObject NoteOB2;

    public GameObject Note3;
    public GameObject NoteOB3;

    public GameObject Note4;
    public GameObject NoteOB4;

    public GameObject Note5;
    public GameObject NoteOB5;

    void Start()
    {
        Note1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);

        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "Note1":
                    infoText.text = "Press F to ReadNote#1";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Note1.gameObject.SetActive(true);
                        PickupPaper.Play();
                        Player.GetComponent<FirstPersonController>().enabled = false;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        Note1Code.gameObject.SetActive(true);
                        NoteOB1.gameObject.SetActive(false);
                    }
                    break;

                case "Note2":
                    infoText.text = "Press F to ReadNote#2";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Note2.gameObject.SetActive(true);
                        PickupPaper.Play();
                        Player.GetComponent<FirstPersonController>().enabled = false;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        Note2Code.gameObject.SetActive(true);
                        NoteOB2.gameObject.SetActive(false);
                    }
                    break;

                case "Note3":
                    infoText.text = "Press F to ReadNote#3";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Note3.gameObject.SetActive(true);
                        PickupPaper.Play();
                        Player.GetComponent<FirstPersonController>().enabled = false;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        Note3Code.gameObject.SetActive(true);
                        NoteOB3.gameObject.SetActive(false);
                    }
                    break;

                case "Note4":
                    infoText.text = "Press F to ReadNote#4";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Note4.gameObject.SetActive(true);
                        PickupPaper.Play();
                        Player.GetComponent<FirstPersonController>().enabled = false;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        Note4Code.gameObject.SetActive(true);
                        NoteOB4.gameObject.SetActive(false);
                    }
                    break;

                case "Note5":
                    infoText.text = "Press F to ReadNote#5";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Note5.gameObject.SetActive(true);
                        PickupPaper.Play();
                        Player.GetComponent<FirstPersonController>().enabled = false;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        Note5Code.gameObject.SetActive(true);
                        NoteOB5.gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }

    public void ExitButton()
    {
        Note1.gameObject.SetActive(false);
        Note2.gameObject.SetActive(false);
        Note3.gameObject.SetActive(false);
        Note4.gameObject.SetActive(false);
        Note5.gameObject.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
