using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    public static event EventHandler OnAnyObjectPlacedHere;

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public virtual void Interact(Player player){
        // This method is meant to be overridden in derived classes.
        Debug.LogError("BaseCounter Interact method called. This should be overridden in a derived class.");
    }

    public virtual void InteractAlternate(Player player){
        // This method is meant to be overridden in derived classes.
        Debug.LogError("BaseCounter InteractAlternate method called. This should be overridden in a derived class.");
    }

    public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null) {
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
