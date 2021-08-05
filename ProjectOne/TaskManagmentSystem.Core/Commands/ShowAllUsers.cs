﻿using System;
using System.Collections.Generic;
using TaskManagmentSystem.Core.Contracts;
using System.Linq;
using TaskManagmentSystem.Models.Contracts;
using System.Text;
using TaskManagmentSystem.Models.Common;

namespace TaskManagmentSystem.Core.Commands
{
    public class ShowAllUsers : BaseCommand
    {
        public ShowAllUsers(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)

        {

        }
        public override string Execute()
        {
            CheckIsRoot();
            if (this.Repository.Users.Count > 0)
            {
                var sb = new StringBuilder();

                foreach (var user in this.Repository.Users)  //ToDo: Find a way to make this switch LINQ
                {
                    sb.AppendLine(user.ToString());
                    sb.AppendLine(Constants.PRINT_INFO_SEPARATOR);
                }
                return sb.ToString().Trim();
            }
            return "There are no registered users."; //maybe constant ?
        }
    }
}