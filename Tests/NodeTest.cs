using System;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class NodeTest
    {
        private Node node;
        private ConsoleWrapperStub stub;

        [TestFixtureSetUp]
        public void Init()
        {
            node = new Node(0, 1);
            stub = new ConsoleWrapperStub();
        }

        [Test]
        public void InitializeNode()
        {
            Assert.IsTrue(node.Row == 0 && node.Col == 1);
        }

        [Test]
        public void NodeClear()
        {
            node.clear();

            Assert.IsTrue(node.content.Equals(Player.Empty));
        }

        [Test]
        public void NodeDrawPlayers()
        {
            string[] expectedConsoleOutput = { "   ", " O ", " X " };
            var players = Enum.GetValues(typeof(Player)).Cast<Player>().ToArray();

            for(int i = 0; i < players.Length; i++)
            {
                node.content = players[i];
                node.draw(stub);

                Assert.That(stub.output, Is.EqualTo(expectedConsoleOutput[i]));
            }
        }
    }
}
