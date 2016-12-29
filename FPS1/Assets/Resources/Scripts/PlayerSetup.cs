using UnityEngine;
using UnityEngine.Networking;


public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    NetworkInstanceId playerID;
    Camera sceneCamera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignPlayerLayer();
        } else
        {
            DisableCamera();
        }

        RegisterPlayer();        
    }

    private void RegisterPlayer ()
    {
        playerID = GetComponent<NetworkIdentity>().netId;
        transform.name = "Player " + playerID.ToString();
    }

    private void DisableComponents ()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    private void DisableCamera()
    {
        sceneCamera = Camera.main;
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(false);
        }
    }

    private void AssignPlayerLayer ()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void OnDisable()
    {
        sceneCamera.gameObject.SetActive(true);
    }
}
