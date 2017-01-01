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
        // If our player somehow ends up without a camera, disable.
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
            // We hit something (player prefab is assigned tag 'Player')
            // So, this is only true if we've hit a Player (other objects fail)
            if (_hit.collider.tag == PLAYER_TAG)
            {
                // Notify the server of the player we've hit
                CmdPlayerHit(_hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerHit (string _playerID)
    {
        Debug.Log(_playerID + " has been hit");
    }
}
