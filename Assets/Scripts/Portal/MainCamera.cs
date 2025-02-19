using UnityEngine;
using UnityEngine.Rendering;

public class MainCamera : MonoBehaviour {

    Portal[] portals;

    void Awake () {
        portals = Object.FindObjectsByType<Portal>(FindObjectsSortMode.None);
        Debug.Log(portals.Length);
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += OnPreRenderCamera;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnPreRenderCamera;
    }

    private void OnPreRenderCamera(ScriptableRenderContext context, Camera camera)
    {
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].PrePortalRender();
        }
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].Render();
        }

        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].PostPortalRender();
        }
    }
}