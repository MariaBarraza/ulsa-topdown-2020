using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
  [SerializeField]
  List<Player> currentParty;
  Player leader;
   [SerializeField]
  Player[] players;

  void Start()
  {
      players = FindObjectsOfType(typeof(Player)) as Player[];
      for(int i=0;0<players.Length;i++)
      {
          Player p = players[i];
          if(p.IsLeader)
          {
              p.IsNpc = false;
              if(currentParty.Count > 0)
              {
                  currentParty.Insert(0,p);
              }
              else 
              {
                  currentParty.Add(p);
              }
          }
          else
          {
              p.IsNpc = true;
              currentParty.Add(p);
          }
      }
      for(int i=0;0<currentParty.Count;i++)
      {
          currentParty[i].Target = currentParty[i - 1];
      }
  }
}
