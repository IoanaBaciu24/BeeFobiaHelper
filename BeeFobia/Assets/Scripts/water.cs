using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour{
    public GameObject mLiquid;
    public GameObject mLiquidMesh;

    private int mSloshSpeed = 60;
    private int mRotateSpeed = 15;
    private int difference = 25;

    // Update is called once per frame
    void Update(){
        //motion
        Slosh();
        //mLiquidMesh.transform.Rotate(Vector3.up * mRotateSpeed * Time.deltaTime, Space.Self);
    }

    private void Slosh(){
        //inverse cup rotation
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
        //rotate to
        Vector3 finalRotation = Quaternion.RotateTowards(mLiquid.transform.localRotation, inverseRotation, mSloshSpeed * Time.deltaTime).eulerAngles;

        //clamp
        //finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        //set
        mLiquid.transform.localEulerAngles = finalRotation;
    }

    private float ClampRotationValue(float value, float difference){
        return (value > 180) ? Mathf.Clamp(value, 360 - difference, 360) : Mathf.Clamp(value, 0, difference);
    }
}
