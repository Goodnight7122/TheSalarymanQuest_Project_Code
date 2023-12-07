using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public DoorController door1;
    public DoorController fence1;
    public DoorController fence2;


    public float eyeDistance = 5.0f;
    private Ray ray;
    private RaycastHit hitData;
    public TextMeshProUGUI infoText;


    public AudioSource sourcedoor1;
    public AudioSource sourcefence1;
    public AudioSource sourcefence2;

    public GameObject MapMenu;

    void Start()
    {
        infoText.gameObject.SetActive(false);
        MapMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Code OpenMap

        if (Input.GetKey(KeyCode.Tab))
        {
            OpenMap();
        }
        else CloseMap();


        //Code Opendoor

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);

        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "door1":
                    infoText.text = "Press F to open/close the door";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door1.control();
                        sourcedoor1.Play();
                    }
                    break;

                case "fence1":
                    infoText.text = "Press F to open/close the door";
                    infoText.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        fence1.control();
                        sourcefence1.Play();
                    }
                    break;
            }
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }
    }

    public void OpenMap()
    {
        MapMenu.gameObject.SetActive(true);
    }
    public void CloseMap()
    {
        MapMenu.gameObject.SetActive(false);
    }

}
