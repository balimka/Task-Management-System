﻿using System;
using System.Collections;
using System.Collections.Generic;
using TaskManagmentSystem.Core.Contracts;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Models.Contracts;

namespace TaskManagmentSystem.Core
{
    public class Repository : IRepository
    {
        private int nextId;
        private readonly IList<IMember> users = new List<IMember>();
        private readonly IList<ITeam> teams = new List<ITeam>();
        public Repository()
        {
            this.nextId = 0;
        }
        public IList Users        
            => new List<IMember>(users);
        
        public IList Teams
            => new List<ITeam>(teams);

        public IMember CreateUser(string username)
        {
            var user = new Member(++nextId, username);
            this.users.Add(user);
            return user;
        }
        public ITeam CreateTeam(string teamName)
        {
            var team = new Team(++nextId, teamName);
            this.teams.Add(team);
            return team;
        }
        public IBoardItem CreateTask(Type type, string title, string description)
        {
            var task = Activator.CreateInstance(type, ++nextId, title, description) as IBoardItem;
            return task;
        }
    }
}
