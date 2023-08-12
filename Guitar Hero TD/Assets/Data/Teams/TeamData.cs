using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "TeamData")]
public class TeamData : ScriptableObject
{
    public string teamName;
    public Color teamColor;
    public Sprite bulletSprite;
    public Sprite towerSprite;
    public Sprite enemySprite;
}
