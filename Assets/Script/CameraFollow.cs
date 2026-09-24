using UnityEngine;

namespace Script
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 8f, -7f);
        // Start is called before the first frame update
        void Start()
        {
            transform.position = target.position + offset;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}
