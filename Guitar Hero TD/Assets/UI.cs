using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    private BuildManager bm;

    public Image curretTurret;

    public TMP_Text A;
    public TMP_Text D;
    public TMP_Text teamSelected;
    public TMP_Text turretCount;

    private void Start()
    {
        bm = GameObject.FindGameObjectWithTag("BuildManager").GetComponent<BuildManager>();
    }

    private void Update()
    {
        curretTurret.sprite = bm.availableTeams[bm.currentTeamIndex].towerSprite;

       A.color = bm.previousTeam.teamColor;
       D.color = bm.nextTeam.teamColor;
       teamSelected.text = bm.availableTeams[bm.currentTeamIndex].teamName + " Team Selected";
        teamSelected.color = bm.availableTeams[bm.currentTeamIndex].teamColor;
        turretCount.text = bm.currentTurretAmt.ToString() + "/" + bm.maxTurretAmt.ToString();

        if (bm.currentTurretAmt >= bm.maxTurretAmt)
        {
            turretCount.color = Color.red;
        }
        else
        {
            turretCount.color = Color.white;
        }
    }


}
