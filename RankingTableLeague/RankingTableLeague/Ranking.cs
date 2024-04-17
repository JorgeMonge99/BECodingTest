using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingTableLeague
{
    public class Ranking
    {
        private Dictionary<string, int> rankingTable;
        private List<string> rankingTableFormattedList;
        const int gameWinPoints = 3;
        const int gameDrawPoints = 1;
        public Ranking() {
            rankingTable = new Dictionary<string, int>();
            rankingTableFormattedList = new List<string>();
        }
       public List<string> CreateRanking(string pathDocumentResultsGames)
        {
            String lineGameRegister;
            try
            {
                StreamReader documentResultsGames = new StreamReader(pathDocumentResultsGames);
                lineGameRegister = documentResultsGames.ReadLine();
                while (lineGameRegister != null)
                {
                    CalculateTeamPoints(lineGameRegister);
                    lineGameRegister = documentResultsGames.ReadLine();
                }
                documentResultsGames.Close();

                var RankingTableOrdened = rankingTable.OrderByDescending(team => team.Value).ThenBy(team => team.Key);
                
                AssignRankingPosition(RankingTableOrdened);
            }
            catch (Exception e){
                Console.WriteLine("Exception: " + e.Message);
            }
            return rankingTableFormattedList;
        }

        private void CalculateTeamPoints(string lineGameRegister)
        {
            string separatorTeams = ", ";
            string[] Teams = lineGameRegister.Split(separatorTeams);
            string separatorTeamScore = " ";
            int indexTeam1 = 0;
            int indexTeam2 = 1;
            string[] nameScoreTeam1 = Teams[indexTeam1].Split(separatorTeamScore);
            string[] nameScoreTeam2 = Teams[indexTeam2].Split(separatorTeamScore);

            string nameTeam1 = String.Join(' ', nameScoreTeam1.Take(nameScoreTeam1.Length - 1).ToArray());
            string nameTeam2 = String.Join(' ', nameScoreTeam2.Take(nameScoreTeam2.Length - 1).ToArray());

            int scoreTeam1 = int.Parse(nameScoreTeam1.Last());
            int scoreTeam2 = int.Parse(nameScoreTeam2.Last());

            int pointsToAddTeam1 = 0;
            int pointsToAddTeam2 = 0;
            if (scoreTeam1 > scoreTeam2)
            {
                pointsToAddTeam1 = gameWinPoints;
            }
            else if (scoreTeam1 < scoreTeam2)
            {
                pointsToAddTeam2 = gameWinPoints;
            }
            else
            {
                pointsToAddTeam1 = gameDrawPoints;
                pointsToAddTeam2 = gameDrawPoints;
            }

            int currentPointsTeam1 = 0;
            rankingTable.TryGetValue(nameTeam1, out currentPointsTeam1);
            int newPointsTeam1 = currentPointsTeam1 + pointsToAddTeam1;
            rankingTable[nameTeam1] = newPointsTeam1;

            int currentPointsTeam2 = 0;
            rankingTable.TryGetValue(nameTeam2, out currentPointsTeam2);
            int newPointsTeam2 = currentPointsTeam2 + pointsToAddTeam2;
            rankingTable[nameTeam2] = newPointsTeam2;
        }

        private void AssignRankingPosition(IOrderedEnumerable<KeyValuePair<string, int>> RankingTableOrdened)
        {
            string beforeTeamPoints = "";
            int rankingPosition = 0;
            int position = 0;

            foreach (var team in RankingTableOrdened)
            {
                string currentTeamPoints = team.Value.ToString();
                string currentTeamName = team.Key.ToString();
                position += 1;
                rankingPosition += (currentTeamPoints != beforeTeamPoints) ? 1 : 0;
                string pointsShortWord = (currentTeamPoints == "1") ? " pt" : " pts";
                string lineToPrint = rankingPosition + ". " + currentTeamName + ", " + currentTeamPoints + pointsShortWord;
                rankingTableFormattedList.Add(lineToPrint);
                beforeTeamPoints = currentTeamPoints;
                rankingPosition = position;
            }
        }

        public void PrintRanking(List<string> rankingListToPrint) {
            foreach (string team in rankingListToPrint) { 
                Console.WriteLine(team);
            }
        }
    }
}
