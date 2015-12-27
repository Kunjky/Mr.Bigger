using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_postScore : GSTypedRequest<LogEventRequest_postScore, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_postScore() : base("LogEventRequest"){
			request.AddString("eventKey", "postScore");
		}
		public LogEventRequest_postScore Set_score( long value )
		{
			request.AddNumber("score", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_postScore : GSTypedRequest<LogChallengeEventRequest_postScore, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_postScore() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "postScore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_postScore SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_postScore Set_score( long value )
		{
			request.AddNumber("score", value);
			return this;
		}			
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_highScoreLeaderboard : GSTypedRequest<LeaderboardDataRequest_highScoreLeaderboard,LeaderboardDataResponse_highScoreLeaderboard>
	{
		public LeaderboardDataRequest_highScoreLeaderboard() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "highScoreLeaderboard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_highScoreLeaderboard (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_highScoreLeaderboard SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_highScoreLeaderboard : GSTypedRequest<AroundMeLeaderboardRequest_highScoreLeaderboard,AroundMeLeaderboardResponse_highScoreLeaderboard>
	{
		public AroundMeLeaderboardRequest_highScoreLeaderboard() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "highScoreLeaderboard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_highScoreLeaderboard (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_highScoreLeaderboard SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_highScoreLeaderboard : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_highScoreLeaderboard(GSData data) : base(data){}
		public long? score{
			get{return response.GetNumber("score");}
		}
	}
	
	public class LeaderboardDataResponse_highScoreLeaderboard : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_highScoreLeaderboard(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_highScoreLeaderboard> Data_highScoreLeaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_highScoreLeaderboard>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_highScoreLeaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highScoreLeaderboard> First_highScoreLeaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_highScoreLeaderboard>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_highScoreLeaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highScoreLeaderboard> Last_highScoreLeaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_highScoreLeaderboard>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_highScoreLeaderboard(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_highScoreLeaderboard : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_highScoreLeaderboard(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_highScoreLeaderboard> Data_highScoreLeaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_highScoreLeaderboard>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_highScoreLeaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highScoreLeaderboard> First_highScoreLeaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_highScoreLeaderboard>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_highScoreLeaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highScoreLeaderboard> Last_highScoreLeaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_highScoreLeaderboard>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_highScoreLeaderboard(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}
