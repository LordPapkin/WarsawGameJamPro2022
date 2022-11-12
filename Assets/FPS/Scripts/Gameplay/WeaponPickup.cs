using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class WeaponPickup : Pickup
    {
        [Tooltip("The prefab for the weapon that will be added to the player on pickup")]
        public WeaponController WeaponPrefab;

        protected override void Start()
        {
            base.Start();

            // Set all children layers to default (to prefent seeing weapons through meshes)
            foreach (Transform t in GetComponentsInChildren<Transform>())
            {
                if (t != transform)
                    t.gameObject.layer = 0;
            }
        }

        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            PlayerWeaponsManager playerWeaponsManager = byPlayer.GetComponent<PlayerWeaponsManager>();
            if (playerWeaponsManager)
            {

                if (playerWeaponsManager.GetActiveWeapon() == null)
                {
                    if (playerWeaponsManager.AddWeapon(WeaponPrefab))
                    {
                        playerWeaponsManager.SwitchWeapon(true);
                        playerWeaponsManager.ActiveWeaponPrefab = WeaponPrefab;
                        playerWeaponsManager.ActiveWeaponPrefab.pickupPosition = transform.position;

                        PlayPickupFeedback();
                        Destroy(gameObject);
                    }
                } 
                else
                {
                    if (playerWeaponsManager.AddWeapon(WeaponPrefab))
                    {
                        playerWeaponsManager.RemoveWeapon(playerWeaponsManager.GetActiveWeapon());
                        Instantiate(playerWeaponsManager.ActiveWeaponPrefab.pickupPrefab, playerWeaponsManager.ActiveWeaponPrefab.pickupPosition, WeaponPrefab.transform.rotation);

                        playerWeaponsManager.SwitchWeapon(true);
                        playerWeaponsManager.ActiveWeaponPrefab = WeaponPrefab;
                        playerWeaponsManager.ActiveWeaponPrefab.pickupPosition = transform.position;

                        PlayPickupFeedback();
                        Destroy(gameObject);
                    }
                }

            }
        }
    }
}