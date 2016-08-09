using UnityEngine;
using System.Collections;

public class ToggleDebug : MonoBehaviour {

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
        CylHelper.DebugEnabled = !CylHelper.DebugEnabled;
    }
}
