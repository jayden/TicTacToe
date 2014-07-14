using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    class GameControllerTest
    {
        private GameController controller;
        private Board board;
        private GameState currentState;
        private Player currentPlayer;
        private PerfectPlayer perfectPlayer;

        [TestFixtureSetUp]
        public void Init()
        {
            controller = new GameController();
        }

        [Test]
        [Ignore("Need to finish this test...")]
        public void InitGame()
        {
            controller.initGame();
        }
    }
}
