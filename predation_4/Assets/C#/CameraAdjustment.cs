using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjustment: MonoBehaviour
{
    [SerializeField] Level LE;
    private GameObject player;  //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    //レベルカウント
    private int count=1;
    private float MaxCameraZ;
    private float MaxCameraY;
    //カメラ引く倍率
    public float CameraPosition;
    //縮小スピード
    public float shrinkSpeed = 0.01f;
    //カメラアップ距離
    public float Speed = 0f;

    //public bool s = false;

    // Use this for initialization
    void Start()
    {

        //情報を取得
        this.player = GameObject.Find("hebi 2");

        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;

        //レベルが上がった時のカメラを調整する位置の最大
        MaxCameraZ = transform.localPosition.z * CameraPosition;
        MaxCameraY = transform.position.y * CameraPosition+Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;

        //レベルカウントより現在のレベルが大きい場合
        if (count < LE.level)
        {
            //現在の大きさがMAX大きさより大きい時
            if (player.transform.localScale.x > LE.CurrentSize)
            {
                //カメラのZ座標の調整
                if (transform.localPosition.z < MaxCameraZ)
                {
                    count++;
                    //カメラアップ距離
                    Speed+=0.5f;
                    MaxCameraY = MaxCameraY * CameraPosition+Speed;
                    MaxCameraZ = MaxCameraZ * CameraPosition;
                    Time.timeScale = 1;  // 時間再開
                }
                //カメラのY座標の調整
                else if (transform.localPosition.y < MaxCameraY)
                {
                    offset.z -= shrinkSpeed;
                    offset.y += shrinkSpeed;
                }
                else
                {
                    offset.z -= shrinkSpeed;
                }
            }
        }
    }
}
