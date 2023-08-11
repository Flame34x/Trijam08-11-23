using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private BuildManager bm;

    RawImage sr;

    private void Start()
    {
        bm = GameObject.FindGameObjectWithTag("BuildManager").GetComponent<BuildManager>();
        sr = GetComponent<RawImage>();
    }

    private void Update()
    {
        sr.color = bm.availableTeams[bm.currentTeamIndex].teamColor;
    }


}
