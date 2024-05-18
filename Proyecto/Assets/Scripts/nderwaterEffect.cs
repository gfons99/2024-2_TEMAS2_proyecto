using UnityEngine;
using Cinemachine; // Asegúrate de importar el namespace necesario

public class UnderwaterEffect : MonoBehaviour
{
    public float underwaterLevel = 7f;

    // Referencia a la cámara FreeLook
    public CinemachineFreeLook freeLookCamera;

    // Los ajustes de niebla predeterminados de la escena
    private bool defaultFog;
    private Color defaultFogColor;
    private float defaultFogDensity;

    void Start()
    {
        // Establece el color de fondo
        if (freeLookCamera != null)
        {
            freeLookCamera.gameObject.GetComponent<Camera>().backgroundColor = new Color(0f, 0.4f, 0.7f, 1f);
        }

        // Almacena los ajustes predeterminados de niebla de la escena
        defaultFog = RenderSettings.fog;
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;
    }

    void Update()
    {
        if (transform.position.y < underwaterLevel)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.3f, 0.6f, 0.8f, 0.3f); // Color de niebla más transparente
            RenderSettings.fogDensity = 0.01f; // Reducir la densidad de la niebla para hacerla más transparente
        }
        else
        {
            RenderSettings.fog = defaultFog;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
        }
    }
}
