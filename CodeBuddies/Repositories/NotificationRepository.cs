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
            string selectAll = "SELECT * FROM Notifications";
            SqlCommand selectAllNotifications = new (selectAll, sqlConnection);
            dataAdapter.SelectCommand = selectAllNotifications;
            notificationDataSet.Clear();
            dataAdapter.Fill(notificationDataSet, "Notifications");

            foreach (DataRow notificationRow in notificationDataSet.Tables["Notifications"].Rows)
            {
                Notification currentNotification;

                if (notificationRow["notification_type"].ToString() == "invite")
                {
                    currentNotification = new InviteNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"], false);
                }
                else
                {
                    currentNotification = new InfoNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"]);
                }

                notifications.Add(currentNotification);
            }

            return notifications;
        }

        public List<Notification> GetAllByBuddyId(long buddyId)
        {
            List<Notification> notifications = new ();

            DataSet notificationDataSet = new ();
            string selectAll = "SELECT * FROM Notifications WHERE receiver_id=@buddyId";
            SqlCommand selectAllNotifications = new (selectAll, sqlConnection);
            selectAllNotifications.Parameters.AddWithValue("@buddyId", buddyId);
            dataAdapter.SelectCommand = selectAllNotifications;
            notificationDataSet.Clear();
            dataAdapter.Fill(notificationDataSet, "Notifications");

            foreach (DataRow notificationRow in notificationDataSet.Tables["Notifications"].Rows)
            {
                Notification currentNotification;

                if (notificationRow["notification_type"].ToString() == "invite")
                {
                    currentNotification = new InviteNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"], false);
                }
                else
                {
                    currentNotification = new InfoNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"]);
                }

                notifications.Add(currentNotification);
            }

            return notifications;
        }

        public void RemoveById(long notificationId)
        {
            string deleteNotificationQuery = "DELETE FROM Notifications WHERE id = @notificationId";
            using SqlCommand deleteCommand = new (deleteNotificationQuery, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@notificationId", notificationId);

            deleteCommand.ExecuteNonQuery();
        }

        public long GetFreeNotificationId()
        {
            long maxId = 0;
            string maxIdQuery = "SELECT MAX(id) FROM Notifications";

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
                "Notifications", "Sessions", "Messages", "CodeReviews", "CodeContributions", "Buddies"
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
                INSERT INTO Notifications (id, notification_timestamp, notification_type, notification_status, notification_description, sender_id, receiver_id, session_id)
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
