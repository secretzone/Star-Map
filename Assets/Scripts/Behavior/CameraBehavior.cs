using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Behavior
{
    public class CameraBehavior : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _initialPosition;

        private Camera _camera;
        private bool _inProgress = false;
        public float zoomMax;
        public float zoomMin;
        public float zoomSpeed = 10;
        public float zoomPerScroll = 50;

        private float zoom ;
        Vector3 newPosition;

        // Start is called before the first frame update
        void Start()
        {
            _camera = GetComponent<Camera>();
            _initialPosition = transform.position;//_camera.WorldToScreenPoint(transform.position);
            zoomMax = _camera.orthographicSize;
            zoom = zoomMax;
        }
    

        public void ResetPosition()
        {
            transform.position = _initialPosition;
            _camera.orthographicSize = zoomMax;
        }

        // public void ZoomInToStar(Star star)
        // {
        //     Debug.Log("Zooming in");
        //     transform.position = star.transform.position;
        //     _camera.orthographicSize = zoomMax;
        // }

        // public void ZoomOutToMap()
        // {
        //     Debug.Log("Zooming out");
        //     ResetPosition();
        //     _camera.orthographicSize = zoomMax;
        // }

        private IEnumerator ChangeOrtho(float targetZoom)
        {
            if (_inProgress)
            {
                yield return null;
            }
            _inProgress = true;
        
            while (!Mathf.Approximately(targetZoom, _camera.orthographicSize))
            {
                // targetZoom -= Input.mouseScrollDelta.y * sensitivity;
                targetZoom = Mathf.Clamp(targetZoom, zoomMin, zoomMax);
                float newSize = Mathf.MoveTowards(_camera.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
                _camera.orthographicSize = newSize;
                yield break;
            }
            _inProgress = false;
        }


        void ProcessCameraZoom()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > zoomMin)
            {
                newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                zoom -= zoomSpeed;
                Camera.main.orthographicSize = zoom;
                
                transform.position = newPosition; //Vector3.Lerp(transform.position, newPosition, 0.1F);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < zoomMax)
            {
                zoom += zoomSpeed;
                Camera.main.orthographicSize = zoom;
                transform.position = _initialPosition;
            }
        }

        // Update is called once per frame
        void Update()
        {
            ProcessCameraZoom();
        }
    }
}
