using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FinalBattle.Menus;
using FinalBattle;

namespace FinalBattle
{
    public class Game
    {
        int _turn;
        int _round;
        public bool _gameOver;
        bool _roundOver;
        PlayerType _heroes;
        PlayerType _monsters;

        Party goodGuys;
        Party badGuys;

        CreateMenu menu = new CreateMenu();

        public Game(PlayerType heroes, PlayerType monsters)
        {
            _turn = 0;
            _round = 1;
            _gameOver = false;
            _roundOver = false;
            _heroes = heroes;
            _monsters = monsters;

            goodGuys = new Party(_heroes, "Heroes", 1, 3);
            badGuys = new Party(_monsters, "Monsters", 1, 1);
        }

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
                    // second round consists of 2 Skeleton characters
                    Console.WriteLine("You have advanced to Round 2!");
                    Console.WriteLine();

                    badGuys = new Party(_monsters, "Monsters", 2, 1);
                }

                if (_round == 3)
                {
                    // third round consists of the Uncoded One
                    Console.WriteLine("You have advanced to the Final Round! Get ready to fight the Uncoded One!");
                    Console.WriteLine();

                    badGuys = new Party(_monsters, "The Uncoded One", 1, 1);
                }

                Round(_round, badGuys);
                _round++;
            }
            
        }

        public void Round(int round, Party badGuys)
        {
            int playerTurn = 0;

            while (!_roundOver)
            {
                if (GetTurn(_turn) == "Heroes")
                {
                    // Console.WriteLine($"Bad guys left: {badGuys.characters.Count}");
                    Console.WriteLine($"It is {goodGuys.characters[playerTurn]._name}'s turn.");

                    // this gets menu and then allows player to choose action
                    menu.GetMenuItems(goodGuys, badGuys, goodGuys.characters[0]);                    

                    // increment turn before checking if round is over
                    _turn++;

                    // show round status after attack
                    ShowRoundStatus(goodGuys, badGuys, GetTurn(_turn));

                    // check if action eliminated enemy team
                    IsRoundOver(goodGuys, badGuys);
                    if (_roundOver) break;

                    Console.WriteLine();
                    Thread.Sleep(500);
                }

                

                if (GetTurn(_turn) == "Monsters")
                {
                    // Console.WriteLine($"Number of badGuys: {badGuys.characters.Count}");
                    Console.WriteLine($"It is {badGuys.characters[playerTurn]._name}'s turn.");

                    // TODO: need to iterate through characters, only the first character in a party is ever taking a turn right now
                    // this gets menu and then allows player to choose action
                    menu.GetMenuItems(badGuys, goodGuys, badGuys.characters[0]);                   

                    // increment turn before checking if round is over
                    _turn++;

                    // show round status after attack
                    ShowRoundStatus(goodGuys, badGuys, GetTurn(_turn));

                    // check if action eliminated enemy team
                    IsRoundOver(goodGuys, badGuys);
                    if (_roundOver) break;

                    Console.WriteLine();
                    Thread.Sleep(500);     
                }
            }

            // reset round
            _roundOver = false;
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
            }

            else _roundOver = false;
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

        public void ShowRoundStatus(Party goodGuys, Party badGuys, string turn)
        {
            Console.WriteLine();
            Console.WriteLine("======================Battle======================");
            if (turn == "Heroes") Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{goodGuys.characters[0]._name}        ( {goodGuys.characters[0]._currentHealth}/{goodGuys.characters[0]._maxHealth} )");
            Console.ResetColor();
            Console.WriteLine("------------------------VS------------------------");

            if (turn == "Monsters") Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < badGuys.characters.Count; i++)
                Console.WriteLine($"                           {badGuys.characters[i]._name}        ( {badGuys.characters[i]._currentHealth}/{badGuys.characters[i]._maxHealth} )");

            Console.ResetColor();
        }
    }
}
