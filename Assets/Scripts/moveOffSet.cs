﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffSet : MonoBehaviour
{
    private Material materialAtual;
    public float velocidade;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        materialAtual = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        offset += 0.01f;
        
        materialAtual.SetTextureOffset("_MainTex", new Vector2 (offset * velocidade, 0));
    }
}
