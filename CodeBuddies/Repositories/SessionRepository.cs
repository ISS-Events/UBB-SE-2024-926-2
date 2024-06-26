﻿using System.Data;
using System.Data.SqlClient;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddies.Repositories
{
    public class SessionRepository : DBRepositoryBase, ISessionRepository
    {
        public SessionRepository() : base()
        {
        }

        #region Getters
        public List<Message> GetMessagesForSpecificSession(long sessionId)
        {
            List<Message> sessionMessages = new ();

            SqlDataAdapter dataAdapter = new ();

            DataSet messagesDataSet = new ();
            string selectAllMessagesForSpecificSession = "SELECT * FROM Messages m inner join MessagesSessions ms on m.i=Id = ms.MessageId where ms.SessionId = @id ";
            SqlCommand selectAllMessagesForSpecificSessionCommand = new (selectAllMessagesForSpecificSession, sqlConnection);
            selectAllMessagesForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllMessagesForSpecificSessionCommand;
            dataAdapter.Fill(messagesDataSet, "Messages");

            foreach (DataRow messageRow in messagesDataSet.Tables["Messages"].Rows)
            {
                Message currentMessage = new ((long)messageRow["Id"], Convert.ToDateTime(messageRow["Timestamp"]), messageRow["Content"].ToString(), (long)messageRow["SenderId"]);
                sessionMessages.Add(currentMessage);
            }

            return sessionMessages;
        }

        public List<CodeContribution> GetCodeContributionsForSpecificSession(long sessionId)
        {
            List<CodeContribution> codeContributions = new List<CodeContribution>();

            SqlDataAdapter dataAdapter = new ();
            DataSet codeContributionsDataSet = new ();
            string selectAllCodeContributionsForSpecificSession = "SELECT * FROM CodeContributions where SessionId = @id";
            SqlCommand selectAllCodeContributionsForSpecificSessionCommand = new (selectAllCodeContributionsForSpecificSession, sqlConnection);
            selectAllCodeContributionsForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllCodeContributionsForSpecificSessionCommand;
            dataAdapter.Fill(codeContributionsDataSet, "CodeContributions");

            foreach (DataRow codeContributionRow in codeContributionsDataSet.Tables["CodeContributions"].Rows)
            {
                CodeContribution currentCodeContribution = new ((long)codeContributionRow["BuddyId"], Convert.ToDateTime(codeContributionRow["ContributionDate"]), (int)codeContributionRow["ContributionValue"]);
                codeContributions.Add(currentCodeContribution);
            }

            return codeContributions;
        }

        public List<Message> GetMessagesForSpecificCodeReview(long codeReviewId)
        {
            List<Message> codeReviewMessages = new ();

            SqlDataAdapter dataAdapter = new ();
            DataSet messagesDataSet = new ();
            string selectAllMessagesForSpecificCodeReview = "SELECT * FROM Messages m inner join MessagesCodeReviews mcr on m.Id = mcr.MessageId where mcr.CodeReviewId = @id";
            SqlCommand selectAllMessagesForSpecificCodeReviewCommand = new SqlCommand(selectAllMessagesForSpecificCodeReview, sqlConnection);
            selectAllMessagesForSpecificCodeReviewCommand.Parameters.AddWithValue("@id", codeReviewId);
            dataAdapter.SelectCommand = selectAllMessagesForSpecificCodeReviewCommand;
            dataAdapter.Fill(messagesDataSet, "Messages");

            foreach (DataRow messageRow in messagesDataSet.Tables["Messages"].Rows)
            {
                Message currentMessage = new ((long)messageRow["Id"], Convert.ToDateTime(messageRow["Timestamp"]), messageRow["Content"].ToString(), (long)messageRow["SenderId"]);
                codeReviewMessages.Add(currentMessage);
            }

            return codeReviewMessages;
        }

        public List<CodeReviewSection> GetCodeReviewSectionsForSpecificSession(long sessionId)
        {
            List<CodeReviewSection> codeReviewSections = new ();

            SqlDataAdapter dataAdapter = new ();
            DataSet codeReviewSectionsDataSet = new ();
            string selectAllCodeReviewSectionsForSpecificSession = "SELECT * FROM CodeReviews cr inner join CodeReviewsSessions crs on cr.Id = crs.CodeReviewId where crs.SessionId = @id ";
            SqlCommand selectAllCodeReviewSectionsForSpecificSessionCommand = new (selectAllCodeReviewSectionsForSpecificSession, sqlConnection);
            selectAllCodeReviewSectionsForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllCodeReviewSectionsForSpecificSessionCommand;
            dataAdapter.Fill(codeReviewSectionsDataSet, "CodeReviews");

            foreach (DataRow codeReviewSectionRow in codeReviewSectionsDataSet.Tables["CodeReviews"].Rows)
            {
                bool isClosed = false;
                if (codeReviewSectionRow["Status"].ToString() != "closed")
                {
                    isClosed = true;
                }

                CodeReviewSection currentCodeReviewSection = new ((long)codeReviewSectionRow["Id"], (long)codeReviewSectionRow["OwnerId"], GetMessagesForSpecificCodeReview((long)codeReviewSectionRow["Id"]), codeReviewSectionRow["CodeSection"].ToString(), isClosed);
                codeReviewSections.Add(currentCodeReviewSection);
            }

            return codeReviewSections;
        }

        public List<long> GetBuddiesForSpecificSession(long sessionId)
        {
            List<long> sessionBuddies = new ();

            SqlDataAdapter dataAdapter = new ();
            DataSet buddiesDataSet = new ();
            string selectAllBuddiesForSpecificSession = "SELECT * FROM BuddiesSessions where session_id = @id";
            SqlCommand selectAllBuddiesForSpecificSessionCommand = new (selectAllBuddiesForSpecificSession, sqlConnection);
            selectAllBuddiesForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllBuddiesForSpecificSessionCommand;
            dataAdapter.Fill(buddiesDataSet, "BuddiesSessions");

            foreach (DataRow currentRow in buddiesDataSet.Tables["BuddiesSessions"].Rows)
            {
                sessionBuddies.Add((long)currentRow["BuddyId"]);
            }

            return sessionBuddies;
        }

        public List<Session> GetAllSessionsOfABuddy(long buddyId)
        {
            List<Session> sessions = new ();

            DataSet sessionDataSet = new ();
            string selectAllSessions = "SELECT * FROM Sessions s INNER JOIN BuddiesSessions bs ON s.Id = bs.session_id WHERE bs.buddy_id=@user_id";
            SqlCommand selectAllSessionsCommand = new (selectAllSessions, sqlConnection);
            selectAllSessionsCommand.Parameters.AddWithValue("@user_id", buddyId);
            dataAdapter.SelectCommand = selectAllSessionsCommand;
            dataAdapter.Fill(sessionDataSet, "Sessions");

            foreach (DataRow sessionRow in sessionDataSet.Tables["Sessions"].Rows)
            {
                List<Message> sessionMessages = GetMessagesForSpecificSession((long)sessionRow["Id"]);
                List<long> sessionBuddies = GetBuddiesForSpecificSession((long)sessionRow["Id"]);
                List<CodeContribution> sessionCodeContributions = GetCodeContributionsForSpecificSession((long)sessionRow["Id"]);
                List<CodeReviewSection> sessionCodeReviewSections = GetCodeReviewSectionsForSpecificSession((long)sessionRow["Id"]);

                Session session = new ((long)sessionRow["Id"], (long)sessionRow["OwnerId"], sessionRow["Name"].ToString(), Convert.ToDateTime(sessionRow["CreationDate"]), Convert.ToDateTime(sessionRow["LastEditDate"]), sessionBuddies, sessionMessages, sessionCodeContributions, sessionCodeReviewSections, new List<string>(), new TextEditor("black", new List<string>()), new DrawingBoard(string.Empty));
                sessions.Add(session);
            }

            return sessions;
        }

        public string GetSessionName(long sessionId)
        {
            string sessionName;

            string selectSessionNameQuery = "SELECT Name FROM Sessions WHERE Id = @SessionId";

            try
            {
                using SqlCommand selectCommand = new (selectSessionNameQuery, sqlConnection);
                selectCommand.Parameters.AddWithValue("@SessionId", sessionId);

                object result = selectCommand.ExecuteScalar();

                sessionName = result?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new NullColumn(ex.Message);
            }

            return sessionName;
        }

        public long GetFreeSessionId()
        {
            long freeSessionId = 0;

            // Execute a query to find a free session id
            string query = "SELECT TOP 1 Id FROM Sessions ORDER BY Id DESC";
            using (SqlCommand command = new (query, sqlConnection))
            {
                object result = command.ExecuteScalar();
                if (result != null && long.TryParse(result.ToString(), out long lastSessionId))
                {
                    freeSessionId = lastSessionId + 1;
                }
                else
                {
                    // Handle if no sessions exist in the database
                    freeSessionId = 1;
                }
            }

            return freeSessionId;
        }
        #endregion

        #region Adders
        public void AddBuddyMemberToSession(long buddyId, long sessionId)
        {
            string insertQuery = "INSERT INTO BuddiesSessions (BuddyId, SessionId) VALUES (@BuddyId, @SessionId)";
            try
            {
                using SqlCommand insertCommand = new (insertQuery, sqlConnection);
                insertCommand.Parameters.AddWithValue("@BuddyId", buddyId);
                insertCommand.Parameters.AddWithValue("@SessionId", sessionId);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new EntityAlreadyExists(ex.Message);
            }
        }

        public long AddNewSession(string sessionName, long ownerId, int maxParticipants)
        {
            long sessionId = 0;

            // Get a free session id
            long freeSessionId = GetFreeSessionId();

            string insertQuery = "INSERT INTO Sessions (Id, OwnerId, Name, CreationDate, LastEditDate) VALUES (@SessionId, @OwnerId, @SessionName, @CreationDate, @LastEditDate)";
            string insertMemberQuery = "INSERT INTO BuddiesSessions (BuddyId, SessionId) VALUES (@BuddyId, @SessionId)";

            try
            {
                using (SqlCommand insertCommand = new (insertQuery, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@SessionId", freeSessionId);
                    insertCommand.Parameters.AddWithValue("@SessionName", sessionName);
                    insertCommand.Parameters.AddWithValue("@OwnerId", ownerId);
                    insertCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@LastEditDate", DateTime.Now);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        sessionId = freeSessionId;
                    }
                }

                using (SqlCommand insertCommand = new (insertMemberQuery, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@BuddyId", ownerId);
                    insertCommand.Parameters.AddWithValue("@SessionId", freeSessionId);

                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new EntityAlreadyExists(ex.Message);
            }
            return sessionId;
        }
        #endregion

    }
}
