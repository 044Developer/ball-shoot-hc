using UnityEngine;

namespace BallShoot.Tools.ObstaclePositionDrawer
{
    public class ObstaclePositionDrawerHandler : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private GameObject _firstPos;
        [SerializeField] private GameObject _secondPos;
        [SerializeField] private GameObject _thirdPos;
        [SerializeField] private GameObject _fourthPos;

        [SerializeField] private float _gizmoheight;

        void OnDrawGizmos()
        {
            if (_firstPos != null && _secondPos != null && _thirdPos != null && _fourthPos != null)
            {
                DrawBoxGizmo(
                    _firstPos.transform.position,
                    _secondPos.transform.position,
                    _thirdPos.transform.position,
                    _fourthPos.transform.position,
                    _gizmoheight
                    );
            }
        }

        void DrawBoxGizmo(Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4, float height)
        {
            Gizmos.color = Color.green;

            // Draw the base of the cube
            Gizmos.DrawLine(point1, point2);
            Gizmos.DrawLine(point2, point3);
            Gizmos.DrawLine(point3, point4);
            Gizmos.DrawLine(point4, point1);

            // Calculate the top corners of the cube
            Vector3 point5 = new Vector3(point1.x, point1.y + height, point1.z);
            Vector3 point6 = new Vector3(point2.x, point2.y + height, point2.z);
            Vector3 point7 = new Vector3(point3.x, point3.y + height, point3.z);
            Vector3 point8 = new Vector3(point4.x, point4.y + height, point4.z);

            // Draw the top of the cube
            Gizmos.DrawLine(point5, point6);
            Gizmos.DrawLine(point6, point7);
            Gizmos.DrawLine(point7, point8);
            Gizmos.DrawLine(point8, point5);

            // Connect the base and top of the cube
            Gizmos.DrawLine(point1, point5);
            Gizmos.DrawLine(point2, point6);
            Gizmos.DrawLine(point3, point7);
            Gizmos.DrawLine(point4, point8);
        }
#endif
    }
}