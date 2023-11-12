using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidBody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    
    private void Awake() {
        character = GetComponent<CharacterController2D>();
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        UseTool();
    }

    private void UseTool() {
        Vector2 position = rigidBody2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders) {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null) {
                hit.Hit();
                break;
            }
        }
    }
}
