using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // Counter is empty
            if (player.HasKitchenObject()) {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else {
                // Player is not carrying anything
            }
        }
        else {
            // Counter has something
            if (player.HasKitchenObject()) {
                // Player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    // Player is carrying a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) { 
                        GetKitchenObject().DestroySelf();
                    }
                }
                else {
                    // Player is NOT carrying a plate 
                    if (GetKitchenObject().TryGetPlate(out PlateKitchenObject counterPlateKitchenObject)) {
                        // Counter has a plate on it
                        if (counterPlateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {    
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }


        }
    }
}
