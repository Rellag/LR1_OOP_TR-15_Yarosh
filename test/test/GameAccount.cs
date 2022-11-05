using System;
namespace test
{
    public class GameAccount
    {
        public string UserName { get; private set; }
        public int CurrentRating { get; private set; }
        public int GamesCount { get; private set; }


        public GameAccount(string userName, int сurrentRating, int gamesCount)
        {
            UserName = userName;
            CurrentRating = сurrentRating;
            GamesCount = gamesCount;
        }


        public void WinGame(GameAccount opponentName, int Rating)
        {

            if (Rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Rating), "Game rating can not be negative");
            }

            if (Rating >= CurrentRating && Rating >= opponentName.CurrentRating)
            {
                throw new ArgumentOutOfRangeException(nameof(Rating), "Game rating is too high");
            }

            CurrentRating += Rating;
            GamesCount++;
            opponentName.CurrentRating -= Rating;
            opponentName.GamesCount++;

            Console.WriteLine(UserName + " " + CurrentRating + " (+ {0}) " + "WON" + " " +
                opponentName.UserName + " " + opponentName.CurrentRating + " (- {1})", Rating, Rating);


            TheStat.AddFirst(new Stat(Rating, UserName, opponentName.UserName, CurrentRating, opponentName.CurrentRating));
            opponentName.TheStat.AddFirst(new Stat(Rating, UserName, opponentName.UserName, CurrentRating, opponentName.CurrentRating));
            Stat.ManeStat.AddFirst(new Stat(Rating, UserName, opponentName.UserName, CurrentRating, opponentName.CurrentRating));

            Stat.seedIndex++;
        }

        public void LoseGame(GameAccount opponentName, int Rating)
        {

            if (Rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Rating), "Game rating can not be negative");
            }

            if(Rating >= CurrentRating && Rating >= opponentName.CurrentRating)
            {
                throw new ArgumentOutOfRangeException(nameof(Rating), "Game rating is too high");
            }

            CurrentRating -= Rating;
            GamesCount++;
            opponentName.CurrentRating += Rating;
            opponentName.GamesCount++;


            Console.WriteLine(UserName + " " + CurrentRating + " (- {0}) " + "LOST"  + " " +
                opponentName.UserName + " " + opponentName.CurrentRating + " (+ {1})", Rating, Rating);


            TheStat.AddFirst(new Stat(Rating, opponentName.UserName, UserName, opponentName.CurrentRating, CurrentRating));
            opponentName.TheStat.AddFirst(new Stat(Rating, opponentName.UserName, UserName, opponentName.CurrentRating, CurrentRating));
            Stat.ManeStat.AddFirst(new Stat(Rating, opponentName.UserName, UserName, opponentName.CurrentRating, CurrentRating));

            Stat.seedIndex++;
        }

        LinkedList<Stat> TheStat = new LinkedList<Stat> { };


        public void GetStats()
        {

            Console.WriteLine("\nStats of {0}:", UserName);
            foreach (var item in TheStat)
            {
                Console.WriteLine("Game index: {0}, Game Rating: {1}, Winner: {2} {3} (+ {1})," +
                    " Looser: {4} {5}(- {1})", item.index, item.Rating, item.winner, item.winnerRating,
                    item.looser, item.looserRating);
            }

        }
    }

        

    public class Stat
    {
        public int index { get; }
        public int Rating { get; }
        public string winner { get; set; }
        public string looser { get; set; }
        public int winnerRating { get; }
        public int looserRating { get; }
        public static int seedIndex = 42000;

        public Stat(int rating, string winner, string looser, int winnerRating, int looserRating)
        {
            index = seedIndex;
            Rating = rating;
            this.winner = winner;
            this.looser = looser;
            this.winnerRating = winnerRating;
            this.looserRating = looserRating;
        }

      public static LinkedList<Stat> ManeStat = new LinkedList<Stat> { };

        public static void GetStats()
        {

            Console.WriteLine("\nStats:");
            foreach (var item in ManeStat)
            {
                Console.WriteLine("Game index: {0}, Game Rating: {1}, Winner: {2} {3} (+ {1})," +
                    " Looser: {4} {5}(- {1})", item.index, item.Rating, item.winner, item.winnerRating,
                    item.looser, item.looserRating);
            }

        }
    }

    
}

