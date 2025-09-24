using UnityEngine;

namespace jjh
{
    public class ForceEntity
    {
        public ForceEntity(Vector3 start, Vector3 finish)
        {
            forceStartPoint = start;
            forceFinishPoint = finish;
            forceDiff = forceFinishPoint - forceStartPoint;
            forceDirection = forceDiff.normalized;
        }

        public Vector3 StartPoint => forceStartPoint;
        public Vector3 FinishPoint => forceFinishPoint;
        public Vector3 Direction => forceDirection;
        public Vector3 ForceDiff => forceDiff;
        public float Distance => forceDiff.magnitude;

        private Vector3 forceStartPoint;
        private Vector3 forceFinishPoint;
        private Vector3 forceDirection;
        private Vector3 forceDiff;
    }
}

