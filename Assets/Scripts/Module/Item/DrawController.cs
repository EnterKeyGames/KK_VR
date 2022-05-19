using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    [SerializeField] private Transform TrackingSpace = default;

    [SerializeField] private Transform lineParentTransform = default;

    [SerializeField] private Material lineMaterial = default;

    private LineRenderer lineRenderer;
    private int lineCount;
    private bool isDrawing = false;

    // Start is cal led before the first frame update
    void Start()
    {
        lineCount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.8)
        {
            if (!isDrawing)
            {
                GameObject obj = new GameObject();
                obj.transform.SetParent(lineParentTransform);
                lineRenderer = obj.AddComponent<LineRenderer>();
                lineRenderer.material = lineMaterial;
                lineRenderer.startWidth = 0.02f;
                lineRenderer.endWidth = 0.02f;
                isDrawing = true;
            }

            //  コントローラー座標を取得
            Vector3 localPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Vector3 pos = TrackingSpace.TransformPoint(localPos);

            lineCount++;

            lineRenderer.positionCount = lineCount;
            lineRenderer.SetPosition(lineCount - 1, pos);
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 0 && isDrawing)
        {
            isDrawing = false;
            lineCount = 0;
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            foreach(Transform t in lineParentTransform)
            {
                Destroy(t.gameObject);
            }
        }
    }
}
