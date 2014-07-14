using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    class BoardTest
    {
        private Board board;
        private ConsoleWrapperStub stub;
        private int[] winningPatterns = 
        {
           0x1c0, 0x38, 0x7,     // rows
           0x124, 0x92, 0x49,     // column
           0x111, 0x54              // diagonals
        };

        [SetUp]
        public void Init()
        {
            board = new Board();
            stub = new ConsoleWrapperStub();
        }

        [Test]
        public void InitializeBoard()
        {
            Assert.AreEqual(board.node.Length, 9);
        }

        [Test]
        public void ClearBoard()
        {
            board.init();

            foreach(var node in board.node)
            {
                Assert.That(node.content, Is.EqualTo(Player.Empty));
            }
        }

        [Test]
        public void IsNotDraw()
        {
            // assign moves
            board.node[0, 1].content = Player.PlayerX;
            board.node[0, 0].content = Player.PlayerO;

            Assert.False(board.isDraw());
        }

        [Test]
        public void IsDraw()
        {
            // fill board
            foreach(var node in board.node)
            {
                node.content = Player.PlayerX;
            }

            Assert.True(board.isDraw());
        }
        
        [Test, TestCaseSource("winningPatterns")]
        public void ShouldWin(int pattern)
        {
            TraverseBoard((r) =>
                {
                    if (pattern % 2 == 0)
                    {
                        r.content = Player.PlayerO;
                        pattern = pattern >> 1;
                    }
                    else
                        r.content = Player.PlayerX;
                });

            Assert.True(board.hasWon(Player.PlayerX));
        }

        [Test]
        [Ignore("Need to finish writing this...")]
        public void DrawBoard()
        {
            int counter = 1;
            TraverseBoard( (r) =>
                {
                    if(counter % 3 == 0)
                    {
                        stub.WriteLine();
                    }
                });
        }

        [Test]
        public void TraverseTest()
        {
            int counter = 0;
            int expected = 3;
            board.TraverseBoard((r, c) =>
            {
                if (r == c)
                    counter++;
            });

            Assert.That(counter, Is.EqualTo(expected));
        }

        private void TraverseBoard(Action<Node> action)
        {
            foreach(var node in board.node)
            {
                action(node);
            }
        }
    }
}
