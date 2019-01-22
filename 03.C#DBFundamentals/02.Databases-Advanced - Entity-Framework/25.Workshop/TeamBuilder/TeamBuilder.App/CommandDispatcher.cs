using System;
using System.Linq;
using TeamBuilder.App.Core;
using TeamBuilder.App.Core.Command;

namespace TeamBuilder.App
{
    public class CommandDispatcher
    {
        private readonly AuthenticationManager _authManager;

        public CommandDispatcher(AuthenticationManager authManager)
        {
            this._authManager = authManager;
        }

        public string Dispatch(string input)
        {
            string[] args = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = args.Length > 0 ? args[0] : string.Empty;

            string[] commandArgs = args.Skip(1).ToArray();

            switch (commandName)
            {
                case "ShowTeam":
                    ShowTeamCommand showTeamCommand = new ShowTeamCommand();
                    return showTeamCommand.Execute(commandArgs);
                case "ShowEvent":
                    ShowEventCommand showEventCommand = new ShowEventCommand();
                    return showEventCommand.Execute(commandArgs);
                case "AddTeamTo":
                    AddTeamToCommand addTeamToCommand = new AddTeamToCommand(this._authManager);
                    return addTeamToCommand.Execute(commandArgs);
                case "Disband":
                    DisbandCommand disbandCommand = new DisbandCommand(this._authManager);
                    return disbandCommand.Execute(commandArgs);
                case "KickMember":
                    KickMemberCommand kickMemberCommand = new KickMemberCommand(this._authManager);
                    return kickMemberCommand.Execute(commandArgs);
                case "AcceptInvite":
                    AcceptInviteCommand acceptInviteCommand = new AcceptInviteCommand(this._authManager);
                    return acceptInviteCommand.Execute(commandArgs);
                case "DeclineInvite":
                    DeclineInviteCommand declineInviteCommand = new DeclineInviteCommand(this._authManager);
                    return declineInviteCommand.Execute(commandArgs);
                case "InviteToTeam":
                    InviteToTeamCommand inviteToTeamCommand = new InviteToTeamCommand(this._authManager);
                    return inviteToTeamCommand.Execute(commandArgs);
                case "CreateTeam":
                    CreateTeamCommand createTeamCommand = new CreateTeamCommand(this._authManager);
                    return createTeamCommand.Execute(commandArgs);
                case "CreateEvent":
                    CreateEventCommand createEventCommand = new CreateEventCommand(this._authManager);
                    return createEventCommand.Execute(commandArgs);
                case "Exit":
                    ExitCommand exitCommand = new ExitCommand();
                    return exitCommand.Execute(new string[0]);
                case "RegisterUser":
                    RegisterUserCommand registerUserCommand = new RegisterUserCommand(_authManager);
                    return registerUserCommand.Execute(commandArgs);
                case "Login":
                    LoginCommand loginCommand = new LoginCommand(this._authManager);
                    return loginCommand.Execute(commandArgs);
                case "Logout":
                    LogoutCommand logoutCommand = new LogoutCommand(this._authManager);
                    return logoutCommand.Execute(commandArgs);
                case "DeleteUser":
                    DeleteUserCommand deleteUserCommand = new DeleteUserCommand(this._authManager);
                    return deleteUserCommand.Execute(commandArgs);

                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }
        }
    }
}
