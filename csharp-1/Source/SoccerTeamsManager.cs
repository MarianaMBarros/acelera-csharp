using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private readonly List<Team> _teams;
        private readonly List<Player> _players;
        public SoccerTeamsManager()
        {
            _teams = new List<Team>();
            _players = new List<Player>();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            var team = _teams.FirstOrDefault(p => p.Id == id);
            if (team != null)
            {
                throw new UniqueIdentifierException();
            }
            team = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);
            _teams.Add(team);
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {

            var player = _players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                throw new UniqueIdentifierException();
            }

            var team = GetTeamById(teamId);

            player = new Player(id, team.Id, name, birthDate, skillLevel, salary);
            _players.Add(player);
        }

        private Team GetTeamById(long teamId)
        {
            var team = _teams.FirstOrDefault(p => p.Id == teamId);
            if (team == null)
            {
                throw new TeamNotFoundException();
            }
            return team;
        }

        private Player GetPlayerById(long playerId)
        {
            var player = _players.FirstOrDefault(p => p.Id == playerId);
            if (player == null)
            {
                throw new PlayerNotFoundException();
            }
            return player;
        }

        public void SetCaptain(long playerId)
        {

            var player = GetPlayerById(playerId);
            var team = GetTeamById(player.TeamId);
            team.SetCaptain(player.Id);
        }

        public long GetTeamCaptain(long teamId)
        {
            var team = GetTeamById(teamId);

            if (!team.CaptainId.HasValue)
            {
                throw new CaptainNotFoundException();
            }

            return team.CaptainId.Value;
        }

        public string GetPlayerName(long playerId)
        {
            var player = GetPlayerById(playerId);
            return player.Name;
        }

        public string GetTeamName(long teamId)
        {
            var team = GetTeamById(teamId);
            return team.Name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            var team = GetTeamById(teamId);
            if (team == null)
            {
                throw new TeamNotFoundException();
            }

            return _players.Where(p => p.TeamId == teamId)
                .Select(p => p.Id)
                .OrderBy(p => p)
                .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            var team = GetTeamById(teamId);

            var player = _players.Where(p => p.TeamId == team.Id)
                .OrderByDescending(p => p.SkillLevel)
                .ThenBy(p => p.Id)
                .FirstOrDefault();
            return player == null ? 0 : player.Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            var team = GetTeamById(teamId);

            var player = _players.Where(p => p.TeamId == team.Id)
                .OrderBy(p => p.BirthDate)
                .ThenBy(p => p.Id)
                .FirstOrDefault();
            return player == null ? 0 : player.Id;
        }

        public List<long> GetTeams()
        {
            return _teams
                .Select(p => p.Id)
                .OrderBy(p => p)
                .ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            var team = GetTeamById(teamId);

            var player = _players.Where(p => p.TeamId == team.Id)
                .OrderByDescending(p => p.Salary)
                .ThenBy(p => p.Id)
                .FirstOrDefault();
            return player == null ? 0 : player.Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            var player = GetPlayerById(playerId);
            return player.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            return _players
                .OrderByDescending(p => p.SkillLevel)
                .Take(top)
                .Select(p => p.Id)
                .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            var team = GetTeamById(teamId);
            var visitorTeam = GetTeamById(visitorTeamId);

            if (team.MainShirtColor == visitorTeam.MainShirtColor)
                return visitorTeam.SecondaryShirtColor;

            return visitorTeam.MainShirtColor;
        }

    }
}