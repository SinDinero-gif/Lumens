using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Portal : MonoBehaviour
{
    public Colors colorPortal;
    [SerializeField] private Light2D portalLight;
    
    [ContextMenu("Portal Color Swap")]
    public void Start()
    {
        PortalColorSwap();
    }

    private void PortalColorSwap()
    {
        switch (colorPortal)
        {
            case Colors.white:
                portalLight.color = Color.white;
                break;
            case Colors.red:
                portalLight.color = Color.red;
                break;
            case Colors.blue:
                portalLight.color = Color.blue;
                break;
            case Colors.green:
                portalLight.color = Color.green;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
