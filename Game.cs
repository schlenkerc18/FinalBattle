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
        int _round = 0;
        public bool _gameOver = false;

        Party goodGuys = new Party(PlayerType.Human, "Heroes", 1);
        Party badGuys = new Party(PlayerType.Computer, "Monsters", 1);

        public void RunGame()
        {
            while (!_gameOver)
            {
                for (int i = 0; i < goodGuys.characters.Count; i++)
                {
                    if (GetTurn(_turn) == "Heroes")
                    {
                        Console.WriteLine($"It is {goodGuys.characters[i]._name}'s turn.");

                        if (goodGuys._playerType == PlayerType.Computer) goodGuys.characters[i].ComputerAction(goodGuys, badGuys);
                        else goodGuys.characters[i].PlayerAction(goodGuys, badGuys);

                        // check if action eliminated enemy team
                        IsGameOver(goodGuys, badGuys);
                        if (_gameOver) break;
                        Console.WriteLine();
                        Thread.Sleep(500);
                        _turn++;
                    }

                    if (GetTurn(_turn) == "Monsters")
                    {
                        Console.WriteLine($"It is {badGuys.characters[i]._name}'s turn.");

                        if (badGuys._playerType == PlayerType.Computer) badGuys.characters[i].ComputerAction(badGuys, goodGuys);
                        else badGuys.characters[i].PlayerAction(badGuys, goodGuys);

                        // check if action eliminated enemy team
                        IsGameOver(badGuys, goodGuys);
                        if (_gameOver) break;
                        Console.WriteLine();
                        Thread.Sleep(500);
                        _turn++;
                    }
                }

                _round++;
            }
            
        }
        public string GetTurn(int turn)
        {
            if (turn % 2 == 0) return "Heroes";
            else return "Monsters";
        }

        public void IsGameOver(Party freinds, Party enemy)
        {
            if (goodGuys.characters.Count == 0 || badGuys.characters.Count == 0)
            {
                _gameOver = true;
                Console.WriteLine();
                Console.WriteLine($"{freinds._name} won the game!");
            }
            else _gameOver = false;

            
        }
    }

    

}
