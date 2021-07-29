﻿using ProjectOne.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagmentSystem.Core.Commands
{
    public class CreateBugCommand : BaseCommand
    {
        public CreateBugCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)

        {

        }
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}