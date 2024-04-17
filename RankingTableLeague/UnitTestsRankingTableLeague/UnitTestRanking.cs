using Microsoft.VisualStudio.TestTools.UnitTesting;
using RankingTableLeague;
using System.Linq;

namespace RankingTableLeague.Tests
{
    [TestClass()]
    public class UnitTestRanking
    {
        [TestMethod()]
        [DeploymentItem("inputResultsGames.txt")]
        public void CreateRanking() { 
            List<string> expectedRankingResult = new List<string>{"1. Tarantulas, 6 pts", "2. Lions, 5 pts", "3. FC Awesome, 1 pt",
                "3. Snakes, 1 pt", "5. Grouches, 0 pts" };

            Ranking rankingObject = new RankingTableLeague.Ranking();
            string pathDocumentResultsGames = "inputResultsGames.txt";
            List<string> rankingResult = rankingObject.CreateRanking(pathDocumentResultsGames);

            string expectedRankingText = String.Empty;
            foreach (string team in expectedRankingResult)
            {
                expectedRankingText += team;
            }

            string rankingResultText = String.Empty;
            foreach (string team in rankingResult)
            {
                rankingResultText += team;
            }

            Assert.AreEqual(expectedRankingText,rankingResultText);

        }
    }
}
