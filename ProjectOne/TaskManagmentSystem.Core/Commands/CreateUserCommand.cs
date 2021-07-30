﻿using System.Collections.Generic;
using TaskManagmentSystem.Core.Contracts;
using TaskManagmentSystem.Models.Common;

namespace TaskManagmentSystem.Core.Commands
{
    internal class CreateUserCommand : BaseCommand
    {
        private const int numberOfParameters = 1;


        public CreateUserCommand(List<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {

        }

        public override string Execute()
        {
            Validator.ValidateParametersCount(numberOfParameters, CommandParameters.Count);
            string username = CommandParameters[0];
            var user = this.Repository.CreateUser(username);

            return $"User with username {user.Name} was created";
        }
    }
}