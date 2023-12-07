using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NavKeypad
{
    public class Opendoor : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        public bool IsClosed => IsClosed;
        private bool isOpen = false;
        public AudioSource sourcefence2;

        public void ToggleDoor()
        {
            isOpen = !isOpen;
            anim.SetBool("isClosed", isOpen);
        }

        public void OpenDoor()
        {
            isOpen = true;
            anim.SetBool("isClosed", isOpen);
            sourcefence2.Play();
        }
        public void CloseDoor()
        {
            isOpen = false;
            anim.SetBool("isClosed", isOpen);
        }
    }
}