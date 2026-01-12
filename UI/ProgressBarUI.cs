using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour {
    
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage; 

    private IHasProgress hasProgressObject;
    private void Start() {
        hasProgressObject = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgressObject == null) {
            Debug.LogError("ProgressBarUI could not find IHasProgress component on hasProgressGameObject.");
            return;
        }
        hasProgressObject.OnProgressChanged += HasProgress_OnProgressChanged;

        barImage.fillAmount = 0f;

        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 1f || e.progressNormalized == 0f) {
            Hide();
        } else {
            Show();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
