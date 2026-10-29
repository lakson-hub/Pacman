using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public event EventHandler OnScoreChanged;

    private int score;

    private void OnEnable() {
        Pellet.OnAnyPelletEaten += Pellet_OnAnyPelletEaten;
    }

    private void OnDisable() {
        Pellet.OnAnyPelletEaten -= Pellet_OnAnyPelletEaten;
    }

    private void Pellet_OnAnyPelletEaten(object sender, Pellet.OnAnyPelletEatenEventArgs e) {
        AddPoints(e.GetPelletSO().GetPoints());
    }

    private void AddPoints(int points) {
        if (points <= 0) return;

        score += points;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log(score);
    }

    public int GetScore() {
        return score;
    }
}
