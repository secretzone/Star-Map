using UnityEngine;

namespace Behavior
{
    public class SimpleRotate : MonoBehaviour
    {
        public float speed = 0.1f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate( 0.0f, 0.0f,speed * Time.deltaTime, Space.Self);
        }
    }
}
