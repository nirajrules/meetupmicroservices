using System;
using System.Collections.Generic;

public static class WinnerManager
{
    static private Random r = new Random();
    public static int PickNextWinner<T>(string currentWinners, List<T> RSVPs)
    {
        int winner = -1;
        string[] winnerIDs = null;

        if (RSVPs == null || RSVPs.Count == 0)
            return -1;

        if (currentWinners == string.Empty)
            return r.Next(RSVPs.Count);

        currentWinners = currentWinners.Trim(','); //Remove the last trailing ',' 
        winnerIDs = currentWinners.Split(",");

        if (winnerIDs.Length == RSVPs.Count)
            return -1;


        while (true)
        {
            winner = r.Next(RSVPs.Count);
            if (WinnerIsAlreadyAwarded(winnerIDs, winner))
                continue; //skip and select another one
            break; // found the winner
        }

        return winner;
    }

    static bool WinnerIsAlreadyAwarded(string[] winnerIDs, int winner)
    {
        foreach (string winnerId in winnerIDs) // Loop through existing Winners to make sure selected Winner wasn't chosen already
        {
            if (winner == Convert.ToInt32(winnerId)) //If yes 
            {
                return true;
            }
        }
        return false;
    }
}