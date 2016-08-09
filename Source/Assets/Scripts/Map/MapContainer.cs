using UnityEngine;
using System.Collections;

public class MapContainer : MonoBehaviour {
    public static MapContainer Instance;
    private MeshRenderer meshRenderer;
    public bool Follow = false;
    public bool FloorProject = false;
    private Quaternion floorProjectionRotation;
    private float floorProjectionScale;
    private Vector3 oldScale;

    void Start()
    {
        Instance = this;
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        meshRenderer.enabled = true;
        oldScale = this.transform.parent.localScale;
    }

    void Update()
    {
        if (Follow)
        {
            var headPos = Camera.main.transform.position;
            var gazeDir = Vector3.Normalize(Camera.main.transform.forward);

            this.transform.position = Vector3.Lerp(this.transform.position, (headPos + gazeDir), 0.05f);
            this.transform.position = new Vector3(this.transform.position.x, -0.3f, this.transform.position.z);
            gazeDir.y = 0;
            this.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(gazeDir), Vector3.up);
        }
        else if (FloorProject)
        {
            this.transform.rotation = floorProjectionRotation;
            this.transform.localScale = this.transform.localScale * floorProjectionScale;
        }
    }

    public void SetFloorProjection()
    {
        if (!FloorProject)
        {
            Vector3 control = Map.Control2 - Map.Control1;
            Vector3 worldControl = WorldControlPoint.Position2 - WorldControlPoint.Position2;
            floorProjectionRotation = Quaternion.FromToRotation(control, worldControl);
            floorProjectionScale = worldControl.magnitude / control.magnitude;
        }
        Follow = false;
        FloorProject = !FloorProject;
    }
}
