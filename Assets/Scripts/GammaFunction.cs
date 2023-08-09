// 角度を補正する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammaFunction : MonoBehaviour
{
    public GameObject TrueRacket;
    public float xr;
    public float yr;
    public float zr;

    public float maxGamma; // 最大の補正の係数
    private float gamma = 0.0f;
    private float initGamma = 4.0f;
    public float threshold;
    public float transitionStartTime; // 補正をかけ始める時間
    public float transitionTime; // 最大の補正にかかるまでの時間
    private float startTimestamp;
    // Start is called before the first frame update
    void Start()
    {
        maxGamma = initGamma;
        threshold = 6.0f;
        startTimestamp = Time.time;
        //InvokeRepeating("GammaChanger", 25, 0.2f);
    }

    void GammaChanger()
    {
        maxGamma -= initGamma / 20.0f;
        if (maxGamma <= 0.1f)
        {
            maxGamma = 0.0f;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Quaternion baseQuaternion = TrueRacket.transform.rotation;
        Vector3 baseRotation = baseQuaternion.eulerAngles;
        gamma = calcGamma();
        // Debug.Log($"gamma: {gamma}");
        // Debug.Log($"before: {baseRotation}");
        xr = baseRotation.x;
        yr = baseRotation.y;
        zr = baseRotation.z;
        //ガンマ関数を適用する
        float y=0;
        float x=0;
        if (gamma > 0.0f) {
            y = applyGamma(zr, gamma);
            x = applyGamma(xr, gamma);
        }

        transform.localRotation = Quaternion.Euler(x, y, 0);
        // Debug.Log($"after: {transform.rotation.eulerAngles}");

    }
    // ガンマ関数を適用する
    // beforeRotation: 補正をかける前の角度
    // nowGamma: 現在の補正度合い
    float applyGamma(float beforeRotation, float nowGamma)
    {
        float afterRotation = 0.0f;
        if(0<beforeRotation && threshold>=beforeRotation){
            afterRotation = -(beforeRotation-threshold*Mathf.Pow(beforeRotation/threshold, nowGamma));
        }
        else if((360-threshold)<=beforeRotation &&360>beforeRotation){
            afterRotation = (360-beforeRotation)-threshold*Mathf.Pow((360-beforeRotation)/threshold, nowGamma);
        }
        return afterRotation;
    }
    // どのくらいの補正をかけるかを計算する
    float calcGamma()
    {
        float nowTimestamp = Time.time;
        float elapsedTime = nowTimestamp - transitionStartTime - startTimestamp;
        if (elapsedTime > transitionTime) {
            return maxGamma;
        } else if (elapsedTime < 0.0f) {
            return 0.0f;
        }else {
            // 線形に変化する
            return (maxGamma - initGamma)*(elapsedTime/transitionTime) + initGamma;
        }
    }
}
