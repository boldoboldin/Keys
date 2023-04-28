using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBarImage;
    public PlayerCtrl playerCtrl;

    // Update is called once per frame
    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(playerCtrl.hp / playerCtrl.maxHp, 0, 1f);
    }
}
