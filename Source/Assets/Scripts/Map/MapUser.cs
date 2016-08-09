using UnityEngine;
using System.Collections;

public class MapUser : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        var worldRay = WorldControlPoint.Position2 - WorldControlPoint.Position1;
        var mapRay = Map.Control2 - Map.Control1;

        var headPos = Camera.main.transform.position;
        headPos.y = WorldControlPoint.Position1.y;

        var userRay = (headPos - WorldControlPoint.Position1);

        var rotationTransfer = Quaternion.FromToRotation(worldRay.normalized, mapRay.normalized);

        var mapUserDist = (rotationTransfer * userRay) * mapRay.magnitude  / worldRay.magnitude;

        this.gameObject.transform.position = (Map.Control1 + mapUserDist);
    }
}
