namespace RankingTableLeague
{
    using System.Linq;
    internal class Program
    {
        [assembly: InternalsVisibleToAttribute("UnitTestsRankingTableLeague")]
        static void Main(string[] args)
        {
            Console.WriteLine("Write the path to the results of games document:");
            string pathDocumentResultsGames = Console.ReadLine();

            Ranking rankingObject = new Ranking();
            List<string> rankingList = rankingObject.CreateRanking(pathDocumentResultsGames);
            rankingObject.PrintRanking(rankingList);
            Console.ReadLine();

        }
    }
}
