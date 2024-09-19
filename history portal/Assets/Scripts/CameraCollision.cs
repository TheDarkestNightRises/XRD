using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraCollision : MonoBehaviour
{
    public Material[] materials;
    public Transform camera;
    private bool wasInFront;
    private bool inVirtualWorld;

    private void Start()
    {
        SetMaterials(false);
    }

    private void SetMaterials(bool render)
    {
        var stencilTest = render ? CompareFunction.NotEqual : CompareFunction.Equal;

        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)stencilTest);
        }
    }

    private bool IsInFront()
    {
        return transform.InverseTransformPoint(camera.position).z >= 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == camera)
        {
            wasInFront = IsInFront();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform != camera)
        {
            return;
        }

        bool isInFront = IsInFront();
        if (isInFront != wasInFront)
        {
            inVirtualWorld = !inVirtualWorld;
            SetMaterials(inVirtualWorld);
        }
        wasInFront = isInFront;
    }

    private void OnDestroy()
    {
        SetMaterials(true);
    }
}
