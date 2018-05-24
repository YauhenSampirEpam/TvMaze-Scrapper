﻿using System.Collections.Generic;

namespace TvMazeScrapper.Services.Api.TvMazeApi.DataModels
{
    public class ShowData
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<PersonData> Cast { get; set; }
    }
}