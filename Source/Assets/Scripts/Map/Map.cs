using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public Map Instance;
    public static Vector3 Control1;
    public static Vector3 Control2;

    private bool firstControlPoint;

    private GameObject ControlPoint1;
    private GameObject ControlPoint2;

    void Start()
    {
        Instance = this;
        firstControlPoint = true;
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

    void Update()
    {
        if (ControlPoint1 != null)
            Control1 = ControlPoint1.transform.position;

        if (ControlPoint2 != null)
            Control2 = ControlPoint2.transform.position;
    }
}
