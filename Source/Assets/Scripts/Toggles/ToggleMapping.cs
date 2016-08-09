using UnityEngine;
using System.Collections;

public class ToggleMapping : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnSelect()
    {
        Toggle();
    }

    public static void Toggle()
    {
        if (SpatialMapping.Instance != null)
            SpatialMapping.Instance.DrawVisualMeshes = !SpatialMapping.Instance.DrawVisualMeshes;
    }
}
