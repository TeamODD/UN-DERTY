using UnityEngine;

namespace jjh
{
    public class TransformUtils
    {
        public static bool SmoothTickMove(Transform refTransform, Vector3 targetPosition, float speed)
        {
            Vector3 prevDiff = targetPosition - refTransform.position;

            float step = speed * Time.deltaTime;
            refTransform.position = Vector3.MoveTowards(refTransform.position, targetPosition, step);

            Vector3 diffVector = targetPosition - refTransform.position;
            float dist = diffVector.magnitude;
            if (dist < 0.1f || Vector3.Dot(diffVector, prevDiff) < 0)
            {
                refTransform.position = targetPosition;
                return true;
            }
            return false;
        }
    }
}