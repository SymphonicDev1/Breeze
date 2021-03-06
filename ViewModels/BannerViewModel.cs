﻿using GameLauncher.Models;
using System;
using System.Collections.ObjectModel;

namespace GameLauncher.ViewModels
{
    internal class BannerViewModel
    {
        public static ObservableCollection<GenreList> GenreListOC { get; set; }
        public ObservableCollection<GameList> BannerViewOC { get; set; }
        private LoadAllGames lag = new LoadAllGames();

        public void LoadGames()
        {
            lag.LoadGames();
            BannerViewOC = lag.Games;
        }

        public void LoadGenres()
        {
            lag.LoadGenres();
            GenreListOC = lag.Genres;
        }

        public void LoadList()
        {
            for (int i = 0; i < BannerViewOC.Count; i++)
            {
                Console.WriteLine(string.Concat(BannerViewOC[i].Title, " | ", BannerViewOC[i].Genre, "|", BannerViewOC[i].Path));
            }
        }
    }
}