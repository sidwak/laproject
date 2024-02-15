using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TransformUISc : MonoBehaviour
{
    public TMP_InputField translIn;
    public TMP_InputField rotaIn;
    public TMP_InputField scalIn;
    public TMP_InputField timeIn;

    void Start()
    {
        timeIn.text = "3.0";
    }

    void Update()
    {
        
    }
    public void TranslateBtnPressed() 
    {
        string t = translIn.text;
        string[] tA = t.Split(",");
        Vector3 tarT = new Vector3(float.Parse(tA[0]), float.Parse(tA[1]), float.Parse(tA[2]));
        float time = float.Parse(timeIn.text);
        TransformAnimator.Instance.StartTranslation(TransformAnimator.Instance.selectedObj.transform.position,
            tarT, time);
    }
    public void RotateBtnPressed() 
    {
        string r = rotaIn.text;
        string[] rA = r.Split(",");
        Quaternion tarR = Quaternion.Euler(float.Parse(rA[0]), float.Parse(rA[1]), float.Parse(rA[2]));
        float time = float.Parse(timeIn.text);
        TransformAnimator.Instance.StartRotation(TransformAnimator.Instance.selectedObj.transform.rotation,
            tarR, time);
    }
    public void ScaleBtnPressed() 
    {
        string s = scalIn.text;
        string[] sA = s.Split(",");
        Vector3 tarS = new Vector3(float.Parse(sA[0]), float.Parse(sA[1]), float.Parse(sA[2]));
        float time = float.Parse(timeIn.text);
        TransformAnimator.Instance.StartScaling(TransformAnimator.Instance.selectedObj.transform.localScale,
            tarS, time);
    }
}
