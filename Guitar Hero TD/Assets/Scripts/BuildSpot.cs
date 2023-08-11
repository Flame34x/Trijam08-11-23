using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    #region Public Properties

    public bool IsHighlighted { get; private set; }
    public bool IsOccupied { get; private set; }

    public Color HighlightedColor;
    public Color NormalColor;
    public Color occupiedColor;

    public Transform BuildSpotTransform;

    #endregion

    #region Private Fields

    private SpriteRenderer spriteRenderer;
    private GameObject tower;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void Update()
    {
        UpdateColor();
    }

    #endregion

    #region Public Methods

    public void SetHighlighted(bool highlighted)
    {
        if (IsOccupied)
        {
            IsHighlighted = highlighted;
            UpdateColor();
        }
        else
        {
            IsHighlighted = highlighted;
            UpdateColor();
        }
    }

    public void BuildTower(GameObject towerPrefab, TeamData team)
    {
        if (!IsOccupied)
        {
          GameObject newTower =  Instantiate(towerPrefab, BuildSpotTransform.position, Quaternion.identity);
            newTower.GetComponent<Tower>().team = team;
            tower = newTower;
            IsOccupied = true;
        }
    }

    public void DestroyTower()
    {
        if (IsOccupied)
        {
            Destroy(tower);
            tower = null;
            IsOccupied = false;
        }
    
    }

    #endregion

    #region Private Methods

    private void UpdateColor()
    {
        if (!IsOccupied)
        {
        spriteRenderer.color = IsHighlighted ? HighlightedColor : NormalColor;
        }
       if (IsOccupied)
        {
        spriteRenderer.color = IsHighlighted ? occupiedColor : NormalColor;
        }
    }

    #endregion
}
