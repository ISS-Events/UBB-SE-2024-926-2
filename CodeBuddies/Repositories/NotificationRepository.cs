using System.Data;
using System.Data.SqlClient;
using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;

namespace CodeBuddies.Repositories
{
    public class NotificationRepository : DBRepositoryBase, INotificationRepository
    {
        public NotificationRepository() : base()
        {
        }

        public List<Notification> GetAll()
        {
            List<Notification> notifications = new ();

            DataSet notificationDataSet = new ();
            string selectAll = "SELECT * FROM Notification";
            SqlCommand selectAllNotifications = new (selectAll, sqlConnection);
            dataAdapter.SelectCommand = selectAllNotifications;
            notificationDataSet.Clear();
            dataAdapter.Fill(notificationDataSet, "Notification");

            foreach (DataRow notificationRow in notificationDataSet.Tables["Notification"].Rows)
            {
                Notification currentNotification;

                if (notificationRow["Type"].ToString() == "invite")
                {
                    currentNotification = new InviteNotification((long)notificationRow["Id"], (DateTime)notificationRow["TimeStamp"], notificationRow["Type"].ToString(), notificationRow["Status"].ToString(), notificationRow["Description"].ToString(), (long)notificationRow["SenderId"], (long)notificationRow["ReceiverId"], (long)notificationRow["SessionId"], false);
                }
                else
                {
                    currentNotification = new InfoNotification((long)notificationRow["Id"], (DateTime)notificationRow["TimeStamp"], notificationRow["Type"].ToString(), notificationRow["Status"].ToString(), notificationRow["Description"].ToString(), (long)notificationRow["SenderId"], (long)notificationRow["ReceiverId"], (long)notificationRow["SessionId"]);
                }

                notifications.Add(currentNotification);
            }

            return notifications;
        }

        public List<Notification> GetAllByBuddyId(long buddyId)
        {
            List<Notification> notifications = new ();

            DataSet notificationDataSet = new ();
            string selectAll = "SELECT * FROM Notification WHERE ReceiverId=@buddyId";
            SqlCommand selectAllNotifications = new (selectAll, sqlConnection);
            selectAllNotifications.Parameters.AddWithValue("@buddyId", buddyId);
            dataAdapter.SelectCommand = selectAllNotifications;
            notificationDataSet.Clear();
            dataAdapter.Fill(notificationDataSet, "Notification");

            foreach (DataRow notificationRow in notificationDataSet.Tables["Notification"].Rows)
            {
                Notification currentNotification;

                if (notificationRow["Type"].ToString() == "invite")
                {
                    currentNotification = new InviteNotification((long)notificationRow["Id"], (DateTime)notificationRow["TimeStamp"], notificationRow["Type"].ToString(), notificationRow["Status"].ToString(), notificationRow["Description"].ToString(), (long)notificationRow["SenderId"], (long)notificationRow["ReceiverId"], (long)notificationRow["SessionId"], false);
                }
                else
                {
                    currentNotification = new InfoNotification((long)notificationRow["Id"], (DateTime)notificationRow["TimeStamp"], notificationRow["Type"].ToString(), notificationRow["Status"].ToString(), notificationRow["Description"].ToString(), (long)notificationRow["SenderId"], (long)notificationRow["ReceiverId"], (long)notificationRow["SessionId"]);
                }

                notifications.Add(currentNotification);
            }

            return notifications;
        }

        public void RemoveById(long notificationId)
        {
            string deleteNotificationQuery = "DELETE FROM Notification WHERE Id = @notificationId";
            using SqlCommand deleteCommand = new (deleteNotificationQuery, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@notificationId", notificationId);

            deleteCommand.ExecuteNonQuery();
        }

        public long GetFreeNotificationId()
        {
            long maxId = 0;
            string maxIdQuery = "SELECT MAX(Id) FROM Notification";

            using (SqlCommand command = new SqlCommand(maxIdQuery, sqlConnection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxId = Convert.ToInt64(result);
                }
            }

            // Increment the maximum ID to get a free ID
            return maxId + 1;
        }

        public void ClearDatabase()
        {
            List<string> tables = new ()
            {
                "BuddiesSessions", "MessagesCodeReviews", "MessagesSessions", "CodeReviewsSessions",
                "Notification", "Sessions", "Messages", "CodeReviews", "CodeContributions", "Buddies"
            };
            foreach (string table in tables)
            {
                string deleteNotificationQuery = $"DELETE FROM {table}";
                using SqlCommand deleteCommand = new (deleteNotificationQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void Save(Notification notification)
        {
            // Define the SQL command to insert a new notification
            string saveQuery = @"
                INSERT INTO Notification (Id, Timestamp, Type, Status, Description, SenderId, ReceiverId, SessionId)
                VALUES (@Id, @Timestamp, @Type, @Status, @Description, @SenderId, @ReceiverId, @SessionId)";

            // Create a SqlCommand object with the save query and connection
            using (SqlCommand saveCommand = new SqlCommand(saveQuery, sqlConnection))
            {
                // Add parameters to the SQL command
                saveCommand.Parameters.AddWithValue("@Id", GetFreeNotificationId());
                saveCommand.Parameters.AddWithValue("@Timestamp", notification.TimeStamp);
                saveCommand.Parameters.AddWithValue("@Type", notification.Type);
                saveCommand.Parameters.AddWithValue("@Status", notification.Status);
                saveCommand.Parameters.AddWithValue("@Description", notification.Description);
                saveCommand.Parameters.AddWithValue("@SenderId", notification.SenderId);
                saveCommand.Parameters.AddWithValue("@ReceiverId", notification.ReceiverId);
                saveCommand.Parameters.AddWithValue("@SessionId", notification.SessionId);

                // Execute the SQL command
                saveCommand.ExecuteNonQuery();
            }
        }
    }
}
