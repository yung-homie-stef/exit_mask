using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class ColourShifter : MonoBehaviour
    {
        public GameObject whiteCamera;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            whiteCamera.SetActive(false);
        }
    }
}
