using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private Reader reader;
        private Writer writer;

        private ManagerController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

            this.controller = new ManagerController();
        }
        public void Run()
        {
            File.Delete("result.txt");

            while (true)
            {
                try
                {

                    string input = this.reader.ReadLine();

                    if (input == "Exit")
                    {
                        break;
                    }

                    string[] data = input.Split().ToArray();
                    string command = data[0];

                    if (command == "AddPlayer")
                    {
                        string playerType = data[1];
                        string playerUsername = data[2];

                        string result = controller.AddPlayer(playerType, playerUsername);

                        this.writer.WriteLine(result);
                    }
                    else if (command == "AddCard")
                    {
                        string cardType = data[1];
                        string cardName = data[2];

                        string result = controller.AddCard(cardType, cardName);

                        this.writer.WriteLine(result);
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string username = data[1];
                        string cardName = data[2];

                        string result = controller.AddPlayerCard(username, cardName);

                        this.writer.WriteLine(result);
                    }
                    else if (command == "Fight")
                    {
                        string attackUser = data[1];
                        string enemyUser = data[2];

                        string result = controller.Fight(attackUser, enemyUser);

                        this.writer.WriteLine(result);
                    }
                    else if (command == "Report")
                    {
                        string result = controller.Report();

                        this.writer.WriteLine(result);
                    }
                }
                catch(Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}
