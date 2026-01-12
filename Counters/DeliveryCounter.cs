using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{

    public static DeliveryCounter Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one DeliveryCounter instance!");
        }
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject()){
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
               // Player is carrying a plate
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                player.GetKitchenObject().DestroySelf();
            }

        }
        else
        {
            // Player is not carrying anything
            // Do nothing
        }
    }
}
