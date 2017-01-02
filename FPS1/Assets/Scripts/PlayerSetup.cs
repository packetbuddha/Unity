using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
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
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    { 
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    } 

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
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

    // Assign the remote players to their own layer
    private void AssignPlayerLayer ()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    // When player dies, re-enable the scene camera
    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
        Cursor.lockState = CursorLockMode.None;



    }
}
