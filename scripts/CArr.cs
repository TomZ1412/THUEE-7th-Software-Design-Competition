using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CArr:MonoBehaviour
{
    public Transform target;    //目标  
    public Transform self;  //自己  

    public float direction; //箭头旋转的方向，或者说角度，只有正的值  
    public Vector3 u;   //叉乘结果，用于判断上述角度是正是负  

    float devValue = 10f;   //离屏边缘距离  
    float showWidth;    //由devValue计算出从中心到边缘的距离（宽和高）  
    float showHeight;

    Quaternion originRot;   //箭头原角度  

    // 初始化  
    void Start()
    {
        originRot = transform.rotation;
        //showWidth = Screen.width / 2 - devValue;  
        //showHeight = Screen.height / 2 - devValue;  
    }

    void Update()
    {
        // 每帧都重新计算一次，主要是调试使用方便  
       // showWidth = Screen.width / 2 - devValue;
        //showHeight = Screen.height / 2 - devValue;

        // 计算向量和角度  
        Vector3 forVec = self.forward;  //计算本物体的前向量  
        Vector3 angVec = (target.position - self.position).normalized;  //本物体和目标物体之间的单位向量  

        Vector3 targetVec = Vector3.ProjectOnPlane(angVec - forVec, forVec).normalized; //这步很重要，将上述两个向量计算出一个代表方向的向量后投射到本身的xy平面  
        Vector3 originVec = self.up;

        direction = Vector2.Dot(originVec, targetVec);  //再跟y轴正方向做点积和叉积，就求出了箭头需要旋转的角度和角度的正负  
        u = Vector3.Cross(originVec, targetVec);

        direction = Mathf.Acos(direction) * Mathf.Rad2Deg;  //转换为角度  

        u = self.InverseTransformDirection(u);  //叉积结果转换为本物体坐标  

        // 给与旋转值  
        transform.rotation = originRot * Quaternion.Euler(new Vector3(0f, 0f, direction * (u.z > 0 ? 1 : -1)));

        // 计算当前物体在屏幕上的位置  
        Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);

        //if(Vector3.Dot(forVec, angVec) < 0)  
        // 不在屏幕内的情况  
        if (screenPos.x < devValue || screenPos.x > Screen.width - devValue || screenPos.y < devValue || screenPos.y > Screen.height - devValue || Vector3.Dot(forVec, angVec) < 0)
        {
            Vector3 result = Vector3.zero;
            if (direction == 0) //特殊角度0和180直接赋值，大家知道tan90会出现什么结果  
            {
                result.y = showHeight;
            }
            else if (direction == 180)
            {
                result.y = -showHeight;
            }
            else    //非特殊角  
            {
                // 转换角度  
                float direction_new = 90 - direction;
                float k = Mathf.Tan(Mathf.Deg2Rad * direction_new);

                // 矩形  
                result.x = showHeight / k;
                if ((result.x > (-showWidth)) && (result.x < showWidth))    // 角度在上下底边的情况  
                {
                    result.y = showHeight;
                    if (direction > 90)
                    {
                        result.y = -showHeight;
                        result.x = result.x * -1;
                    }
                }
                else    // 角度在左右底边的情况  
                {
                    result.y = showWidth * k;
                    if ((result.y > -showHeight) && result.y < showHeight)
                    {
                        result.x = result.y / k;
                    }
                }
                if (u.z > 0)
                    result.x = -result.x;
            }
            //transform.localPosition = result;
        }
        else    // 在屏幕内的情况  
        {
            //transform.position = screenPos;
        }
    }
}