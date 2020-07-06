using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class HotspotColliderFixer : MonoBehaviour {

    public GameObject player = null;
    public GameObject detector = null;

    void Start()
    {
    }

    void Update() {
      detector.transform.position = player.transform.position + new Vector3(0,2,0);
    }
}