using UnityEngine;
using System.Collections;

public class CylHelper : MonoBehaviour {
    public bool IsMap = true;
    public bool IsUser = false;

    public static bool DebugEnabled = false;

    private MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        meshRenderer.enabled = DebugEnabled;

        if (DebugEnabled)
        {
            if (IsMap)
            {
                this.gameObject.transform.position = Map.Control1;
                this.gameObject.transform.up = (Map.Control2 - Map.Control1);
                this.gameObject.transform.position += (this.gameObject.transform.up.normalized * this.transform.localScale.y);
            }
            else
            {
                if (IsUser)
                {
                    this.gameObject.transform.position = WorldControlPoint.Position1;
                    this.gameObject.transform.up = (Camera.main.transform.position - WorldControlPoint.Position1);
                    var temp = this.gameObject.transform.up;
                    this.gameObject.transform.up = new Vector3(temp.x, 0, temp.z);
                    this.gameObject.transform.position += (this.gameObject.transform.up.normalized * this.transform.localScale.y);
                }
                else
                {
                    this.gameObject.transform.position = WorldControlPoint.Position1;
                    this.gameObject.transform.up = (WorldControlPoint.Position2 - WorldControlPoint.Position1);
                    this.gameObject.transform.position += (this.gameObject.transform.up.normalized * this.transform.localScale.y);
                }
            }
        }
	}
}
