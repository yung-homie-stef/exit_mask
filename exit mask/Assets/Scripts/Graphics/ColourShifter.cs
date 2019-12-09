using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class ColourShifter : MonoBehaviour
    {
        public GameObject whiteCamera;

        private void OnTriggerEnter(Collider other)
        {
            // disable first overlayed camera so that player only sees game through black on white
            whiteCamera.SetActive(false);
            // interrupt theme of scene and play harsh noise insteads
            FindObjectOfType<audioManager>().Stop("theme_reversed");
            FindObjectOfType<audioManager>().Play("harsh_noise_wall");
        }
    }
}
