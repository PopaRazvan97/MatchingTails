﻿using System;

namespace MemoryTiles
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public Tuple<int, int> GamesPlayed { get; set; }

        public Profile(int id, string name, string avatar, int gamesPlayed, int gamesWon)
        {
            this.Id = id;
            this.Name = name;
            this.Avatar = avatar;
            this.GamesPlayed = new Tuple<int, int>(gamesPlayed, gamesWon);
        }

        public static bool operator ==(Profile profile1, Profile profile2)
        {
            return ReferenceEquals(profile1, profile2);
        }

        public static bool operator !=(Profile profile1, Profile profile2)
        {
            return !(ReferenceEquals(profile1, profile2));
        }

    }
}