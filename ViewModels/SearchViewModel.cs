﻿using GameLauncher.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameLauncher.ViewModels
{
    public class SearchViewModel
    {
        private LoadSearch ls = new LoadSearch();
        public static ObservableCollection<SearchResults> SearchList { get; set; }

        public void LoadSearch(string gametitle, string imagetype, string searchstring)
        {
            ls.Search(gametitle, imagetype, searchstring);
            SearchList = ls.SearchList;
        }
    }
}