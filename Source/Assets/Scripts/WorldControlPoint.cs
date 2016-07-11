using UnityEngine;
using System.Collections;

public class WorldControlPoint : MonoBehaviour
{
    public static Vector3 Position1;
    public static Vector3 Position2;
    bool placing = false;

    void Start()
    {
        Position1 = new Vector3();
        Position2 = new Vector3();
    }

    void OnSelect()
    {
        placing = !placing;

        if (placing)
        {
            SpatialMapping.Instance.DrawVisualMeshes = true;
        }
        else
        {
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }
    }

    void Update()
    {
        if (placing)
        {
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                this.transform.position = hitInfo.point;
                if (this.gameObject.name == "WorldControlPoint1")
                    Position1 = this.transform.position;
                else
                    Position2 = this.transform.position;
            }
        }
    }
}
