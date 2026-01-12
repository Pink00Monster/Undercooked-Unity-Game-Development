using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter {

    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float plateSpawnTimer;
    private float plateSpawnTimerMax = 4f;
    private int plateSpawnAmount;
    private int plateSpawnAmountMax = 4;

    private void Update() {
        plateSpawnTimer += Time.deltaTime;
        if (plateSpawnTimer > plateSpawnTimerMax) {
            plateSpawnTimer = 0f;
            if (!HasKitchenObject()) {               
                if (plateSpawnAmount < plateSpawnAmountMax) {
                    plateSpawnAmount++;

                    OnPlateSpawned?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {
            if (plateSpawnAmount > 0) {
                plateSpawnAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
