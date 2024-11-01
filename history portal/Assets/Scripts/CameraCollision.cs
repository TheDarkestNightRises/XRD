using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraCollision : MonoBehaviour
{
    public Material[] materials;
    private bool wasInFront;
    private bool inVirtualWorld;
    private bool hasCollided;
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
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
        float offsetDistance = Camera.main.nearClipPlane;
        var worldPos = mainCamera.position + mainCamera.forward * offsetDistance;
        return transform.InverseTransformPoint(worldPos).z >= 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera")) return;
        mainCamera.position += mainCamera.forward * 0.02f;
        wasInFront = IsInFront();
        hasCollided = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("MainCamera")) return;
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
            wasInFront = isInFront;
        }
    }

    private void Update()
    {
        WhileColliding();
    }
}
