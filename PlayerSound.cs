using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    //play a step sound every 0.1 seconds while walking.
    private float footstepTimerMax = .1f;

    private void Awake() {
        player = GetComponent<Player>();
    }

    private void Update() {
        if (player.IsWalking()) {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f) {
                footstepTimer = footstepTimerMax;
                float volume = 1f;
                SoundManager.Instance.PlayFootstepSound(player.transform.position, volume);
            }
        } 
    }
}
