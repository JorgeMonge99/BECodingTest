namespace RankingTableLeague
{
    using System.Linq;
    internal class Program
    {
        [assembly: InternalsVisibleToAttribute("UnitTestsRankingTableLeague")]
        static void Main(string[] args)
        {
            Console.WriteLine("Write the path to the game's result document:");
            string pathDocumentGamesResult = Console.ReadLine();

            Ranking rankingObject = new Ranking();
            List<string> rankingList = rankingObject.CreateRanking(pathDocumentGamesResult);
            rankingObject.PrintRanking(rankingList);

        }
    }
}
