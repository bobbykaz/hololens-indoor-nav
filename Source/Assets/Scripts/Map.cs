using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public static Vector3 Control1;
    public static Vector3 Control2;
    public static Map Instance;
    private MeshRenderer meshRenderer;
    private bool firstControlPoint = true;
    public bool Follow = false;

    private GameObject ControlPoint1;
    private GameObject ControlPoint2;

    void Start()
    {
        Instance = this;
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        meshRenderer.enabled = true;
        Control1 = new Vector3();
        Control2 = new Vector3();
    }

    private void OnSelect()
    {
        ControlPoint1 = GameObject.Find("MapControl1");
        ControlPoint2 = GameObject.Find("MapControl2");

        GameObject gameObj = null;

        if (firstControlPoint)
            gameObj = ControlPoint1;
        else
            gameObj = ControlPoint2;

        if (gameObj != null)
            gameObj.transform.position = WorldCursor.Instance.HitInfo.point;

        if (ControlPoint1 != null)
            Control1 = ControlPoint1.transform.position;

        if (ControlPoint2 != null)
            Control2 = ControlPoint2.transform.position;

        firstControlPoint = !firstControlPoint;
    }

    void Update ()
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

        if (ControlPoint1 != null)
            Control1 = ControlPoint1.transform.position;

        if (ControlPoint2 != null)
            Control2 = ControlPoint2.transform.position;
    }
}
