using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    public PlayerWeapon weapon;
    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No Camera referenced");
            this.enabled = false;
 
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            // We hit something
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerHit(_hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerHit (string playerID)
    {
        Debug.Log(playerID + " has been hit");
    }
}
