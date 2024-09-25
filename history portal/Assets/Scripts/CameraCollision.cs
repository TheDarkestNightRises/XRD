using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraCollision : MonoBehaviour
{
    public Material[] materials;
    public Transform camera;
    private bool wasInFront;
    private bool inVirtualWorld;
    private bool hasCollided;

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
        var worldPos = camera.position + camera.forward * Camera.main.nearClipPlane;
        return transform.InverseTransformPoint(worldPos).z >= 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != camera)
        {
            return;
        }
    
        wasInFront = IsInFront();
        hasCollided = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != camera)
        {
            return;
        }
        hasCollided = false;
    }

    private void WhileColliding()
    {
        if (!hasCollided) return;
        bool isInFront = IsInFront();
        if (isInFront != wasInFront)
        {
            inVirtualWorld = !inVirtualWorld;
            SetMaterials(inVirtualWorld);
        }
        wasInFront = isInFront;
    }

    private void Update()
    {
        WhileColliding();
    }

    private void OnDestroy()
    {
        SetMaterials(true);
    }
}
