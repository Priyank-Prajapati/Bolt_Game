using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    private bool shouldZoomIn = false;
    private bool shouldZoomOut = false;

    public AudioSource audio;
    
    void Update()
    {
        if (shouldZoomIn)
            ZoomIn();
        else if (shouldZoomOut)
            ZoomOut();
    }

    void ZoomIn()
    {
        playerCam.m_Lens.OrthographicSize = Mathf.Lerp(playerCam.m_Lens.OrthographicSize, playerCam.m_Lens.OrthographicSize - 1.0f, 1f * Time.deltaTime);
        if (playerCam.m_Lens.OrthographicSize <= 4.0f)
            shouldZoomIn = false;
    }
    void ZoomOut()
    {
        playerCam.m_Lens.OrthographicSize = Mathf.Lerp(playerCam.m_Lens.OrthographicSize, playerCam.m_Lens.OrthographicSize + 1.0f, 1f * Time.deltaTime);
        if (playerCam.m_Lens.OrthographicSize >= 5.0f)
            shouldZoomOut = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            shouldZoomIn = true;
            audio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shouldZoomOut = true;
            if (!PlayerController.isDead)
                audio.Stop();
        }
    }
}
