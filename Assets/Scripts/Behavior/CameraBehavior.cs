using System.Collections;
using UnityEngine;

namespace Behavior
{
    public class CameraBehavior : MonoBehaviour
    {
        private Vector3 _initialPosition;

        private Camera _camera;
        private bool _inProgress = false;
        public float zoomedInSize;
        public float zoomedOutSize;
        public float zoomSpeed = 10;


        // Start is called before the first frame update
        void Start()
        {
            _camera = GetComponent<Camera>();
            _initialPosition = _camera.WorldToScreenPoint(transform.position);
        }
    

        public void ResetPosition()
        {
            transform.position = _initialPosition;
        }

        // public void ZoomInToStar(Star star)
        // {
        //     Debug.Log("Zooming in");
        //     transform.position = star.transform.position;
        //     _camera.orthographicSize = zoomedInSize;
        // }

        // public void ZoomOutToMap()
        // {
        //     Debug.Log("Zooming out");
        //     ResetPosition();
        //     _camera.orthographicSize = zoomedOutSize;
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
                targetZoom = Mathf.Clamp(targetZoom, zoomedInSize, zoomedOutSize);
                float newSize = Mathf.MoveTowards(_camera.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
                _camera.orthographicSize = newSize;
                yield break;
            }
            _inProgress = false;
        }


        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
