using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalBattle
{
    public class Game
    {
        int _turn = 0;
        int _round = 1;
        public bool _gameOver = false;
        bool _roundOver;

        Party goodGuys = new Party(PlayerType.Human, "Heroes", 1);
        Party badGuys = new Party(PlayerType.Computer, "Monsters", 1);

        /// <summary>
        /// This function currently runs the turn logic for each game.  
        /// Heroes attack first, then the bad guys attack.
        /// After each attack, we check to see if the game is over.
        /// </summary>
        public void RunGame()
        {
            while (!_gameOver)
            {
                if (_round == 2)
                {
                    Party badGuys = new Party(PlayerType.Computer, "Monsters", 2);
                }
                //else if (_round == 3)
                //{
                  
                //}

                Round(_round, badGuys);
                _round++;
            }
            
        }

        public void Round(int round, Party badGuys)
        {
            for (int i = 0; i < goodGuys.characters.Count; i++)
            {
                if (GetTurn(_turn) == "Heroes")
                {
                    Console.WriteLine($"It is {goodGuys.characters[i]._name}'s turn.");

                    if (goodGuys._playerType == PlayerType.Computer) goodGuys.characters[i].ComputerAction(goodGuys, badGuys);
                    else goodGuys.characters[i].PlayerAction(goodGuys, badGuys);

                    // check if action eliminated enemy team
                    IsRoundOver(goodGuys, badGuys);
                    if (_roundOver) break;
                    Console.WriteLine();
                    Thread.Sleep(500);
                    _turn++;
                }

                if (GetTurn(_turn) == "Monsters")
                {
                    Console.WriteLine($"Number of badGuys: {badGuys.characters.Count}");
                    Console.WriteLine($"It is {badGuys.characters[i]._name}'s turn.");

                    if (badGuys._playerType == PlayerType.Computer) badGuys.characters[i].ComputerAction(badGuys, goodGuys);
                    else badGuys.characters[i].PlayerAction(badGuys, goodGuys);

                    // check if action eliminated enemy team
                    IsRoundOver(goodGuys, badGuys);
                    if (_roundOver) break;
                    Console.WriteLine();
                    Thread.Sleep(500);
                    _turn++;
                }
            }
        }

        /// <summary>
        /// String representation of player's turn
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public string GetTurn(int turn)
        {
            if (turn % 2 == 0) return "Heroes";
            else return "Monsters";
        }

        public void IsRoundOver(Party goodGuys, Party badGuys)
        {
            if (goodGuys.characters.Count == 0 || badGuys.characters.Count == 0)
            {
                // if good goodGuys count is 0, then we want to see if the game is over this round
                IsGameOver(_round);
                _roundOver = true;

                // reset turn for heroes to go first
                _turn = 0;
                
            }

            _roundOver = false;
        }

        public void IsGameOver(int round)
        {
            if (goodGuys.characters.Count == 0 || badGuys.characters.Count == 0)
            {
                
                Console.WriteLine();
                if (goodGuys.characters.Count == 0)
                {
                    _gameOver = true;
                    Console.WriteLine("The Heroes have lost and the Uncoded One's forces have prevailed.");
                }
                    
                else if (badGuys.characters.Count == 0 & round == 3)
                {
                    _gameOver = true;
                    Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                }
            }
            else _gameOver = false;

            
        }
    }

    

}
