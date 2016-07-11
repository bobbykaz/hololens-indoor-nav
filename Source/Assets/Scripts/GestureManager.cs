using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GestureManager : MonoBehaviour {

    public static GestureManager Instance { get; private set; }
    GestureRecognizer recognizer;
    public GameObject FocusedObject { get; private set; }

    // Use this for initialization
    void Start () {
        Instance = this;

        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (FocusedObject != null)
                FocusedObject.SendMessageUpwards("OnSelect");
        };

        recognizer.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        if (WorldCursor.Instance.GotHit)
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = WorldCursor.Instance.HitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
