﻿using System.Collections.Generic;
using TaskManagmentSystem.Models.Common;
using TaskManagmentSystem.Models.Contracts;

namespace TaskManagmentSystem.Models
{
    public class Team : ITeam
    {
        private string name;
        private IList<IMember> members = new List<IMember>();
        private IList<IBoard> boards = new List<IBoard>();
        private IList<IMember> administrators = new List<IMember>();

        public Team(int id, string name)
        {
            this.Id = id;
            this.Name = name;            
        }

        public IList<IMember> Members
            => new List<IMember>(this.members);


        public IList<IBoard> Boards
             => new List<IBoard>(this.boards);
        public IList<IMember> Administrators
            => new List<IMember>(administrators);
        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateObjectIsNotNULL(value, string.Format(Constants.ITEM_NULL_ERR, nameof(Team)));
                Validator.ValidateRange(value.Length, Constants.TEAM_NAME_MIN_SYMBOLS, Constants.TEAM_NAME_MAX_SYMBOLS, string.Format(Constants.STRING_LENGHT_ERR, nameof(Team), Constants.TEAM_NAME_MIN_SYMBOLS, Constants.TEAM_NAME_MAX_SYMBOLS));
                
                this.name = value;
            }
        }

        public int Id { get; }

        public void AddBoard(IBoard board)
        {
            this.boards.Add(board);
        }

        public void AddMember(IMember member)
        {
            this.members.Add(member);
        }
        public void AddAdministrator(IMember admin)
        {
            this.administrators.Add(admin);
        }

    }
}
