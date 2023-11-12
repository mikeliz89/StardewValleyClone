using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
   Transform player;
   [SerializeField] float speed = 5f;
   [SerializeField] float pickupDistance = 1.5f;
   [SerializeField] float timeToLootInSeconds = 10f;

   private void Awake() {
    player = GameManager.instance.player.transform;
   }

   private void Update() 
   {
        //item will be destroyed after time to loot time
        timeToLootInSeconds -= Time.deltaTime;
        if(timeToLootInSeconds < 0) {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickupDistance) {
            return;
        }

        transform.position = Vector3.MoveTowards(
         transform.position, 
         player.position,
         speed * Time.deltaTime
        );

        if(distance < 0.1f) {
            Destroy(gameObject);
        }
   }
}
