using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    public static WorldCursor Instance;
    public bool GotHit;
    public RaycastHit HitInfo;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        Instance = this;
    }

    void Update()
    {
        var headPos = Camera.main.transform.position;
        var gazeDir = Camera.main.transform.forward;
        GotHit = Physics.Raycast(headPos, gazeDir, out HitInfo);
        if (GotHit)
        {

            meshRenderer.enabled = true;
            this.transform.position = (HitInfo.point - this.transform.position) / 10 + this.transform.position;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, HitInfo.normal);
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}