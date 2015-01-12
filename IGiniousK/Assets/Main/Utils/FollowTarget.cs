using System;
using UnityEngine;

    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);
        public FollowType type = FollowType.full;
        private bool isAnim = false;

        void Awake()
        {
        }

        private void LateUpdate()
        {

        }

        private void FullFollow()
        {
            transform.position = target.position + offset;
        }

        private void XZFollow()
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);// + offset;
        }

    }

public enum FollowType
{
    full,
    xy,
}
