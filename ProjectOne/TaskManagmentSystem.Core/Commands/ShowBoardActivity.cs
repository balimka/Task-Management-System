using System.Collections.Generic;
using System.Linq;
using TaskManagmentSystem.Core.Contracts;
using TaskManagmentSystem.Models.Common;

namespace TaskManagmentSystem.Core.Commands
{
    public class ShowBoardActivity : BaseCommand
    {
        private const int numberOfParameters = 2;
        //showboardactivity [teamname] [boardID]
        public ShowBoardActivity(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {

        }
        public override string Execute()
        {
            Validator.ValidateParametersCount(numberOfParameters, CommandParameters.Count);

            string teamIdentifier = CommandParameters[0];
            string boardIdentifier = CommandParameters[1];

            var team = this.Repository.GetTeam(teamIdentifier);

            if (!this.Repository.IsTeamMember(team, this.Repository.LoggedUser))
            {
                throw new UserInputException(string.Format(Constants.MEMBER_NOT_IN_TEAM, this.Repository.LoggedUser.Name));
            }

            var board = this.Repository.GetBoard(boardIdentifier);

            return team.Boards.FirstOrDefault(x => x.Id == board.Id).ViewHistory();
        }
    }
}
