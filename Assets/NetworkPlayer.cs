using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin xROrigin = FindAnyObjectByType<XROrigin>();
        xROrigin.transform.Find("CameraOffset/Main Camera");
        leftHandRig = xROrigin.transform.Find("CameraOffset/LeftHand");
        rightHandRig = xROrigin.transform.Find("CameraOffset/RightHand");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            rightHandRig.gameObject.SetActive(false);
            leftHandRig.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    { 
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
