using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class ColourShifter : MonoBehaviour
    {
        public GameObject whiteCamera;
        public GameObject staticCanvas;

        private bool staticActive = false;
        private float staticTimer = 19.5f;

        private void Update()
        {
            if (staticActive)
            {
                staticTimer -= Time.deltaTime;
                staticCanvas.SetActive(true);
            }

            if (staticTimer <= 0)
            {
                staticTimer = 0;
                staticCanvas.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // disable first overlayed camera so that player only sees game through black on white
            whiteCamera.SetActive(false);
            // interrupt theme of scene and play harsh noise insteads
           audioManager.instance.Stop("theme_reversed");
           audioManager.instance.Play("harsh_noise_wall");
            staticActive = true;
        }
    }
}
