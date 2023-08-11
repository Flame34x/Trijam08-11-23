using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private GameObject selectedTower;

    public TeamData[] availableTeams;
    public int currentTeamIndex = 0;

    #endregion

    #region Private Fields

    private GameObject spot;

    #endregion

    #region MonoBehaviour Callbacks

    private void Update()
    {
        HandleMouseInput();
        HandleTowerPlacement();
        ChangeTeam();
    }

    #endregion

    #region Input Handling

    private void HandleMouseInput()
    {
        CheckMouse();
    }

    public void ChangeTeam()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Increment the current team index
            currentTeamIndex = (currentTeamIndex + 1) % availableTeams.Length;

            TeamData selectedTeam = availableTeams[currentTeamIndex];
        }
    }

    #endregion

    #region Tower Placement

    private void HandleTowerPlacement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (spot != null && !spot.GetComponent<BuildSpot>().IsOccupied)
            {
                spot.GetComponent<BuildSpot>().BuildTower(selectedTower, availableTeams[currentTeamIndex]);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (spot != null && spot.GetComponent<BuildSpot>().IsOccupied)
            {
                spot.GetComponent<BuildSpot>().DestroyTower();
            }
        }
    }

    #endregion

    #region Mouse Position Checking

    private void CheckMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        // Check if the mouse is over a BuildSpot
        if (hit.collider != null && hit.collider.CompareTag("BuildSpot"))
        {
            GameObject newSpot = hit.transform.gameObject;

            if (newSpot != spot)
            {
                // Unhighlight the previous spot if there was any
                if (spot != null)
                {
                    spot.GetComponent<BuildSpot>().SetHighlighted(false);
                }

                // Set the new spot and highlight it
                spot = newSpot;
                spot.GetComponent<BuildSpot>().SetHighlighted(true);
            }
        }
        else
        {
            // Mouse is not over a BuildSpot, unhighlight the previous spot if there was any
            if (spot != null)
            {
                spot.GetComponent<BuildSpot>().SetHighlighted(false);
                spot = null; // Reset the spot reference
            }
        }
    }

    #endregion
}
