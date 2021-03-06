﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSightController : MonoBehaviour {

    public float distance = 50f;

    [SerializeField]
    private TargetSightView targetSightView;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // 射撃(スペースキー)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            //[TODO]TargetSightViewの関数を呼びたくない。
            StartCoroutine(targetSightView.FireView());
        }
    }

    void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, distance)){

            // ダメージ対象かどうか
            if (hit.collider.GetComponent<IDamageable>() != null)
            {
                // ダメージ処理
                hit.collider.GetComponent<IDamageable>().Damage();
            }
        }
    }
}
