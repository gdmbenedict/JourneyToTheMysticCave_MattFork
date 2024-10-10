﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class _GameManager
    {
        #region Declarations
        Map map = new Map();
        GameStats gameStats = new GameStats();
        Gamelog gamelog = new Gamelog();
        Player player = new Player();
        LevelManager levelManager = new LevelManager();
        LegendColors legendColors = new LegendColors();
        HUD hUD = new HUD();
        EnemyManager enemyManager = new EnemyManager();
        ItemManager itemManager = new ItemManager();
        QuestManager questManager;

        bool gameOver = false;
        bool playerWon = false;
        #endregion

        public _GameManager()
        {
            Init();
        }

        public void Gameplay()
        {
            TutorialText();
            map.Update();
            hUD.Update();
            legendColors.Update();
            Draw();

            while (!gameOver)
            {
                Update();
                Draw();
                CheckGameOver();
            }
            Console.SetCursorPosition(0, 35);
            EndGame();
        }

        private void Init()
        {
            levelManager.Init(player);
            map.Init(levelManager, legendColors, player, enemyManager, itemManager);
            gameStats.Init(levelManager, map);
            player.Init(map, gameStats, legendColors, enemyManager, levelManager, itemManager);
            legendColors.Init(gameStats, map, levelManager);
            enemyManager.Init(gameStats, levelManager, legendColors, gamelog, player, map);
            itemManager.Init(gameStats, levelManager, legendColors, gamelog, player, map, enemyManager);
            gamelog.Init(player, enemyManager, itemManager, gameStats, map);
            hUD.Init(player, enemyManager, itemManager, map, legendColors);

            //Quest Manager creation
            questManager = new QuestManager(gameStats, map);
            questManager.quests.Add(new Quest(gameStats.Quest1Name, gameStats.Quest1Description, gameStats.Quest1Target, gameStats.Quest1CompletionNumber));
            questManager.quests.Add(new Quest(gameStats.Quest2Name, gameStats.Quest2Description, gameStats.Quest2Target, gameStats.Quest2CompletionNumber));
            questManager.quests.Add(new Quest(gameStats.Quest3Name, gameStats.Quest3Description, gameStats.Quest3Target, gameStats.Quest3CompletionNumber));
        }

        private void Update()
        {
            player.Update();
            levelManager.Update();
            map.Update();
            legendColors.Update();
            enemyManager.Update();
            itemManager.Update();
            hUD.Update();
            gamelog.Update();
            questManager.Update();
        }

        private void Draw()
        {
            map.Draw();
            legendColors.Draw();
            itemManager.Draw();
            enemyManager.Draw();
            player.Draw();
            hUD.Draw();
            gamelog.Draw();
            questManager.Draw();
        }

        void TutorialText()
        {
            Console.CursorVisible = false;

            Console.WriteLine("Text Based RPG Beta");
            Console.WriteLine();
            Console.WriteLine("Move:");
            DisplaySymbolsInColumns("Up   ", "W");
            DisplaySymbolsInColumns("Up-Left", "Q");
            Console.WriteLine();
            DisplaySymbolsInColumns("Down ", "S");
            DisplaySymbolsInColumns("Up-Right", "E");
            Console.WriteLine();
            DisplaySymbolsInColumns("Left ", "A");
            DisplaySymbolsInColumns("Down-Left", "Z");
            Console.WriteLine();
            DisplaySymbolsInColumns("Right", "D");
            DisplaySymbolsInColumns("Down-Right", "C");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        private void DisplaySymbolsInColumns(string direction, string description)
        {
            Console.Write($"{direction} = {description}");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(" ");
            }
        }

        void CheckGameOver()
        {
            if (enemyManager.AreAllEnemiesDead() && itemManager.IsMoneyCollected())
            {
                gameOver = true;
                playerWon = true;
            }
            if (player.healthSystem.dead)
            {
                gameOver = true;
                playerWon = false;
            }
        }

        void EndGame()
        {
            if (!player.healthSystem.dead)
                Console.WriteLine(player.name + " has won! Press enter to exit");
            else
                Console.WriteLine(player.name + " has died, press enter to exit");

            ConsoleKeyInfo input = Console.ReadKey();

            while (input.Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Press Enter");
                input = Console.ReadKey();
            }
            System.Environment.Exit(0);
        }
    }
}
