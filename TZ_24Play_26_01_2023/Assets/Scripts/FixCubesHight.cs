using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FixCubesHight : MonoBehaviour
{
    [SerializeField] PlayerHeight ph;
    [SerializeField] Transform extraCubes;
    Vector3 NewPos;
    void LateUpdate()
    {
        for(int i=0;i<extraCubes.childCount;i++){
            if(extraCubes.GetChild(i).transform.localPosition.y!=-i-1.5f && ph.Wait<=0){ //-1.5 - is where new blocks attached
                NewPos = new Vector3(extraCubes.localPosition.x, -i-1.5f ,extraCubes.localPosition.z);
                extraCubes.GetChild(i).DOLocalMove(NewPos,1/ph.fallSpeed).WaitForKill();
            }
        }
    }
}
