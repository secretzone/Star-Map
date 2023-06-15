using UnityEngine;

namespace UI
{
    public class SolarSystemUI : MonoBehaviour
    {

        public Camera solarSystemCamera;
        public GameObject canvas;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Enabled(bool enabled)
        {
            solarSystemCamera.gameObject.SetActive(enabled);
            canvas.SetActive(enabled);
        }
    }
}
