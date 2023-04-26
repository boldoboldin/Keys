using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private BillboardType billboardType;

    public enum BillboardType {LookAtCamera, CameraForward};

    [SerializeField] private PlayerCtrl playerCtrl;
    
    
    void LateUpdate()
    {
        switch (billboardType)
        {
            case BillboardType.LookAtCamera: transform.LookAt(Camera.main.transform.position, Vector3.up);
            break;

            case BillboardType.CameraForward: transform.forward = Camera.main.transform.forward;
            break;
           
        default:
            break;
        }
    }
    public void ActivateAtk()
    {
        playerCtrl.ActivateAtk();

    }
    public void DeactivateAtk()
    {
        playerCtrl.DeactivateAtk();
    }
}
