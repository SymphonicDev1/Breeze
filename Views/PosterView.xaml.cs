﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GameLauncher.Models;
using GameLauncher.ViewModels;

namespace GameLauncher.Views
{
    public partial class PosterView : UserControl
    {
        private MainWindow MainWindow = ((MainWindow)Application.Current.MainWindow);
        public CollectionViewSource GameListCVS;

        public PosterView()
        {
            InitializeComponent();
        }

        private void GameLink_OnClick(object sender, RoutedEventArgs e)
        {
            object link = ((Button)sender).Tag;
            string linkstring = link.ToString().Trim();

            if (linkstring != "")
            {
                Process.Start(new ProcessStartInfo(linkstring));
            }
        }

        private void LaunchButton_OnClick(object sender, RoutedEventArgs e)
        {
            object link = ((Button)sender).Tag;
            string linkString = link.ToString().Trim();
            if (linkString != "")
            {
                Process.Start(new ProcessStartInfo(linkString));
            }
        }

        private void EditGame_OnClick(object sender, RoutedEventArgs e)
        {
            ModifyFile.EditGameInfile(((Button)sender).Tag);
            MainWindow.RefreshGames();
        }

        private void DeleteGame_OnClick(object sender, RoutedEventArgs e)
        {
            ModifyFile.RemoveGameFromFile(((Button)sender).Tag);
            MainWindow.RefreshGames();
        }

        private void SearchString_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
       {
            GameListCVS = ((CollectionViewSource)(FindResource("GameListCVS")));
            MainWindow.cvs = GameListCVS;
            GameListCVS.Filter += new FilterEventHandler(GenreFilter);
            GameListCVS.Filter += new FilterEventHandler(GameSearch);
            if (GameListCVS.View != null) //This is getting a null "GameListCVS.View" on genre only, works if searchbar updated
                GameListCVS.View.Refresh();
        }

        public void RefreshList2(CollectionViewSource cvscvs)
        {
            GameListCVS = cvscvs;
            GameListCVS.Filter += new FilterEventHandler(GenreFilter);
            GameListCVS.Filter += new FilterEventHandler(GameSearch);
            if (GameListCVS.View != null) //This is getting a null "GameListCVS.View" on genre only, works if searchbar updated
                GameListCVS.View.Refresh();
        }

        public static string FilterGenreName;

        public void GenreToFilter(string filtergenrename)
        {
            //Set public variable for use in GenreFilter
            FilterGenreName = filtergenrename;
        }

        private void GameSearch(object sender, FilterEventArgs e)
        {
            GameList gl = e.Item as GameList;
            if (GameSearchBar == null)
            {
                return;
            }
            else
            {

                e.Accepted &= gl.Title.ToUpper().Contains(GameSearchBar.Text.ToUpper());
            }
        }

        public void GenreFilter(object sender, FilterEventArgs e)
        {
            GameList gl = e.Item as GameList;
            if (FilterGenreName == null)
            {
                return;
            }
            else
            {
                e.Accepted &= gl.Genre.ToUpper().Contains(FilterGenreName.ToUpper());
            }
        }
    }
}